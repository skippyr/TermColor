import subprocess
import os
import shutil
import hashlib

project_name = 'TermColor'
assembly_name ='term-color'
publish_directory = 'publish'
license_file = 'LICENSE'
dotnet_version = subprocess.run('dotnet --version', shell=True, capture_output=True).stdout[:3].decode('utf-8')

class PublishItem:
    def __init__(self, os_name, cpu_arch, runtime_id):
        self.__os_name = os_name
        self.__cpu_arch = cpu_arch
        self.__runtime_id = runtime_id
    
    def get_os_name(self):
        return self.__os_name
    
    def get_cpu_arch(self):
        return self.__cpu_arch
    
    def get_runtime_id(self):
        return self.__runtime_id

class PublishInfo:
    def __init__(self, zip_file):
        self.__zip_file = zip_file
        self.__sha256sum = get_sha256sum(zip_file)

    def get_zip_file(self):
        return self.__zip_file
    
    def get_sha256sum(self):
        return self.__sha256sum

publish_items = [
    PublishItem('Windows', 'ARM64', 'win-arm64'),
    PublishItem('Windows', "x64", 'win-x64'),
    PublishItem('MacOS', 'ARM64', 'osx-arm64'),
    PublishItem('MacOS', 'x64', 'osx-x64'),
    PublishItem('Linux', 'ARM64', 'linux-arm64'),
    PublishItem('Linux', 'x64', 'linux-x64')
]

def get_sha256sum(file):
    hash = hashlib.sha256()
    
    with open(file, 'rb') as stream:
        for byte_block in iter(lambda: stream.read(4096), b''):
            hash.update(byte_block)

    return hash.hexdigest()

def clean():
    print('Cleaning existing builds:')

    try:
        shutil.rmtree(publish_directory)
    except FileNotFoundError:
        pass

    subprocess.run('dotnet clean', shell=True)

def publish_item(item):
    subprocess.run(f'dotnet publish -r {item.get_runtime_id()} /p:publishSingleFile=true /p:publishTrimmed=true /p:selfContained=true', shell=True)

def zip_item(zip_file, item):
    os.makedirs(publish_directory, exist_ok=True)
    subprocess.run(f'zip -j "{zip_file}" {' '.join(list(map(lambda file: f'"{file}"', [
        f'{os.path.join('bin', 'Release', f'net{dotnet_version}', item.get_runtime_id(), 'publish', f'{assembly_name}.exe' if item.get_os_name() == 'Windows' else assembly_name)}',
        license_file
    ])))}', shell=True)

clean()

publish_info_items = []

for item in publish_items:
    print()
    print(f'Publishing for platform "{item.get_os_name()} {item.get_cpu_arch()}":')
    zip_file = os.path.join(publish_directory, f'{project_name}.for.{item.get_os_name()}.{item.get_cpu_arch()}.zip')
    publish_item(item)
    zip_item(zip_file, item)
    publish_info_items.append(PublishInfo(zip_file))

print()
print('Published your project to all platforms.')
print()

for item in publish_info_items:
    print(f'{item.get_sha256sum()} {os.path.basename(item.get_zip_file())}')
