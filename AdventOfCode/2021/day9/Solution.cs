namespace AdventOfCode._2021.day9;

public record HeightMap(int[] Map, int Width, int Height);


public class Solution : IAoCSolution
{
    public HeightMap ParseInputFile(StreamReader fs)
    {
        var input = new List<int>();
        var height = 0;
        var width = 0;
        while (!fs.EndOfStream)
        {
            var row = (fs.ReadLine() ?? throw new InvalidOperationException()).ToCharArray().Select(c => c - '0').ToList();
            input.AddRange(row);
            width = row.Count();
            height++;
        }

        return new HeightMap(input.ToArray(), width, height);
    }

    public int PartOne(HeightMap input)
    {
        var lowPoints = FindLowPoints(input);

        return lowPoints.Select(l => input.Map[l] + 1).Sum();
    }

    private static IEnumerable<int> FindLowPoints(HeightMap input)
    {
        var result = new List<int>();
        var map = input.Map;
        Console.WriteLine($"{input.Width} x {input.Height}");

        for (var i = 0; i < map.Length; i++)
        {
            if (i > 0 && i % input.Width != 0 && map[i - 1] <= map[i]) continue;
            if (i < map.Length - 1 && (i + 1) % input.Width != 0 && map[i] >= map[i + 1]) continue;
            if (i - input.Width >= 0 && map[i - input.Width] <= map[i]) continue;
            if (i + input.Width <= map.Length - 1 && map[i] >= map[i + input.Width]) continue;
            // Low point
            result.Add(i);
        }

        return result;
    }

    public int PartTwo(HeightMap input)
    {
        var lowPoints = FindLowPoints(input);
        var map = input.Map;

        var sizes = new List<int>();

        foreach (var point in lowPoints)
        {
            var set = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(point);
            var size = 0;

            while (queue.Any())
            {
                var i = queue.Dequeue();
                if (set.Contains(i)) continue;
                if (i > 0 && i % input.Width != 0 && map[i - 1] != 9) queue.Enqueue(i - 1);
                if (i < map.Length - 1 && (i + 1) % input.Width != 0 && map[i + 1] != 9) queue.Enqueue(i + 1);
                if (i - input.Width >= 0 && map[i - input.Width] != 9 ) queue.Enqueue(i - input.Width);
                if (i + input.Width <= map.Length - 1 && map[i + input.Width] != 9) queue.Enqueue(i + input.Width);
                set.Add(i);
                size++;
            }
            sizes.Add(size);
        }

        return sizes.OrderByDescending(i => i).Take(3).Aggregate((i, i1) => i * i1);
    }
}