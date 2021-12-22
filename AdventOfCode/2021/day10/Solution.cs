namespace AdventOfCode._2021.day10;

public class Solution : IAoCSolution
{
    public List<string> ParseInputFile(StreamReader fs)
    {
        var input = new List<string>();
        while (!fs.EndOfStream) input.Add(fs.ReadLine() ?? throw new InvalidOperationException());
        return input;
    }

    public int PartOne(List<string> input)
    {
        var list = new List<char>();

        foreach (var line in input)
        {
            var array = line.ToCharArray();
            var stack = new Stack<char>();

            foreach (var c in array)
            {
                if (c is '{' or '(' or '[' or '<')
                {
                    stack.Push(c);
                }
                else
                {
                    if (!stack.Any() || stack.Pop() != ToStart(c))
                    {
                        list.Add(c);
                        break;
                    }
                }
            }
        }
        
        return list.Select(ToPoints).Sum();
    }


    private int ToPoints(char c)
    {
        return c switch
        {
            '}' => 1197,
            ')' => 3,
            ']' => 57,
            '>' => 25137,
            _ => 0
        };
    } 

    private char ToStart(char c)
    {
        return c switch
        {
            '}' => '{',
            ')' => '(',
            ']' => '[',
            '>' => '<',
            _ => c
        };
    }
    
    
    private int ToPart2Points(char c)
    {
        return c switch
        {
            '{' => 3,
            '(' => 1,
            '[' => 2,
            '<' => 4,
            _ => 0
        };
    } 

    public long PartTwo(List<string> input)
    {
        var list = new List<long>();

        foreach (var line in input)
        {
            var array = line.ToCharArray();
            var stack = new Stack<char>();
            var illegal = false;

            foreach (var c in array)
            {
                if (c is '{' or '(' or '[' or '<')
                {
                    stack.Push(c);
                }
                else
                {
                    if (!stack.Any() || stack.Pop() != ToStart(c))
                    {
                        illegal = true;
                        break;
                    }
                }
            }
            if (illegal) continue;

            var score = 0L;
            while (stack.Any())
            {
                score *= 5;
                score += ToPart2Points(stack.Pop());
            }
            list.Add(score);
        }

        list.Sort();

        return list[list.Count / 2];
    }
}