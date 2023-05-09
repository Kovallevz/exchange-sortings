using System.Text.Json;

namespace SortingAlgorithms.Core.Files;

/// <summary>
/// File reader.
/// </summary>
///  <typeparam name="T">Type of the file content.</typeparam>
public class FileReader<T> : IFileReader<T>
{
    /// <inheritdoc/>
    public T? Read(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        var content = File.ReadAllText(path);
        var data = JsonSerializer.Deserialize<T>(content);

        return data;
    }
}
