using SortingAlgorithms.Core.Enums;
using SortingAlgorithms.Core.Models;

namespace SortingAlgorithms.Core.Algorithms.Interfaces;

/// <summary>
/// Sorting method interface.
/// </summary>
public interface ISort
{
    /// <summary>
    /// Gets a sort type.
    /// </summary>
    SortType SortType { get; }

    /// <summary>
    /// Sort array.
    /// </summary>
    /// <param name="array">The source array.</param>
    /// <param name="sortDirection">The sort direction.</param>
    /// <returns>The sorting result.</returns>
    SortingResult Sort(double[] array, SortDirection sortDirection);
}
