namespace AdventOfCode._2021.day3;

public class Solution : IAoCSolution<List<int>>
{
    private readonly int _numberLenght;

    public Solution(int numberLenght = 12)
    {
        _numberLenght = numberLenght;
    }


    public List<int> ParseInputFile(StreamReader fs)
    {
        var input = new List<int>();
        while (!fs.EndOfStream) input.Add(Convert.ToInt32(fs.ReadLine() ?? throw new InvalidOperationException(), 2));
        return input;
    }

    public int PartOne(List<int> input)
    {
        var counters = FindMostCommonBit(input);
        var gamma = 0;
        for (var index = 0; index < counters.Length; index++) gamma |= counters[index] << index;

        var epsilon = gamma ^ ((1 << _numberLenght) - 1);
        return gamma * epsilon;
    }

    public int PartTwo(List<int> input)
    {
        var oxygen = new List<int>(input);
        var co2 = new List<int>(input);

        var index = _numberLenght - 1;
        while (oxygen.Count > 1)
        {
            var bits = FindMostCommonBit(oxygen);
            oxygen = oxygen.Where(n => ((n >> index) & 1) == bits[index]).ToList();

            index--;
        }

        index = _numberLenght - 1;
        while (co2.Count > 1)
        {
            var bits = FindMostCommonBit(co2);
            co2 = co2.Where(n => ((n >> index) & 1) != bits[index]).ToList();

            index--;
        }

        return oxygen.First() * co2.First();
    }

    private int[] FindMostCommonBit(List<int> numbers)
    {
        var counters = new int[_numberLenght];

        foreach (var number in numbers)
        {
            var shifted = number;
            for (var i = 0; i < counters.Length; i++)
            {
                counters[i] += (shifted & 1) == 1 ? 1 : -1;
                shifted >>= 1;
            }
        }

        return counters.Select(c => c >= 0 ? 1 : 0).ToArray();
    }
}