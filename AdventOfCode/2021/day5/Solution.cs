namespace AdventOfCode._2021.day5;

public record Point(int X, int Y);

public record Line(Point Start, Point End)
{
    public override string ToString()
    {
        return $"({Start.X},{Start.Y}) -> ({End.X}, {End.Y})";
    }
}

public class Solution : IAoCSolution<List<Line>>
{
    private const int Width = 1000;
    private const int Height = 1000;

    public List<Line> ParseInputFile(StreamReader fs)
    {
        var input = new List<Line>();
        while (!fs.EndOfStream)
        {
            var points = fs.ReadLine()!.Split(" -> ").Select(s => s.Split(",")).SelectMany(s => s).Select(int.Parse)
                .ToArray();
            input.Add(new Line(new Point(points[0], points[1]), new Point(points[2], points[3])));
        }

        return input;
    }

    public int PartOne(List<Line> input)
    {
        return CreateBoard(input).Count(n => n > 1);
    }

    public int PartTwo(List<Line> input)
    {
        return CreateBoard(input, true).Count(c => c > 1);
    }

    private int[] CreateBoard(List<Line> input, bool diagonal = false)
    {
        var board = new int[Width * Height];
        foreach (var (start, end) in input)
            if (start.X == end.X)
            {
                var yStart = start.Y;
                if (start.Y > end.Y) yStart = end.Y;

                for (var i = 0; i <= Math.Abs(start.Y - end.Y); i++) board[ToIndex(start.X, i + yStart)] += 1;
            }
            else if (start.Y == end.Y)
            {
                var xStart = start.X;
                if (start.X > end.X) xStart = end.X;

                for (var i = 0; i <= Math.Abs(start.X - end.X); i++) board[ToIndex(i + xStart, start.Y)] += 1;
            }
            else if (diagonal)
            {
                var xStep = start.X > end.X ? -1 : 1;
                var yStep = start.Y > end.Y ? -1 : 1;
                var xStart = start.X;
                var yStart = start.Y;

                for (var i = 0; i <= Math.Abs(start.X - end.X); i++)
                    board[ToIndex(i * xStep + xStart, i * yStep + yStart)] += 1;
            }

        return board;
    }

    private int ToIndex(int x, int y)
    {
        return y * Width + x;
    }


    private void PrintBoard(int[] board)
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var value = board[ToIndex(x, y)];
                Console.Write(value == 0 ? "." : value);
            }

            Console.WriteLine();
        }
    }
}