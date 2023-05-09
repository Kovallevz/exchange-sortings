using SortingAlgorithms.Core.Algorithms.Base;
using SortingAlgorithms.Core.Enums;
using SortingAlgorithms.Core.Models;

namespace SortingAlgorithms.Core.Algorithms;

/// <summary>
/// Cocktail shaker sorting implementation.
/// </summary>
public class CocktailShakerSort : BaseSort
{
    /// <inheritdoc/>
    public override SortType SortType => SortType.CocktailShakerSort;
    /// <inheritdoc/>
    public override SortingResult Sort(double[] array, SortDirection sortDirection)
    {
        this.ValidateArray(array);
        var result = new SortingResult(array, this.SortType, sortDirection);
        var comparisonFunction = this.GetComparisonFunctions(sortDirection);
        var arrayToSort = this.GetSourceArrayCopy(array);
        int length = arrayToSort.Length;
        bool swapped = true;
        int start = 0;
        int end = length - 1;
        double tempBuffer;
        while (swapped)
        {
            swapped = false;
            for (int i = start; i < end; i++)
            {
                result.NumberOfComparisons++;
                if (comparisonFunction(arrayToSort[i], arrayToSort[i + 1]))
                {
                    tempBuffer = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[i + 1];
                    arrayToSort[i + 1] = tempBuffer;
                    swapped = true;
                    result.NumberOfShifts++;
                }
            }
            if (!swapped)
            {
                break;
            }
            end--;
            for (int i = end - 1; i >= start; i--)
            {
                result.NumberOfComparisons++;
                if (comparisonFunction(arrayToSort[i], arrayToSort[i + 1]))
                {
                    tempBuffer = arrayToSort[i];
                    arrayToSort[i] = arrayToSort[i + 1];
                    arrayToSort[i + 1] = tempBuffer;
                    swapped = true;
                    result.NumberOfShifts++;
                }
            }
            start++;
        }
        result.SortedArray = arrayToSort;
        return result;
    }
}
