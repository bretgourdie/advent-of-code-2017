using System.Text;

namespace advent_of_code_2017.Day19;
internal class Day19 : AdventSolutionTemplate<string, long>
{
    protected override string part1Work(string[] input) =>
        new Packet().Traverse(input).Letters;

    protected override string part1ExampleExpected => "ABCDEF";
    protected override string part1InputExpected => "RYLONKEWB";

    protected override long part2Work(string[] input) =>
        work(input).Steps;

    private TraverseResult work(string[] input) =>
        new Packet().Traverse(input);

    protected override long part2ExampleExpected => 38;
    protected override long part2InputExpected => 16016;
}
