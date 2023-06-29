namespace advent_of_code_2017.Day08;
internal class Day08 : AdventSolution
{
    protected override long part1ExampleExpected => 1;

    protected override long part1InputExpected => 3089;

    protected override long part2ExampleExpected => throw new NotImplementedException();

    protected override long part2InputExpected => throw new NotImplementedException();

    protected override long part1Work(string[] input)
    {
        var registers = new Dictionary<string, long>();

        foreach (var line in input)
        {
            var instruction = new Instruction(line);
            instruction.Affect(registers);
        }

        return registers.Values.Max();
    }

    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }
}
