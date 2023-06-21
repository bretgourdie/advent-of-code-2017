namespace advent_of_code_2017.Day03;

internal class Day03 : AdventSolution
{
    protected override long part1ExampleExpected => 31;

    protected override long part1InputExpected => 419;

    protected override long part2ExampleExpected => 1968;

    protected override long part2InputExpected => 295229;

    protected override long part1Work(string[] input)
    {
        return new Grid().Generate(int.Parse(input.First()), new ManhattanDistance());
    }

    protected override long part2Work(string[] input)
    {
        return new Grid().Generate(int.Parse(input.First()), new LargerValue());
    }
}
