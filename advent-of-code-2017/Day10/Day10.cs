using advent_of_code_2017.Common;

namespace advent_of_code_2017.Day10;
internal class Day10 : AdventSolutionTemplate<long, string>
{
    protected override long part1ExampleExpected => 12;

    protected override long part1InputExpected => 19591;

    protected override string part2ExampleExpected => "4a19451b02fb05416d73aea0ec8c00c0";

    protected override string part2InputExpected => "62e2204d2ca4f4924f6e7a80f1288786";

    protected override long part1Work(string[] input)
    {
        var line = input.Single();

        int length;
        if (line.Count(x => x == ',') + 1 <= 4)
            length = 5;
        else
            length = 256;

        return new KnotHash().PracticeHash(length, line);
    }

    protected override string part2Work(string[] input)
    {
        return new KnotHash().Hash(input.Single());
    }
}
