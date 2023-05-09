using SortingAlgorithms.Core.Algorithms.Base;
using SortingAlgorithms.Core.Enums;
using SortingAlgorithms.Core.Models;

namespace SortingAlgorithms.Core.Algorithms;

/// <summary>
/// Bubble sorting implementation.
/// </summary>
public class BubbleSort : BaseSort
{
    /// <inheritdoc/>
    public override SortType SortType => SortType.BubbleSort;

    /// <inheritdoc/>
    public override SortingResult Sort(double[] array, SortDirection sortDirection)
    {
        this.ValidateArray(array);

        var result = new SortingResult(array, this.SortType, sortDirection);

        var comparisonFunction = this.GetComparisonFunctions(sortDirection);
        var arrayToSort = this.GetSourceArrayCopy(array);

        var length = arrayToSort.Length;

        bool swapped;
        double tempBuffer;

        for (int i = 0; i < length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < length - i - 1; j++)
            {
                result.NumberOfComparisons++;
                if (comparisonFunction(arrayToSort[j], arrayToSort[j + 1]))
                {
                    tempBuffer = arrayToSort[j];
                    arrayToSort[j] = arrayToSort[j + 1];
                    arrayToSort[j + 1] = tempBuffer;
                    swapped = true;
                    result.NumberOfShifts++;
                }
            }

            if (swapped == false)
            {
                break;
            }
        }

        result.SortedArray = arrayToSort;

        return result;
    }
}
