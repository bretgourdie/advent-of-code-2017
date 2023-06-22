namespace advent_of_code_2017.Day06;
internal class InfiniteLoopDetection : ITerminateStrategy
{
    private readonly ISet<string> configurations = new HashSet<string>();

    public void Add(string configuration)
    {
        configurations.Add(configuration);
    }

    public long GetSteps() => configurations.Count;

    public bool IsDone(string configuration) => configurations.Contains(configuration);
}
