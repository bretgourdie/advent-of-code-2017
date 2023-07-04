using advent_of_code_2017.Common;
using System.Text;

namespace advent_of_code_2017.Day14;
internal class Day14 : AdventSolution
{
    protected override long part1ExampleExpected => 8108;

    protected override long part1InputExpected => 8230;

    protected override long part2ExampleExpected => throw new NotImplementedException();

    protected override long part2InputExpected => throw new NotImplementedException();

    protected override long part1Work(string[] input)
    {
        var line = input.Single();
        const int gridRows = 128;
        var knotHash = new KnotHash();

        var usedSquares = 0;

        for (int ii = 0; ii < gridRows; ii++)
        {
            var row = line + "-" + ii.ToString();

            var hash = knotHash.Hash(row);

            var binary = getBinaryString(hash);

            var binaryLength = binary.Length;

            usedSquares += binary.Count(x => x == '1');
        }

        return usedSquares;
    }

    private string getBinaryString(string hexString)
    {
        var sb = new StringBuilder();

        foreach (var hexLetter in hexString)
        {
            var integer = Convert.ToInt32(hexLetter.ToString(), 16);

            var binaryLetters = Convert.ToString(integer, 2).PadLeft(4, '0');

            sb.Append(binaryLetters);
        }

        return sb.ToString();
    }

    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }
}
