﻿namespace advent_of_code_2017.Day03;

internal interface ISolvingStrategy
{
    int AddToCurrent(Point2D previousPoint, Point2D placingPoint, IDictionary<Point2D, int> grid);
    bool IsFinished(int current, int target);
    int GetValue(Point2D lastPoint, IDictionary<Point2D, int> grid);
}
