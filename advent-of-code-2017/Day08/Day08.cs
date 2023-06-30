namespace advent_of_code_2017.Day08;
internal class Day08 : AdventSolution
{
    protected override long part1ExampleExpected => 1;

    protected override long part1InputExpected => 3089;

    protected override long part2ExampleExpected => 10;

    protected override long part2InputExpected => 5391;

    private long work(
        string[] input,
        Func<long, long, long> takeStrategy)
    {
        var registers = new Dictionary<string, long>();
        long maxAtAnyPoint = -1;

        foreach (var line in input)
        {
            var instruction = new Instruction(line);
            instruction.Affect(registers);
            maxAtAnyPoint = Math.Max(maxAtAnyPoint, getMaxRegister(registers));
        }

        return takeStrategy(getMaxRegister(registers), maxAtAnyPoint);
    }

    private long getMaxRegister(IDictionary<string, long> registers)
    {
        if (registers.Any())
        {
            return registers.Values.Max();
        }

        else
        {
            return -1;
        }
    }

    private long takeMaxAtEnd(long maxAtEnd, long maxAtAnyPoint) => maxAtEnd;

    private long takeMaxAtAnyPoint(long maxAtEnd, long maxAtAnyPoint) => maxAtAnyPoint;

    protected override long part1Work(string[] input) =>
        work(input, takeMaxAtEnd);

    protected override long part2Work(string[] input) =>
        work(input, takeMaxAtAnyPoint);
}
