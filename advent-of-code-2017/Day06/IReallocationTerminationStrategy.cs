namespace advent_of_code_2017.Day06;
internal interface IReallocationTerminationStrategy
{
    bool IsDone(string configuration);
    void Add(string configuration);
    long GetSteps();
}
