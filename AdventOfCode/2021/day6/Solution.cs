namespace AdventOfCode._2021.day6;

public class Solution : IAoCSolution
{
    public List<int> ParseInputFile(StreamReader fs)
    {
        var input = new List<int>();
        while (!fs.EndOfStream) input.AddRange((fs.ReadLine() ?? throw new InvalidOperationException()).Split(",").Select(int.Parse));

        return input;
    }

    public long PartOne(List<int> input)
    {
        return Calc(input, 80);
    }

    private long Calc(List<int> input, int days)
    {
        var world = new long[9];
        foreach (var i in input)
        {
            world[i]++;
        }

        for (var i = 0; i < days; i++)
        {
            var toAdd = world[0];
            for (var j = 1; j < world.Length; j++)
            {
                world[j - 1] = world[j];
            }

            world[6] += toAdd;
            world[8] = toAdd;
        }

        return world.Sum();
    }

    public long PartTwo(List<int> input)
    {
        return Calc(input, 256);
    }
}