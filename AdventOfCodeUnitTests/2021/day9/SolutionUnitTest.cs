using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode._2021.day9;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AdventOfCodeUnitTests._2021.day9;

public class SolutionUnitTest
{
    private static readonly List<string> FileList = new()
        {"2199943210", "3987894921", "9856789892", "8767896789", "9899965678"};

    private static readonly List<int> List = new()
    {
        2, 1, 9, 9, 9, 4, 3, 2, 1, 0, 3, 9, 8, 7, 8, 9, 4, 9, 2, 1, 9, 8, 5, 6, 7, 8, 9, 8, 9, 2, 8, 7, 6, 7, 8, 9, 6,
        7, 8, 9, 9, 8, 9, 9, 9, 6, 5, 6, 7, 8
    };

    private static readonly HeightMap Map = new(List.ToArray(), 10, 5);


    [Test]
    public void ParseFile_pareses_correct()
    {
        // Arrange
        var solution = new Solution();
        var bytes = Encoding.ASCII.GetBytes(FileList.Aggregate((s, c) => s + "\n" + c));
        var memoryStream = new MemoryStream(bytes);
        using var reader = new StreamReader(memoryStream);

        // Act
        var result = solution.ParseInputFile(reader);

        // Assert
        Assert.That(result.Map, Is.EquivalentTo(Map.Map));
        Assert.That(result.Width, Is.EqualTo(Map.Width));
        Assert.That(result.Height, Is.EqualTo(Map.Height));
    }


    [Test]
    public void Part1_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(Map);

        // Assert
        Assert.AreEqual(15, result);
    }
    
    [Test]
    public void Part1_solves_correct_low_points()
    {
        var map = new HeightMap(new[] 
            {
                0, 0, 0, 
                0, 0, 0, 
                0, 0, 0, 
            }, 3, 3);
        
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(map);

        // Assert
        Assert.AreEqual(0, result);
    }
    
    [Test]
    public void Part1_solves_correct_points()
    {
        var map = new HeightMap(new[]
        {
            9, 5, 4, 9,
            5, 9, 9, 5,
            4, 9, 9, 4,
            9, 5, 4, 9
        }, 4, 4);
        
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(map);

        // Assert
        Assert.AreEqual(20, result);
    }
    
    [Test]
    public void Part1_solves_correct_points1()
    {
        var map = new HeightMap(new[]
        {
            9, 9, 9, 9, 9,
            4, 9, 9, 9, 5,
            9, 9, 9, 9, 9,
            4, 9, 9, 9, 5,
            9, 9, 9, 9, 9
        }, 5, 5);
        
        // 4 5 4 5
        
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(map);

        // Assert
        Assert.AreEqual(22, result);
    }
    
    [Test]
    public void Part1_solves_correct_points2()
    {
        var map = new HeightMap(new[]
        {
            1, 1, 3,
            2, 4, 1
        }, 3, 2);
        
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(map);

        // Assert
        Assert.AreEqual(2, result);
    }
    
    [Test]
    public void Part1_solves_correct_points3()
    {
        var map = new HeightMap(new[]
        {
            5, 5, 5,
            5, 5, 1,
            5, 5, 0
        }, 3, 3);
        
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(map);

        // Assert
        Assert.AreEqual(1, result);
    }
    
    [Test]
    public void Part1_solves_correct_edges_left()
    {
        var map = new HeightMap(new[] 
            {
                1, 2, 1, 
                2, 3, 2, 
                3, 3, 1, 
                2, 3, 3
            }, 3, 4);

        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(map);

        // Assert
        Assert.AreEqual(9, result);
    }
    
    [Test]
    public void Part1_solves_correct_edges_right()
    {
        var map = new HeightMap(new[] 
            {
                1, 2, 1, 
                2, 3, 2, 
                1, 3, 3, 
                3, 3, 2,
                1, 3, 3
            }, 3, 5);

        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartOne(map);

        // Assert
        Assert.AreEqual(11, result);
    }

    [Test]
    public void Part2_solves_example_correct()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.PartTwo(Map);

        // Assert
        Assert.AreEqual(1134, result);
    }
}