using SortingAlgorithms.Core.Enums;

namespace SortingAlgorithms.Core.Models;

/// <summary>
/// Sorting result model.
/// </summary>
public class SortingResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SortingResult"/> class.
    /// </summary>
    /// <param name="sourceArray">The source array.</param>
    /// <param name="sortType">The sort type.</param>
    /// <param name="sortDirection">The sort direction.</param>
    public SortingResult(double[] sourceArray, SortType sortType, SortDirection sortDirection)
    {
        SourceArray = sourceArray;
        SortType = sortType;
        SortDirection = sortDirection;
    }

    /// <summary>
    /// Gets source array.
    /// </summary>
    public double[] SourceArray { get; }

    /// <summary>
    /// Gets sort type.
    /// </summary>
    public SortType SortType { get; }

    /// <summary>
    /// Gets sort direction.
    /// </summary>
    public SortDirection SortDirection { get; }

    /// <summary>
    /// Gets or sets number of comparisons.
    /// </summary>
    public int NumberOfComparisons { get; set; }

    /// <summary>
    /// Gets or sets number of shifts.
    /// </summary>
    public int NumberOfShifts { get; set; }

    /// <summary>
    /// Gets or sets sorted array.
    /// </summary>
    public double[] SortedArray { get; set; }
}
