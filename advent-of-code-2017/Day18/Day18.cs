namespace advent_of_code_2017.Day18;
internal class Day18 : AdventSolution
{
    protected override long part1Work(string[] input)
    {
        return new SoundAndRecover().Play(input);
    }

    protected override long part1ExampleExpected => 4;

    protected override long part1InputExpected => 7071;

    protected override long part2Work(string[] input)
    {
        return new SendAndReceive().Play(input);
    }

    protected override long part2ExampleExpected => 1;

    protected override long part2InputExpected => 8001;
}
