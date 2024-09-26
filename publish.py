import subprocess
import os
import shutil

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

publish_items = [
    PublishItem('Windows', 'ARM64', 'win-arm64'),
    PublishItem('Windows', "x64", 'win-x64'),
    PublishItem('MacOS', 'ARM64', 'osx-arm64'),
    PublishItem('MacOS', 'x64', 'osx-x64'),
    PublishItem('Linux', 'ARM64', 'linux-arm64'),
    PublishItem('Linux', 'x64', 'linux-x64')
]

def clean():
    print('Cleaning existing builds:')
    try:
        shutil.rmtree(publish_directory)
    except FileNotFoundError:
        pass
    subprocess.run('dotnet clean', shell=True)

def publish_item(item):
    subprocess.run(f'dotnet publish -r {item.get_runtime_id()} /p:publishSingleFile=true /p:publishTrimmed=true /p:selfContained=true', shell=True)

def zip_item(item):
    os.makedirs(publish_directory, exist_ok=True)
    subprocess.run(f'zip -j "{os.path.join(publish_directory, f'{project_name} for {item.get_os_name()} {item.get_cpu_arch()}.zip')}" {' '.join(list(map(lambda file: f'"{file}"', [
        f'{os.path.join('bin', 'Release', f'net{dotnet_version}', item.get_runtime_id(), 'publish', f'{assembly_name}.exe' if item.get_os_name() == 'Windows' else assembly_name)}',
        license_file
    ])))}', shell=True)

clean()
for item in publish_items:
    print()
    print(f'Publishing for platform "{item.get_os_name()} {item.get_cpu_arch()}":')
    publish_item(item)
    zip_item(item)

print()
print('Published your project to all platforms.')