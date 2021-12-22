using System.IO;
using AdventOfCode._2021.day4;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day4;

public class SolutionUnitTest
{
    private readonly Solution _solution = new();
    private Bingo _bingo = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        using var file = new StreamReader(Directory.GetCurrentDirectory() + "/2021/day4/test-input.txt");
        _bingo = _solution.ParseInputFile(file);
    }

    [Test]
    public void Part1_solves_example_correct()
    {
        // Act
        var result = _solution.PartOne(_bingo);

        // Assert
        Assert.AreEqual(4512, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Act
        var result = _solution.PartTwo(_bingo);

        // Assert
        Assert.AreEqual(1924, result);
    }
}