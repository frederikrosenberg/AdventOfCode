using System.Reflection;
using AdventOfCode;

Console.WriteLine("Advent of Code 2021");

Console.WriteLine("Please Enter day:");

var day = "day10";//Console.ReadLine();
if (string.IsNullOrEmpty(day))
{
    Console.WriteLine("Invalid day");
    return;
}


var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && t.IsAssignableTo(typeof(IAoCSolution)));

var solutionType = types.FirstOrDefault(c => c.FullName!.Contains(day));
if (solutionType == null)
{
    Console.WriteLine($"No solution for {day}");
    return;
}

var instance = Activator.CreateInstance(solutionType)!;
var parse = solutionType.GetMethod("ParseInputFile")!;
var part1 = solutionType.GetMethod("PartOne")!;
var part2 = solutionType.GetMethod("PartTwo")!;

using var file = new StreamReader(Directory.GetCurrentDirectory() + $"/2021/{day}/input.txt");
var input = parse.Invoke(instance, new object?[] {file})!;
var p1 = part1.Invoke(instance, new[] {input})!;
var p2 = part2.Invoke(instance, new[] {input})!;
Console.WriteLine("Part 1: " + p1);
Console.WriteLine("Part 2: " + p2);