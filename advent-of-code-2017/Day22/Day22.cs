namespace advent_of_code_2017.Day22;
internal class Day22 : AdventSolution
{
    private long work(
        string[] input,
        VirusStrategy strategy)
    {
        var virusLocation = findMiddle(input);
        var virusDirection = Direction.North;

        for (int ii = 0; ii < strategy.NumberOfIterations; ii++)
        {
            virusDirection = strategy.DetermineDirection(virusLocation, virusDirection);
            strategy.AffectNode(virusLocation);
            virusLocation = moveForward(virusLocation, virusDirection);
        }

        return strategy.NumberOfInfections;
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
                    var yInverted = length - 1 - y;
                    set.Add(new Point2D(
                        x,
                        yInverted)
                    );
                }
            }
        }

        return set;
    }

    protected override long part1Work(string[] input) =>
        work(input, new PreEvolution(getInfectedGrid(input)));

    protected override long part1ExampleExpected => 5587;
    protected override long part1InputExpected => 5261;

    protected override long part2Work(string[] input) =>
        work(input, new Evolved(getInfectedGrid(input)));

    protected override long part2ExampleExpected => 2511944;
    protected override long part2InputExpected => 2511927;
}
