namespace advent_of_code_2017.Day15;
internal class Day15 : AdventSolution
{
    protected override long part1ExampleExpected => 588;

    protected override long part1InputExpected => 594;

    protected override long part2ExampleExpected => 309;

    protected override long part2InputExpected => 328;

    private long work(string[] input, bool useConditionals)
    {
        var a = new Generator(input.First(), useConditionals);
        var b = new Generator(input.Skip(1).First(), useConditionals);

        long matches = 0;

        for (int ii = 0; ii < numberOfPairsToCheck(useConditionals); ii++)
        {
            var aValue = a.Generate();
            var bValue = b.Generate();

            if (getLower16Bits(aValue) == getLower16Bits(bValue))
            {
                matches += 1;
            }
        }

        return matches;
    }

    private long getLower16Bits(long value) =>
        value & 0b1111_1111_1111_1111;

    private long numberOfPairsToCheck(bool useConditionals) =>
        useConditionals
            ? 5_000_000
            : 40_000_000;

    protected override long part1Work(string[] input) =>
        work(input, useConditionals: false);

    protected override long part2Work(string[] input) =>
        work(input, useConditionals: true);
}
