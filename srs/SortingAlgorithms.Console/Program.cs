using ConsoleTables;

using SortingAlgorithms.Core.Algorithms;
using SortingAlgorithms.Core.Algorithms.Interfaces;
using SortingAlgorithms.Core.Enums;
using SortingAlgorithms.Core.Files;
using SortingAlgorithms.Core.Models;

/// All sorting algorithms.
var algorithms = new List<ISort>{ new BubbleSort(), new CocktailShakerSort() };

/// File reader.
var fileReader = new FileReader<double[]>();

/// Handles of the particular sorting.
var handleSort = (double[] array, ISort algorithm, SortDirection sortDirection)
    => algorithm.Sort(array, sortDirection);

/// Prints result to console table.
var printResultTable = (List<SortingResult> result) =>
{
    Console.WriteLine("Result Table:");
    var table = new ConsoleTable("Type of Sorting", "Direction", "Number of Comparisons", "Number of Shifts");

    foreach (var data in result)
    {
        table.AddRow(
            data.SortType.ToString(),
            data.SortDirection.ToString(),
            data.NumberOfComparisons,
            data.NumberOfShifts);
    }

    table.Write();
};

try
{
    /// The variable to store results of sorting.
    var result = new List<SortingResult>();

    /// Read file path from console.
    Console.WriteLine("Please enter the file path:");
    var filePath = Console.ReadLine();

    /// Read file.
    var data = fileReader.Read(filePath);

    /// Sort data from file using all algorithms and save result to variable.
    foreach (var sorting in algorithms)
    {
        result.Add(handleSort(data, sorting, SortDirection.Ascending));
        result.Add(handleSort(data, sorting, SortDirection.Descending));
    }

    /// Prints result to console table.
    printResultTable(result);

    Console.ReadKey();
}
catch(Exception exception)
{
    Console.WriteLine(exception.Message);
    Console.ReadKey();
}