using System;
using System.IO;

using TermColor.Cli.Widgets.Display;

namespace TermColor.FileSystem;

internal class TextFileHandler : IDisposable
{
    public string Path { get; }
    private readonly FileStream _stream;
    private StreamWriter? _streamWriter;
    public StreamWriter StreamWriter => _streamWriter ??= new StreamWriter(_stream, leaveOpen: true);

    public TextFileHandler(string type, string path, bool shouldCreate = false)
    {
        try
        {
            Path = path;
            _stream = File.Open(path, shouldCreate ? FileMode.OpenOrCreate : FileMode.Open);
        }
        catch (FileNotFoundException)
        {
            ErrorMessageWidget.Display($"the {type} file \"{path}\" does not exist.");
            Program.Close(false);

            throw;
        }
        catch (DirectoryNotFoundException)
        {
            ErrorMessageWidget.Display($"the parent directory of the {type} file \"{path}\" does not exist.");
            Program.Close(false);

            throw;
        }
        catch (UnauthorizedAccessException)
        {
            ErrorMessageWidget.Display(Directory.Exists(path)
                ? $"the {type} file \"{path}\" must be of regular file type."
                : $"not enough permissions to manipulate the {type} file \"{path}\".");
            Program.Close(false);

            throw;
        }
    }

    public string Read()
    {
        using StreamReader reader = new(_stream, leaveOpen: true);

        return reader.ReadToEnd();
    }

    public void Write(string contents)
    {
        StreamWriter.Write(contents);
    }

    public void Dispose()
    {
        StreamWriter.Dispose();
        _stream.Dispose();
    }
}