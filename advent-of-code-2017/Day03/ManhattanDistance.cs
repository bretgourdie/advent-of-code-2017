namespace advent_of_code_2017.Day03;

internal class ManhattanDistance : ISolvingStrategy
{
    public int AddToCurrent(Point2D previousPoint, Point2D placingPoint, IDictionary<Point2D, int> grid) => grid[previousPoint] + 1;

    public int GetValue(Point2D lastPoint, IDictionary<Point2D, int> grid) =>
        Math.Abs(lastPoint.X)
        + Math.Abs(lastPoint.Y);

    public bool IsFinished(int current, int target) => current >= target;
}
