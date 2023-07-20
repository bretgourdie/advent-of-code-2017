using System.Data;

namespace advent_of_code_2017.Day21;
internal class Day21 : AdventSolution
{
    private const char pixelTurnedOn = '#';

    private readonly char[,] startingShape = new[,]
    {
        {'.', '#', '.'}, 
        {'.', '.', '#'},
        {'#', '#', '#'}
    };

    protected override long part1Work(string[] input)
    {
        var shape = startingShape;

        var rules = generateRules(input);

        var twosRules = rules.Where(x => x.Type == Rule.RuleType.TwosRule).ToList();
        var threesRules = rules.Where(x => x.Type == Rule.RuleType.ThreesRule).ToList();

        for (int ii = 0; ii < 5; ii++)
        {
            var size = shape.GetLength(0);

            if (size % 2 == 0)
            {
                shape = transformByTwos(shape, twosRules);
            }

            else if (size % 3 == 0)
            {
                shape = transformByThrees(shape, threesRules);
            }
        }

        return pixelCount(shape, pixelTurnedOn);
    }

    private long pixelCount(
        char[,] shape,
        char pixel)
    {
        long total = 0;

        for (int ii = 0; ii < shape.GetLength(0); ii++)
        {
            for (int jj = 0; jj < shape.GetLength(1); jj++)
            {
                if (shape[ii,jj] == pixel)
                {
                    total += 1;
                }
            }
        }

        return total;
    }

    private IList<Rule> generateRules(IList<string> input)
    {
        var rules = new List<Rule>();
        foreach (var line in input)
        {
            rules.Add(new Rule(line));
        }

        return rules;
    }

    private char[,] transformByTwos(
        char[,] shape,
        IList<Rule> twosRules) => transform(shape, twosRules, 2);

    private char[,] transformByThrees(
        char[,] shape,
        IList<Rule> threesRules) => transform(shape, threesRules, 3);

    private char[,] transform(
        char[,] shape,
        IList<Rule> rules,
        int subdivisionLength)
    {
        var yLen = shape.GetLength(0);
        var xLen = shape.GetLength(1);

        char[,] newShape = new char[yLen + 1, xLen + 1];

        for (int y = 0; y < shape.GetLength(0) / subdivisionLength; y += subdivisionLength)
        {
            for (int x = 0; x < shape.GetLength(1) / subdivisionLength; x += subdivisionLength)
            {
                char[,] slice = getSlice(shape, x, y, subdivisionLength);
                foreach (var rule in rules)
                {
                    if (rule.Qualifies(slice))
                    {
                        slice = rule.Output;
                    }
                }

                throw new NotImplementedException("have to adjust for x/y offset in new shape");
                addSlice(slice, newShape, x, y);
            }
        }

        return newShape;
    }

    private void addSlice(
        char[,] slice,
        char[,] target,
        int x,
        int y)
    {
        throw new NotImplementedException();
    }

    private char[,] getSlice(
        char[,] shape,
        int x,
        int y,
        int length)
    {
        var slice = new char[length, length];

        for (int ii = y; ii < y + length; ii++)
        {
            for (int jj = x; jj < x + length; jj++)
            {
                slice[ii - y, jj - x] = shape[y, x];
            }
        }

        return slice;
    }

    protected override long part1ExampleExpected => 12;
    protected override long part1InputExpected => -1;
    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }

    protected override long part2ExampleExpected { get; }
    protected override long part2InputExpected { get; }
}
