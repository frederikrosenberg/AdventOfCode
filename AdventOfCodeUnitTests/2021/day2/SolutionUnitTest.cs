using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode._2021.day2;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day2;

public class SolutionUnitTest
{
    private readonly List<string> _fileList = new() {"forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2"};

    private readonly List<Move> _list = new()
    {
        new Move(Direction.forward, 5), new Move(Direction.down, 5), new Move(Direction.forward, 8),
        new Move(Direction.up, 3), new Move(Direction.down, 8), new Move(Direction.forward, 2)
    };

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
    public void ParseFile_throws_if_invalid_enum()
    {
        // Arrange 
        var solution = new Solution();
        var bytes = Encoding.ASCII.GetBytes("backwards 2\n");
        var memoryStream = new MemoryStream(bytes);
        using var reader = new StreamReader(memoryStream);

        // Act + assert
        Assert.Throws<InvalidOperationException>(() => solution.ParseInputFile(reader));
    }


    [Test]
    public void Part1_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(_list);

        // Assert
        Assert.AreEqual(150, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartTwo(_list);

        // Assert
        Assert.AreEqual(900, result);
    }
}