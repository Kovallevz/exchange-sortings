using Shouldly;
using System.Text.Json;
using Xunit;

using SortingAlgorithms.Core.Files;

namespace SortingAlgorithms.Core.Tests.Integration;

public class FileReaderTests
{
    [Fact]
    public void ReadFile_WhenFilePathIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var fileReader = new FileReader<double[]>();

        // Act
        var action = () => fileReader.Read(null);

        // Assert
        Should.Throw<ArgumentNullException>(action);
    }

    [Fact]
    public void ReadFile_WhenFilePathIsEmpty_ShouldThrowArgumentNullException()
    {
        // Arrange
        var fileReader = new FileReader<double[]>();

        // Act
        var action = () => fileReader.Read(string.Empty);

        // Assert
        Should.Throw<ArgumentNullException>(action);
    }

    [Fact]
    public void ReadFile_WhenFileDoesNotExist_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var fileName = "non-existent-file.json";
        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
        var fileReader = new FileReader<double[]>();

        // Act
        var action = () => fileReader.Read(path);

        // Assert
        Should.Throw<FileNotFoundException>(action);
    }

    [Fact]
    public void ReadFile_WhenFileIsIncorrect_ShouldThrowJsonException()
    {
        // Arrange
        var fileName = "incorrect-file.json";
        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
        var fileReader = new FileReader<double[]>();

        // Act
        var action = () => fileReader.Read(path);

        // Assert
        Should.Throw<JsonException>(action);
    }

    [Fact]
    public void ReadFile_WhenFileWithoutContent_ShouldThrowJsonException()
    {
        // Arrange
        var fileName = "without-content-file.json";
        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
        var fileReader = new FileReader<double[]>();

        // Act
        var action = () => fileReader.Read(path);

        // Assert
        Should.Throw<JsonException>(action);
    }

    [Fact]
    public void ReadFile_WhenFileIsCorrect_ShouldReadFileSuccessfully()
    {
        // Arrange
        var fileName = "correct-file.json";
        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
        var fileReader = new FileReader<double[]>();

        var expectedResult = new double[]
        {
            1, 2, 434, 5454.65, 23, 54.6, 45, 3.56, 0.566, 334
        };

        // Act
        var result = fileReader.Read(path);

        // Assert
        result.ShouldBe(expectedResult);
    }

    [Fact]
    public void ReadFile_WhenFileIsEmpty_ShouldReadFileSuccessfully()
    {
        // Arrange
        var fileName = "empty-file.json";
        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
        var fileReader = new FileReader<double[]>();

        // Act
        var result = fileReader.Read(path);

        // Assert
        result.ShouldBeEmpty();
    }
}
