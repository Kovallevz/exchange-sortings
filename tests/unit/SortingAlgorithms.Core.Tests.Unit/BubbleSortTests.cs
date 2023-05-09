using Shouldly;
using Xunit;

using SortingAlgorithms.Core.Algorithms;
using SortingAlgorithms.Core.Models;

namespace SortingAlgorithms.Core.Tests.Unit;

public class BubbleSortTests
{
    [Fact]
    public void SortArray_WhenArrayIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var bubbleSort = new BubbleSort();

        // Act
        var action = () => bubbleSort.Sort(null, Enums.SortDirection.Ascending);

        // Assert
        Should.Throw<ArgumentNullException>(action);
    }

    [Fact]
    public void SortArrayByAscending_WhenArrayExists_ShouldSortSuccessfully()
    {
        // Arrange
        var bubbleSort = new BubbleSort();
        var sortDirection = Enums.SortDirection.Ascending;

        var expectedResult = new SortingResult(HelperData.SourceArray, Enums.SortType.BubbleSort, sortDirection)
        {
            SortedArray = HelperData.SortedByAscendingArray,
            NumberOfComparisons = 45,
            NumberOfShifts = 22,
        };

        // Act
        var result = bubbleSort.Sort(HelperData.SourceArray, sortDirection);

        // Assert
       result.ShouldBeEquivalentTo(expectedResult);
    }

    [Fact]
    public void SortArrayByDescending_WhenArrayExists_ShouldSortSuccessfully()
    {
        // Arrange
        var bubbleSort = new BubbleSort();
        var sortDirection = Enums.SortDirection.Descending;

        var expectedResult = new SortingResult(HelperData.SourceArray, Enums.SortType.BubbleSort, sortDirection)
        {
            SortedArray = HelperData.SortedByDescendingArray,
            NumberOfComparisons = 44,
            NumberOfShifts = 23,
        };

        // Act
        var result = bubbleSort.Sort(HelperData.SourceArray, sortDirection);

        // Assert
        result.ShouldBeEquivalentTo(expectedResult);
    }
}
