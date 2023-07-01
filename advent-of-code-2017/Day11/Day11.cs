namespace advent_of_code_2017.Day11;
internal class Day11 : AdventSolution
{
    protected override long part1ExampleExpected => 3;

    protected override long part1InputExpected => 759;

    protected override long part2ExampleExpected => 3;

    protected override long part2InputExpected => 1501;

    private long work(string[] input, Func<long, long, long> returnStrategy)
    {
        var instructions = input.Single().Split(',');

        return new HexNavigation().Navigate(instructions, returnStrategy);
    }

    protected override long part1Work(string[] input) => work(input, takeEndingDistance);

    protected override long part2Work(string[] input) => work(input, takeMaxDistance);

    private long takeEndingDistance(long end, long max) => end;

    private long takeMaxDistance(long end, long max) => max;
}
