namespace AdventOfCode._2021.day2;

// ReSharper disable InconsistentNaming
public enum Direction
{
    forward,
    up,
    down
}
// ReSharper enable InconsistentNaming

public record Move(Direction Direction, int Unit);

public class Solution : IAoCSolution<List<Move>>
{
    public List<Move> ParseInputFile(StreamReader fs)
    {
        var input = new List<Move>();
        while (!fs.EndOfStream)
        {
            var line = (fs.ReadLine() ?? throw new InvalidOperationException()).Split(" ");
            if (!Enum.TryParse<Direction>(line[0], out var dir)) throw new InvalidOperationException();
            input.Add(new Move(dir, int.Parse(line[1])));
        }

        return input;
    }

    public int PartOne(List<Move> input)
    {
        var x = 0;
        var depth = 0;

        foreach (var (direction, unit) in input)
            switch (direction)
            {
                case Direction.forward:
                    x += unit;
                    break;
                case Direction.up:
                    depth -= unit;
                    break;
                case Direction.down:
                    depth += unit;
                    break;
            }

        return x * depth;
    }

    public int PartTwo(List<Move> input)
    {
        var x = 0;
        var depth = 0;
        var aim = 0;

        foreach (var (direction, unit) in input)
            switch (direction)
            {
                case Direction.forward:
                    x += unit;
                    depth += aim * unit;
                    break;
                case Direction.up:
                    aim -= unit;
                    break;
                case Direction.down:
                    aim += unit;
                    break;
            }

        return x * depth;
    }
}