namespace advent_of_code_2017.Day05;
internal class Day05 : AdventSolution
{
    protected override long part1ExampleExpected => 5;

    protected override long part1InputExpected => 364539;

    protected override long part2ExampleExpected => 10;

    protected override long part2InputExpected => 27477714;

    protected long work(string[] input, Func<int, int> postHopIncrement)
    {
        
        var instructions = input.Select(x => int.Parse(x)).ToArray();

        int pointer = 0;
        int steps = 0;

        while (pointer >= 0 && pointer < instructions.Length)
        {
            var value = instructions[pointer];
            var fromPointer = pointer;

            pointer += value;

            instructions[fromPointer] += postHopIncrement(instructions[fromPointer]);

            steps += 1;
        }

        return steps;
    }

    private int incrementByOne(int value) => 1;

    private int incrementOrDecrementByOne(int value) => value >= 3 ? -1 : 1;

    protected override long part1Work(string[] input) =>
        work(input, incrementByOne);

    protected override long part2Work(string[] input) =>
        work(input, incrementOrDecrementByOne);
}
