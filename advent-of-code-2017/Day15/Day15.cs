namespace advent_of_code_2017.Day15;
internal class Day15 : AdventSolution
{
    protected override long part1ExampleExpected => 588;

    protected override long part1InputExpected => 594;

    protected override long part2ExampleExpected => throw new NotImplementedException();

    protected override long part2InputExpected => throw new NotImplementedException();

    protected override long part1Work(string[] input)
    {
        var lower16Bits = 0b1111_1111_1111_1111;

        var a = new Generator(input.First());
        var b = new Generator(input.Skip(1).First());

        long matches = 0;

        for (int ii = 0; ii < 40_000_000; ii++)
        {
            var aValue = a.Generate();
            var bValue = b.Generate();

            if ((aValue & lower16Bits) == (bValue & lower16Bits))
            {
                matches += 1;
            }
        }

        return matches;
    }

    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }
}
