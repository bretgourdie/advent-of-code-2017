using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2017.Day10;
internal class Day10 : AdventSolutionTemplate<long, string>
{
    protected override long part1ExampleExpected => 12;

    protected override long part1InputExpected => 19591;

    protected override string part2ExampleExpected => throw new NotImplementedException();

    protected override string part2InputExpected => "62e2204d2ca4f4924f6e7a80f1288786";

    protected override long part1Work(string[] input)
    {
        var line = input.Single();

        int length;
        if (line.Count(x => x == ',') + 1 <= 4)
            length = 5;
        else
            length = 256;

        return new KnotHash().Hash(line, length);
    }

    protected override string part2Work(string[] input)
    {
        throw new NotImplementedException();
    }
}
