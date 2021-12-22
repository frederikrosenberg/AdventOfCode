namespace AdventOfCode._2021.day4;

public record BoardIndex(int Board, int Index);

public record Bingo(List<int> Numbers, Dictionary<int, List<BoardIndex>> BoardMap, List<int[]> Boards);

public class Solution : IAoCSolution<Bingo>
{
    private const int Width = 5;
    private const int Height = 5;


    public Bingo ParseInputFile(StreamReader fs)
    {
        var numbers = fs.ReadLine()!.Split(",").Select(int.Parse).ToList();
        fs.ReadLine();
        var boardMap = new Dictionary<int, List<BoardIndex>>();
        var boards = new List<int[]>();
        var numberOfBoards = 0;
        var index = 0;
        var currentBoard = new int[Width * Height];
        while (!fs.EndOfStream)
        {
            var line = fs.ReadLine()!;
            if (string.IsNullOrWhiteSpace(line))
            {
                numberOfBoards++;
                index = 0;
                boards.Add(currentBoard);
                currentBoard = new int[Width * Height];
                continue;
            }

            var row = line.Split(" ").Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse);

            foreach (var num in row)
            {
                currentBoard[index] = num;
                if (!boardMap.TryGetValue(num, out var list))
                {
                    list = new List<BoardIndex>();
                    boardMap.Add(num, list);
                }

                list.Add(new BoardIndex(numberOfBoards, index++));
            }
        }

        boards.Add(currentBoard);
        return new Bingo(numbers, boardMap, boards);
    }

    public int PartOne(Bingo input)
    {
        var boolBoards = input.Boards.Select(_ => new bool[Width * Height]).ToList();
        var result = 0;

        foreach (var number in input.Numbers)
        {
            if (!input.BoardMap.TryGetValue(number, out var indexes))
                throw new InvalidOperationException("Missing " + number);

            foreach (var boardIndex in indexes) boolBoards[boardIndex.Board][boardIndex.Index] = true;

            var check = boolBoards.Select(CheckBoard).ToList();
            var index = check.IndexOf(true);
            if (index != -1)
            {
                var board = input.Boards[index];
                var boolBoard = boolBoards[index];
                var sum = board.Where((_, i) => !boolBoard[i]).Sum();

                result = sum * number;
                break;
            }
        }

        return result;
    }

    public int PartTwo(Bingo input)
    {
        var boolBoards = input.Boards.Select(_ => new bool[Width * Height]).ToList();
        var result = 0;
        var lastToWin = -1;

        foreach (var number in input.Numbers)
        {
            if (!input.BoardMap.TryGetValue(number, out var indexes))
                throw new InvalidOperationException("Missing " + number);

            foreach (var boardIndex in indexes) boolBoards[boardIndex.Board][boardIndex.Index] = true;

            var check = boolBoards.Select(CheckBoard).ToList();
            var count = check.Count(c => !c);
            if (count == 1)
            {
                lastToWin = check.IndexOf(false);
                continue;
            }

            if (check.All(c => c))
            {
                var board = input.Boards[lastToWin];
                var boolBoard = boolBoards[lastToWin];
                var sum = board.Where((_, i) => !boolBoard[i]).Sum();

                result = sum * number;
                break;
            }
        }

        return result;
    }

    private bool CheckBoard(bool[] board)
    {
        for (var i = 0; i < Height; i++)
            if (board.Skip(i * Width).Take(Width).All(b => b))
                return true;

        for (var i = 0; i < Width; i++)
            if (board.Where((_, index) => index % Height == i).All(b => b))
                return true;

        return false;
    }
}