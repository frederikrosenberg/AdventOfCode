using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode._2021.day10;
using NUnit.Framework;

namespace AdventOfCodeUnitTests._2021.day10;

public class SolutionUnitTest
{
    private readonly List<string> _list = new()
    {
        "[({(<(())[]>[[{[]{<()<>>",
        "[(()[<>])]({[<{<<[]>>(",
        "{([(<{}[<>[]}>{[]{[(<()>",
        "(((({<>}<{<{<>}{[]{[]{}",
        "[[<[([]))<([[{}[[()]]]",
        "[{[{({}]{}}([{[{{{}}([]",
        "{<[[]]>}<{[{[{[]{()[[[]",
        "[<(<(<(<{}))><([]([]()",
        "<{([([[(<>()){}]>(<<{{",
        "<{([{{}}[<[[[<>{}]]]>[]]"
    };

    [Test]
    public void Part1_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(_list);

        // Assert
        Assert.AreEqual(26397, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartTwo(_list);

        // Assert
        Assert.AreEqual(288957, result);
    }
}