using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode._2021.day3;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day3;

public class SolutionUnitTest
{
    private readonly List<string> _fileList = new()
    {
        "00100",
        "11110",
        "10110",
        "10111",
        "10101",
        "01111",
        "00111",
        "11100",
        "10000",
        "11001",
        "00010",
        "01010"
    };

    private readonly List<int> _list = new()
    {
        0b00100,
        0b11110,
        0b10110,
        0b10111,
        0b10101,
        0b01111,
        0b00111,
        0b11100,
        0b10000,
        0b11001,
        0b00010,
        0b01010
    };


    [Test]
    public void ParseFile_pareses_correct()
    {
        var solution = new Solution(5);
        var bytes = Encoding.ASCII.GetBytes(_fileList.Aggregate((s, c) => s + "\n" + c));
        var memoryStream = new MemoryStream(bytes);
        using var reader = new StreamReader(memoryStream);

        var result = solution.ParseInputFile(reader);

        Assert.That(result, Is.EquivalentTo(_list));
    }


    [Test]
    public void Part1_solves_example_correct()
    {
        // Arrange
        var solution = new Solution(5);

        // Act
        var result = solution.PartOne(_list);

        // Assert
        Assert.AreEqual(198, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Arrange
        var solution = new Solution(5);

        // Act
        var result = solution.PartTwo(_list);

        // Assert
        Assert.AreEqual(230, result);
    }
}