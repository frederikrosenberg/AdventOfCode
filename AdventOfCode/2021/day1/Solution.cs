namespace AdventOfCode._2021.day1;

public class Solution : IAoCSolution<List<int>>
{
    public List<int> ParseInputFile(StreamReader fs)
    {
        var input = new List<int>();
        while (!fs.EndOfStream) input.Add(int.Parse(fs.ReadLine() ?? throw new InvalidOperationException()));

        return input;
    }

    public int PartOne(List<int> input)
    {
        var result = 0;
        var last = input.First();
        foreach (var i in input.Skip(1))
        {
            if (last < i) result++;

            last = i;
        }

        return result;
    }

    public int PartTwo(List<int> input)
    {
        // Notes this includes more sums that it should however these are comprised of two or one number therefore is always lower.
        var sums = input.Select((t, i) => input.Skip(i).Take(3).Sum()).ToList();
        return PartOne(sums);
    }
}