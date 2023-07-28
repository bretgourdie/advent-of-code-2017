namespace advent_of_code_2017.Day25;
internal class Day25 : AdventSolution
{
    protected override long part1Work(string[] input)
    {
        var turingMachine = new TuringMachine(input);

        return turingMachine.GetChecksum();
    }

    protected override long part1ExampleExpected => 3;
    protected override long part1InputExpected => 2526;
    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }

    protected override long part2ExampleExpected { get; }
    protected override long part2InputExpected { get; }
}
