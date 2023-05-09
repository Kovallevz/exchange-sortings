using Shouldly;
using Xunit;

using SortingAlgorithms.Core.Algorithms;
using SortingAlgorithms.Core.Models;

namespace SortingAlgorithms.Core.Tests.Unit;

public class CocktailShakerSortTests
{
    [Fact]
    public void SortArray_WhenArrayIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var cocktailShakerSort = new CocktailShakerSort();

        // Act
        var action = () => cocktailShakerSort.Sort(null, Enums.SortDirection.Ascending);

        // Assert
        Should.Throw<ArgumentNullException>(action);
    }

    [Fact]
    public void SortArrayByAscending_WhenArrayExists_ShouldSortSuccessfully()
    {
        // Arrange
        var cocktailShakerSort = new CocktailShakerSort();
        var sortDirection = Enums.SortDirection.Ascending;

        var expectedResult = new SortingResult(HelperData.SourceArray, Enums.SortType.CocktailShakerSort, sortDirection)
        {
            SortedArray = HelperData.SortedByAscendingArray,
            NumberOfComparisons = 42,
            NumberOfShifts = 22,
        };

        // Act
        var result = cocktailShakerSort.Sort(HelperData.SourceArray, sortDirection);

        // Assert
        result.ShouldBeEquivalentTo(expectedResult);
    }

    [Fact]
    public void SortArrayByDescending_WhenArrayExists_ShouldSortSuccessfully()
    {
        // Arrange
        var cocktailShakerSort = new CocktailShakerSort();
        var sortDirection = Enums.SortDirection.Descending;

        var expectedResult = new SortingResult(HelperData.SourceArray, Enums.SortType.CocktailShakerSort, sortDirection)
        {
            SortedArray = HelperData.SortedByDescendingArray,
            NumberOfComparisons = 42,
            NumberOfShifts = 23,
        };

        // Act
        var result = cocktailShakerSort.Sort(HelperData.SourceArray, sortDirection);

        // Assert
        result.ShouldBeEquivalentTo(expectedResult);
    }
}
