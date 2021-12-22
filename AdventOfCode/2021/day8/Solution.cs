using System.Collections.Immutable;

namespace AdventOfCode._2021.day8;

public record Display(List<string> Signals, List<string> Values);


public class Solution : IAoCSolution
{
    public List<Display> ParseInputFile(StreamReader fs)
    {
        var input = new List<Display>();
        while (!fs.EndOfStream)
        {
            var line = fs.ReadLine()!.Split(" | ");
            var signals = line[0].Split(" ").Select(Extensions.Sort).ToList();
            var values = line[1].Split(" ").Select(Extensions.Sort).ToList();
            input.Add(new Display(signals, values));
        }

        return input;
    }

    public int PartOne(List<Display> input)
    {
        var count = input.SelectMany(d => d.Values).Count(n =>
        {
            return n.Length switch
            {
                2 => true,
                3 => true,
                4 => true,
                7 => true,
                _ => false
            };
        });
        return count;
    }
    
    public int PartTwo(List<Display> input)
    {
        var sum = 0;

        foreach (var (signals, values) in input)
        {
            string one = string.Empty, four = string.Empty;
            var numbers = new Dictionary<string, int>();

            foreach (var signal in signals)
            {
                switch (signal.Length)
                {
                    case 2:
                        numbers.Add(signal, 1);
                        one = signal;
                        break;
                    case 3:
                        numbers.Add(signal, 7);
                        break;
                    case 4:
                        numbers.Add(signal, 4);
                        four = signal;
                        break;
                    case 7:
                        numbers.Add(signal, 8);
                        break;
                }
            }

            var middleSegments = four.ToCharArray().Except(one.ToCharArray()).ToList();

            foreach (var signal in signals)
            {
                if (signal.Length == 5)
                {
                    if (signal.Contains(one.ToCharArray()))
                    {
                        numbers.Add(signal, 3);
                    } else if (signal.Contains(middleSegments))
                    {
                        numbers.Add(signal, 5);
                    }
                    else
                    {
                        numbers.Add(signal, 2);
                    }
                } else if (signal.Length == 6)
                {
                    if (signal.Contains(four.ToCharArray()))
                    {
                        numbers.Add(signal, 9);
                    }
                    else if (signal.Contains(middleSegments))
                    {
                        numbers.Add(signal, 6);
                    }
                    else
                    {
                        numbers.Add(signal, 0);
                    }
                }
            }
            sum += values.Select(v => numbers[v]).Aggregate((s1, s2) => (s1 * 10) + s2);
        }
        
        
        return sum;
    }
}


public static class Extensions {
    public static bool Contains(this string s, IEnumerable<char> chars)
    {
        return chars.All(s.Contains);
    }
    
    public static string Sort(this string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }
}