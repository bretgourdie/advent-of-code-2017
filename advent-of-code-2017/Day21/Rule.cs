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

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < input.Count; x++)
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
        var yLen = initial.GetLength(0);
        var xLen = initial.GetLength(1);

        var numberOfRotations = Array.IndexOf(rotations, rotation);

        char[,] result = initial;
        char[,] toBeTransformed = initial;

        for (int currentRotation = 0; currentRotation < numberOfRotations; currentRotation++)
        {
            result = new char[yLen, xLen];

            for (int y = 0; y < yLen; y++)
            {
                for (int x = 0; x < xLen; x++)
                {
                    result[x, y] = toBeTransformed[y, x];
                }
            }

            for (int y = 0; y < yLen; y++)
            {
                for (int x = 0; x < xLen; x++)
                {
                    result[y, x] = toBeTransformed[yLen - y - 1, xLen - x - 1];
                }
            }

            toBeTransformed = result;
        }

        if (reflection == Reflection.Horizontal)
        {

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
