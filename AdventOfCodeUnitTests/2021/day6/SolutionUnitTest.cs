using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode._2021.day6;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day6;

public class SolutionUnitTest
{
    private readonly List<string> _fileList = new() {"3,4,3,1,2"};

    private readonly List<int> _list = new() {3, 4, 3, 1, 2};


    [Test]
    public void ParseFile_pareses_correct()
    {
        // Arrange
        var solution = new Solution();
        var bytes = Encoding.ASCII.GetBytes(_fileList.Aggregate((s, c) => s + "\n" + c));
        var memoryStream = new MemoryStream(bytes);
        using var reader = new StreamReader(memoryStream);

        // Act
        var result = solution.ParseInputFile(reader);

        // Assert
        Assert.That(result, Is.EquivalentTo(_list));
    }


    [Test]
    public void Part1_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(_list);

        // Assert
        Assert.AreEqual(5934, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartTwo(_list);

        // Assert
        Assert.AreEqual(26984457539, result);
    }
}