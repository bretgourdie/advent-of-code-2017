namespace advent_of_code_2017.Day03
{
    internal class LargerValue : ISolvingStrategy
    {
        public int AddToCurrent(Point2D previousPoint, Point2D placingPoint, IDictionary<Point2D, int> grid)
        {
            var sum = 0;

            for (int x = placingPoint.X - 1; x <= placingPoint.X + 1; x++)
            {
                for (int y = placingPoint.Y - 1; y <= placingPoint.Y + 1; y++)
                {
                    var checkPoint = new Point2D(x, y);

                    if (grid.ContainsKey(checkPoint))
                    {
                        sum += grid[checkPoint];
                    }
                }
            }

            return sum;
        }

        public int GetValue(Point2D lastPoint, IDictionary<Point2D, int> grid) => grid[lastPoint];

        public bool IsFinished(int current, int target) => current > target;
    }
}
