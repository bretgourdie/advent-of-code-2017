namespace advent_of_code_2017.Day03
{
    internal class Grid
    {
        public long Generate(int target, Func<int, int> getNext)
        {
            IDictionary<int, Point2D> grid = new Dictionary<int, Point2D>()
            {
                {1, new Point2D(0, 0) }
            };

            int x = 0;
            int y = 0;

            int xDirection = 1;
            int yDirection = 0;

            int current = 1;
            int moves = 0;

            int remainingInDirection = 1;

            while (current != target)
            {
                current = getNext(current);

                var newXDirection = getXDirection(xDirection, yDirection, remainingInDirection);
                var newYDirection = getYDirection(xDirection, yDirection, remainingInDirection);
                remainingInDirection = getRemainingInDirection(remainingInDirection, moves);

                xDirection = newXDirection;
                yDirection = newYDirection;

                x += 1 * xDirection;
                y += 1 * yDirection;

                var point = new Point2D(x, y);
                grid[current] = point;
                moves += 1;
            }

            return Math.Abs(grid[current].X)
                + Math.Abs(grid[current].Y);
        }

        private int getRemainingInDirection(
            int remainingInDirection,
            int moves)
        {
            if (remainingInDirection > 0)
            {
                return remainingInDirection - 1;
            }

            var sqrt = Math.Sqrt(moves - 1);

            var flooredSqrt = Math.Floor(sqrt);

            return (int)flooredSqrt;
        }

        private int getXDirection(
            int xDirection,
            int yDirection,
            int remainingInDirection)
        {
            if (remainingInDirection > 0)
            {
                return xDirection;
            }

            else
            {
                if (xDirection != 0)
                {
                    return 0;
                }

                else
                {
                    if (yDirection < 0)
                    {
                        return -1;
                    }

                    else
                    {
                        return 1;
                    }
                }
            }
        }

        private int getYDirection(
            int xDirection,
            int yDirection,
            int remainingInDirection)
        {
            if (remainingInDirection > 0)
            {
                return yDirection;
            }

            else
            {
                if (yDirection != 0)
                {
                    return 0;
                }

                else
                {
                    if (xDirection < 0)
                    {
                        return 1;
                    }

                    else
                    {
                        return -1;
                    }
                }
            }
        }
    }
}
