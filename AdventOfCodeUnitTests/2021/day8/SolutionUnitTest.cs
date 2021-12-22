using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode._2021.day8;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day8;

public class SolutionUnitTest
{
    private List<Display> _displays = null!;

    [OneTimeSetUp]
    public void Setup()
    {
        var  solution = new Solution();
        using var file = new StreamReader(Directory.GetCurrentDirectory() + "/2021/day8/test-input.txt");
        _displays = solution.ParseInputFile(file);
    }


    [Test]
    public void Part1_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(_displays);

        // Assert
        Assert.AreEqual(26, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartTwo(_displays);

        // Assert
        Assert.AreEqual(61229, result);
    }
}