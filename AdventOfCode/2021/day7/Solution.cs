namespace AdventOfCode._2021.day7;

public class Solution : IAoCSolution
{
    public List<int> ParseInputFile(StreamReader fs)
    {
        var input = new List<int>();
        while (!fs.EndOfStream) input.AddRange((fs.ReadLine() ?? throw new InvalidOperationException()).Split(",").Select(int.Parse));

        return input;
    }

    public int PartOne(List<int> input)
    {
        
        return Calc(input, (current, wanted) => Math.Abs(current - wanted));
    }

    private int Calc(List<int> input, Func<int, int, int> step)
    {
        var average = (int) input.Average();
        var min = average - input.Count / 4;
        var max = average + input.Count / 4;
        
        return CreateRange(average, min, max).Select(value => input.Sum(n => step(n, value))).Min();
    }


    private IEnumerable<int> CreateRange(int average, int min, int max)
    {
        var lower = average;
        var larger = average + 1;

        while (lower >= min || larger < max)
        {
            if (lower >= min)
            {
                yield return lower;
                lower--;
            }

            if (larger < max)
            {
                yield return larger;
                larger++;
            }
        }
    }

    public int PartTwo(List<int> input)
    {
        var stepFunction = (int current, int wanted) =>
        {
            var diff = Math.Abs(current - wanted);
            var sum = (diff * (diff + 1)) / 2;
            return sum;
        };
        
        return Calc(input, stepFunction);
    }
}