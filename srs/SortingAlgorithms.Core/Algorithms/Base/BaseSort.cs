using SortingAlgorithms.Core.Algorithms.Interfaces;
using SortingAlgorithms.Core.Enums;
using SortingAlgorithms.Core.Models;

namespace SortingAlgorithms.Core.Algorithms.Base;

/// <summary>
/// Base sorting.
/// </summary>
public abstract class BaseSort : ISort
{
    private readonly Dictionary<SortDirection, Func<double, double, bool>> ComparisonFunctions = new Dictionary<SortDirection, Func<double, double, bool>>
    {
        { SortDirection.Ascending, (numberOne, numberTwo) => numberOne > numberTwo },
        { SortDirection.Descending, (numberOne, numberTwo) => numberOne < numberTwo },
    };

    /// <inheritdoc/>
    public abstract SortType SortType { get; }

    /// <inheritdoc/>
    public abstract SortingResult Sort(double[] array, SortDirection sortDirection);

    /// <summary>
    /// Validate array.
    /// </summary>
    /// <param name="array">The source array.</param>
    /// <exception cref="ArgumentNullException">Throws this exception if the source array is null.</exception>
    protected void ValidateArray(double[] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
    }

    /// <summary>
    /// Copy source array to new.
    /// This function is necessary in order not to modify the original array.
    /// </summary>
    /// <param name="array">Source array.</param>
    /// <returns>Copied array.</returns>
    protected double[] GetSourceArrayCopy(double[] array)
    {
        var newArray = new double[array.Length];
        Array.Copy(array, newArray, array.Length);

        return newArray;
    }

    /// <summary>
    /// Get comparison function by sort direction.
    /// </summary>
    /// <param name="sortDirection">The sort direction.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException">Throws this exception if the sort direction is not implemented in the particular sort type..</exception>
    protected Func<double, double, bool> GetComparisonFunctions(SortDirection sortDirection)
    {
        if (!ComparisonFunctions.TryGetValue(sortDirection, out var comparisonFunction))
        {
            throw new NotImplementedException($"Bubble sorting for {sortDirection} direction is not implemented");
        }

        return comparisonFunction;
    }
}
