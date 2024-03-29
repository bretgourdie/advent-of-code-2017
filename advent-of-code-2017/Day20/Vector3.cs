﻿namespace advent_of_code_2017.Day20;
internal struct Vector3
{
    public int X;
    public int Y;
    public int Z;

    public Vector3(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector3 operator +(Vector3 a, Vector3 b) =>
        new Vector3(
            a.X + b.X,
            a.Y + b.Y,
            a.Z + b.Z);

    public override bool Equals(object? obj)
    {
        return obj is Vector3 v && 
              X == v.X
              && Y == v.Y
              && Z == v.Z;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
    }
}
