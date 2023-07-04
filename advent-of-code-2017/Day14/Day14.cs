using advent_of_code_2017.Common;
using System.Text;

namespace advent_of_code_2017.Day14;
internal class Day14 : AdventSolution
{
    const string filledSquare = "#";
    const string unfilledSquare = ".";

    protected override long part1ExampleExpected => 8108;

    protected override long part1InputExpected => 8230;

    protected override long part2ExampleExpected => 1242;

    protected override long part2InputExpected => 1103;

    private IList<IList<string>> getGrid(string[] input)
    {
        var line = input.Single();
        const int gridRows = 128;
        var knotHash = new KnotHash();

        var grid = new string[gridRows][];

        for (int ii = 0; ii < gridRows; ii++)
        {
            var rowToHash = line + "-" + ii.ToString();

            var hash = knotHash.Hash(rowToHash);

            var binary = getBinaryString(hash);

            grid[ii] = binary.Select(x => x.ToString()).ToArray();
        }

        return grid;
    }

    private string getBinaryString(string hexString)
    {
        var sb = new StringBuilder();

        foreach (var hexLetter in hexString)
        {
            var integer = Convert.ToInt32(hexLetter.ToString(), 16);

            var binaryLetters = Convert.ToString(integer, 2).PadLeft(4, '0');

            var binaryReplaced = binaryLetters
                .Replace('1', '#')
                .Replace('0', '.');

            sb.Append(binaryReplaced);
        }

        return sb.ToString();
    }

    private int floodFillGrid(IList<IList<string>> grid)
    {
        int group = 1;

        for (int x = 0; x < grid.Count; x++)
        {
            for (int y = 0; y < grid[x].Count; y++)
            {
                var filled = floodFillSpot(x, y, grid, group);

                if (filled)
                {
                    group += 1;
                }
            }
        }

        return group - 1;
    }

    private bool floodFillSpot(
        int x,
        int y,
        IList<IList<string>> grid,
        int group)
    {
        if (x < 0 || x >= grid.Count
            || y < 0 || y >= grid[x].Count)
        {
            return false;
        }

        if (grid[x][y] == filledSquare)
        {
            grid[x][y] = group.ToString();

            floodFillSpot(x - 1, y, grid, group);
            floodFillSpot(x + 1, y, grid, group);
            floodFillSpot(x, y - 1, grid, group);
            floodFillSpot(x, y + 1, grid, group);

            return true;
        }

        else
        {
            return false;
        }
    }

    protected override long part1Work(string[] input) =>
        getGrid(input)
        .SelectMany(x => x)
        .Count(x => x == "#");

    protected override long part2Work(string[] input) =>
        floodFillGrid(getGrid(input));
}
