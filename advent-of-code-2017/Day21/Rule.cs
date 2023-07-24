namespace advent_of_code_2017.Day21;

internal class Rule
{
    public readonly char[,] Input;
    public readonly char[,] Output;

    private static readonly Rotation[] rotations = 
    {
        Rotation.None,
        Rotation.Clockwise90,
        Rotation.Clockwise180,
        Rotation.Clockwise270
    };

    private static readonly Reflection[] reflections =
    {
        Reflection.None,
        Reflection.Horizontal
    };

    private readonly IList<char[,]> permutations;

    public readonly RuleType Type;

    public Rule(string line)
    {
        var split = line.Split(" => ");

        Input = convertTo2DArray(split[0].Split('/'));
        Output = convertTo2DArray(split[1].Split('/'));

        Type = Input.GetLength(0) == 2 ? RuleType.TwosRule : RuleType.ThreesRule;

        permutations = generatePermutations(Input);
    }

    private char[,] convertTo2DArray(IList<string> input)
    {
        var grid = new char[input.Count, input[0].Length];

        for (int y = 0; y < grid.GetLength(0); y++)
        {
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                grid[y, x] = input[y][x];
            }
        }

        return grid;
    }

    public bool Qualifies(char[,] segment) =>
        permutations.Any(x => matches(segment, x));

    private IList<char[,]> generatePermutations(char[,] initial)
    {
        var permutations = new List<char[,]>();
        foreach (var reflection in reflections)
        {

            foreach (var rotation in rotations)
            {
                var permuted = permute(initial, rotation, reflection);
                permutations.Add(permuted);
            }
        }

        return permutations;
    }

    private char[,] permute(
        char[,] initial,
        Rotation rotation,
        Reflection reflection)
    {
        var numberOfRotations = Array.IndexOf(rotations, rotation);
        var result =
            initial.Clone() as char[,] ??
            throw new NullReferenceException(nameof(initial));

        for (int ii = 0; ii < numberOfRotations; ii++)
        {
            result = rotateClockwise(result);
        }

        if (reflection == Reflection.Horizontal)
        {
            result = reflectHorizontal(result);
        }

        return result;
    }

    private char[,] reflectHorizontal(char[,] initial)
    {
        var yLen = initial.GetLength(0);
        var xLen = initial.GetLength(1);
        var result = new char[yLen,xLen];

        for (int y = 0; y < yLen; y++)
        {
            for (int x = 0; x < xLen; x++)
            {
                var xFlipped = xLen - x - 1;
                result[y, x] = initial[y, xFlipped];
            }
        }

        return result;
    }

    private char[,] rotateClockwise(char[,] initial)
    {
        var yLen = initial.GetLength(0);
        var xLen = initial.GetLength(1);
        var result = new char[yLen, xLen];

        for (int row = 0; row < xLen; row++)
        {
            for (int col = 0; col < yLen; col++)
            {
                int newRow = col;
                int newCol = yLen - (row + 1);

                result[newCol, newRow] = initial[col, row];
            }
        }

        return result;
    }

    private bool matches(char[,] segment, char[,] permutation)
    {
        for (int y = 0; y < segment.GetLength(0); y++)
        {
            for (int x = 0; x < segment.GetLength(1); x++)
            {
                if (segment[y, x] != permutation[y, x])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public enum RuleType
    {
        TwosRule,
        ThreesRule
    }

    private enum Rotation
    {
        None,
        Clockwise90,
        Clockwise180,
        Clockwise270
    }

    private enum Reflection
    {
        None,
        Horizontal
    }
}
