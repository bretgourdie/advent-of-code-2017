using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace advent_of_code_2017.Day19;
internal class Packet
{
    private const char traverseNS = '|';
    private const char traverseEW = '-';
    private const char traverseTurn = '+';
    private const char traverseBlank = ' ';

    private readonly IEnumerable<Direction> NorthSouth = new[]
    {
        Direction.North,
        Direction.South
    };

    private readonly IEnumerable<Direction> EastWest = new[]
    {
        Direction.East,
        Direction.West
    };

    public TraverseResult Traverse(IList<string> map)
    {
        var letters = new StringBuilder();
        var steps = 0;

        Direction currentDirection = Direction.South;

        int y = 0;
        int x = findStart(map);

        while (canTraverse(x, y, currentDirection, map))
        {
            var currentIcon = getMapIcon(x, y, map);

            switch (currentIcon)
            {
                case traverseBlank:
                    throw new InvalidOperationException();
                case traverseTurn:
                    currentDirection = getNewDirection(x, y, currentDirection, map);
                    break;
                case traverseNS:
                case traverseEW:
                    // ignore
                    break;
                default:
                    letters.Append(currentIcon);
                    break;
            }

            x = getX(x, currentDirection);
            y = getY(y, currentDirection);
            steps += 1;
        }

        return new TraverseResult(
            letters.ToString(),
            steps);
    }

    private bool canTraverse(
        int x,
        int y,
        Direction currentDirection,
        IList<string> map)
    {
        return getMapIcon(x, y, map) != traverseBlank;
    }

    private int findStart(IList<string> map) =>
        map.First().IndexOf(traverseNS);

    private Direction getNewDirection(
        int x,
        int y,
        Direction currentDirection,
        IList<string> map)
    {
        foreach (var direction in getChangingDirectionOptions(currentDirection))
        {
            var newX = getX(x, direction);
            var newY = getY(y, direction);
            var newIcon = getMapIcon(newX, newY, map);

            if (newIcon != traverseBlank)
            {
                return direction;
            }
        }

        throw new InvalidOperationException("Cannot use any direction options");
    }

    private IEnumerable<Direction> getChangingDirectionOptions(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
            case Direction.South:
                return EastWest;
            case Direction.West:
            case Direction.East:
                return NorthSouth;
        }

        throw new ArgumentException(nameof(direction));
    }

    private int getX(int x, Direction direction) =>
        getPosition(x, direction, Direction.West, Direction.East);

    private int getY(int y, Direction direction) =>
        getPosition(y, direction, Direction.North, Direction.South);

    private int getPosition(
        int pos,
        Direction toGo,
        Direction subtractor,
        Direction adder)
    {
        if (toGo == subtractor)
        {
            return pos - 1;
        }

        if (toGo == adder)
        {
            return pos + 1;
        }

        return pos;
    }

    private char getMapIcon(int x, int y, IList<string> map) => map[y][x];

    private enum Direction
    {
        North,
        South,
        East,
        West
    }
}
