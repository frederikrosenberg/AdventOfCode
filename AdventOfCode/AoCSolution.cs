namespace AdventOfCode;

public interface IAoCSolution
{
}

public interface IAoCSolution<T> : IAoCSolution
{
    T ParseInputFile(StreamReader fs);


    int PartOne(T input);
    int PartTwo(T input);
}