using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode._2021.day1;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day1;

public class SolutionUnitTest
{
    private readonly List<string> _fileList = new()
        {"199", "200", "208", "210", "200", "207", "240", "269", "260", "263"};

    private readonly List<int> _list = new() {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};


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
        Assert.AreEqual(7, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartTwo(_list);

        // Assert
        Assert.AreEqual(5, result);
    }
}