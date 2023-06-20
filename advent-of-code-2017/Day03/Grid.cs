namespace advent_of_code_2017.Day03
{
    internal class Grid
    {
        public long Generate(int target, Func<int, int> getNext)
        {
            IDictionary<Point2D, int> grid = new Dictionary<Point2D, int>();

            int x = 0;
            int y = 0;
            int current = 1;
            int moves = 0;

            while (current != target)
            {
                current = getNext(current);

                x = goX(moves, current);
                y = goY(moves, current);

                var point = new Point2D(x, y);
                grid[point] = current;
            }

            throw new NotImplementedException();
        }

        private int goX(int moves, int current)
        {
            throw new NotImplementedException();
        }

        private int goY(int moves, int current)
        {
            throw new NotImplementedException();
        }
    }
}
