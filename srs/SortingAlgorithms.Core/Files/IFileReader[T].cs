namespace SortingAlgorithms.Core.Files;

/// <summary>
/// File reader interface.
/// </summary>
/// <typeparam name="T">Type of the file content.</typeparam>
public interface IFileReader<T>
{
    /// <summary>
    /// Read file content.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>File content.</returns>
    public T? Read(string path);
}
