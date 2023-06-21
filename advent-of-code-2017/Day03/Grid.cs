namespace advent_of_code_2017.Day03
{
    internal class Grid
    {
        public long Generate(
            int target,
            ISolvingStrategy solvingStrategy)
        {
            Point2D currentPoint = new Point2D(0, 0);
            Point2D previousPoint;

            IDictionary<Point2D, int> grid = new Dictionary<Point2D, int>()
            {
                {currentPoint, 1}
            };

            int x = 0;
            int y = 0;

            int xDirection = 1;
            int yDirection = 0;

            int currentNumber = 1;
            int moves = 0;

            int remainingInDirection = 1;

            while (!solvingStrategy.IsFinished(currentNumber, target))
            {
                var newXDirection = getXDirection(xDirection, yDirection, remainingInDirection);
                var newYDirection = getYDirection(xDirection, yDirection, remainingInDirection);
                remainingInDirection = getRemainingInDirection(remainingInDirection, moves);

                xDirection = newXDirection;
                yDirection = newYDirection;

                x += 1 * xDirection;
                y += 1 * yDirection;

                previousPoint = currentPoint;
                currentPoint = new Point2D(x, y);
                currentNumber = solvingStrategy.AddToCurrent(previousPoint, currentPoint, grid);

                grid[currentPoint] = currentNumber;
                moves += 1;
            }

            return solvingStrategy.GetValue(currentPoint, grid);
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
