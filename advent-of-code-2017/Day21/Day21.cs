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

    protected override long part1Work(string[] input) =>
        work(input, getNumberOfIterations(input, 5));

    private long work(
        string[] input,
        int numberOfIterations)
    {
        var shape = startingShape;

        var rules = generateRules(input);

        var twosRules = rules.Where(x => x.Type == Rule.RuleType.TwosRule).ToList();
        var threesRules = rules.Where(x => x.Type == Rule.RuleType.ThreesRule).ToList();

        for (int ii = 0; ii < numberOfIterations; ii++)
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

    private int getNumberOfIterations(IList<string> input, int inputNumber)
    {
        if (input.Count == 2)
        {
            return 2;
        }

        return inputNumber;
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
        IList<Rule> twosRules) => transform(shape, twosRules, 3, 2);

    private char[,] transformByThrees(
        char[,] shape,
        IList<Rule> threesRules) => transform(shape, threesRules, 4, 3);

    private char[,] transform(
        char[,] shape,
        IList<Rule> rules,
        int newSubdivisionLength,
        int oldSubdivisionLength)
    {
        var yLen = shape.GetLength(0);
        var xLen = shape.GetLength(1);

        var yExpanding = yLen / oldSubdivisionLength;
        var xExpanding = xLen / oldSubdivisionLength;

        char[,] newShape = new char[yLen + yExpanding, xLen + xExpanding];

        for (int y = 0; y < yExpanding; y++)
        {
            for (int x = 0; x < xExpanding; x++)
            {
                var slice = getSlice(
                    shape,
                    x * oldSubdivisionLength,
                    y * oldSubdivisionLength,
                    oldSubdivisionLength);

                var rule = rules.Single(x => x.Qualifies(slice));

                addSlice(
                    rule.Output,
                    newShape,
                    x * newSubdivisionLength,
                    y * newSubdivisionLength);
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
        var yLen = slice.GetLength(0);
        var xLen = slice.GetLength(1);

        for (int ii = 0; ii < yLen; ii++)
        {
            for (int jj = 0; jj < xLen; jj++)
            {
                target[ii + y, jj + x] = slice[ii, jj];
            }
        }
    }

    private char[,] getSlice(
        char[,] shape,
        int x,
        int y,
        int length)
    {
        var slice = new char[length, length];

        for (int ii = 0; ii < length; ii++)
        {
            for (int jj = 0; jj < length; jj++)
            {
                slice[ii, jj] = shape[y + ii, x + jj];
            }
        }

        return slice;
    }

    protected override long part1ExampleExpected => 12;
    protected override long part1InputExpected => 144;

    protected override long part2Work(string[] input) =>
        work(input, getNumberOfIterations(input, 18));

    protected override long part2ExampleExpected => 12;
    protected override long part2InputExpected => 2169301;
}
