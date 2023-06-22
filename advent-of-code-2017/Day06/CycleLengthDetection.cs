namespace advent_of_code_2017.Day06;
internal class CycleLengthDetection : IReallocationTerminationStrategy
{
    private ISet<string> configurations = new HashSet<string>();
    private ISet<string> infiniteLoopConfigurations = new HashSet<string>();

    private bool isInInfiniteLoop;

    public void Add(string configuration)
    {
        if (isInInfiniteLoop)
        {
            infiniteLoopConfigurations.Add(configuration);
        }

        else
        {
            configurations.Add(configuration);
        }
    }

    public long GetSteps()
    {
        return infiniteLoopConfigurations.Count;
    }

    public bool IsDone(string configuration)
    {
        isInInfiniteLoop |= configurations.Contains(configuration);

        return infiniteLoopConfigurations.Contains(configuration);
    }
}
