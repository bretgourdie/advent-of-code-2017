namespace advent_of_code_2017.Day19;
internal struct TraverseResult
{
    public readonly string Letters;
    public readonly int Steps;

    public TraverseResult(
        string letters,
        int steps)
    {
        Letters = new string(letters);
        Steps = steps;
    }
}
