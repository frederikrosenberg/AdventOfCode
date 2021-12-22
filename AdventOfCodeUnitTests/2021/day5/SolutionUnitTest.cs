using System.Collections.Generic;
using System.IO;
using AdventOfCode._2021.day5;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day5;

public class SolutionUnitTest
{
    private readonly Solution _solution = new();
    private List<Line> _lines = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        using var file = new StreamReader(Directory.GetCurrentDirectory() + "/2021/day5/test-input.txt");
        _lines = _solution.ParseInputFile(file);
    }

    [Test]
    public void Part1_solves_example_correct()
    {
        // Act
        var result = _solution.PartOne(_lines);

        // Assert
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Act
        var result = _solution.PartTwo(_lines);

        // Assert
        Assert.AreEqual(12, result);
    }
}