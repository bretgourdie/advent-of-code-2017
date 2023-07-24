using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using advent_of_code_2017.Common;

namespace advent_of_code_2017.Day22;
internal class Day22 : AdventSolution
{
    private readonly IList<Direction> clockwiseDirections = new List<Direction>()
    {
        Direction.North,
        Direction.East,
        Direction.South,
        Direction.West
    };

    private const string infect = "infect";
    private const string clean = "clean";

    protected override long part1Work(string[] input)
    {
        var infectedPoints = getInfectedGrid(input);
        var virusLocation = findMiddle(input);
        var virusDirection = Direction.North;
        var operations = new Dictionary<string, long>()
        {
            {infect, 0},
            {clean, 0}
        };

        for (int ii = 0; ii < 10_000; ii++)
        {
            var virusOnInfected = infectedPoints.Contains(virusLocation);

            virusDirection = determineDirection(virusDirection, virusOnInfected);
            affectNode(virusLocation, infectedPoints, operations, virusOnInfected);
            virusLocation = moveForward(virusLocation, virusDirection);
        }

        return operations[infect];
    }

    private Point2D findMiddle(IList<string> input) =>
        new Point2D(
            input.First().Length / 2,
            input.First().Length / 2);

    private Point2D moveForward(
        Point2D point,
        Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return new Point2D(point.X, point.Y + 1);
            case Direction.East:
                return new Point2D(point.X + 1, point.Y);
            case Direction.South:
                return new Point2D(point.X, point.Y - 1);
            case Direction.West:
                return new Point2D(point.X - 1, point.Y);
            default:
                throw new ArgumentException(nameof(direction));
        }
    }

    private void affectNode(
        Point2D virusPoint,
        ISet<Point2D> infectedPoints,
        IDictionary<string, long> operations,
        bool isOnInfected)
    {
        if (isOnInfected)
        {
            infectedPoints.Remove(virusPoint);
            operations[clean] += 1;
        }

        else
        {
            infectedPoints.Add(virusPoint);
            operations[infect] += 1;
        }
    }

    private Direction determineDirection(
        Direction virusDirection,
        bool isOnInfectedNode)
    {
        if (isOnInfectedNode)
        {
            return turnRight(virusDirection);
        }

        else
        {
            return turnLeft(virusDirection);
        }
    }

    private Direction turnLeft(Direction direction) =>
        turn(direction, -1);

    private Direction turnRight(Direction direction) =>
        turn(direction, 1);

    private Direction turn(Direction direction, int forward)
    {
        var existingIndex = clockwiseDirections.IndexOf(direction);
        var newIndex = (existingIndex + clockwiseDirections.Count + forward);
        var circledIndex = newIndex % clockwiseDirections.Count;
        return clockwiseDirections[circledIndex];
    }

    private ISet<Point2D> getInfectedGrid(IList<string> input)
    {
        var set = new HashSet<Point2D>();
        var length = input.First().Length;

        for (int y = 0; y < input.Count; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                if (input[y][x] == '#')
                {
                    set.Add(new Point2D(
                        x,
                        length - 1 - y)
                    );
                }
            }
        }

        return set;
    }

    private enum Direction
    {
        North,
        South,
        East,
        West
    }

    protected override long part1ExampleExpected => 5587;
    protected override long part1InputExpected => 5261;
    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }

    protected override long part2ExampleExpected { get; }
    protected override long part2InputExpected { get; }
}
