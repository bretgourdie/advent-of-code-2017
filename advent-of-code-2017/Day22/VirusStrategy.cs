namespace advent_of_code_2017.Day22;
internal abstract class VirusStrategy
{
    protected readonly IList<Direction> clockwiseDirections = new List<Direction>()
    {
        Direction.North,
        Direction.East,
        Direction.South,
        Direction.West
    };

    public abstract Direction DetermineDirection(Point2D location, Direction direction);
    public abstract void AffectNode(Point2D virusLocation);
    public abstract int NumberOfIterations { get; }
    public abstract long NumberOfInfections { get; }

    protected T turnCounterClockwise<T>(T value, IList<T> clockwiseList) =>
        turn(value, -1, clockwiseList);

    protected T turnClockwise<T>(T value, IList<T> clockwiseList) =>
        turn(value, 1, clockwiseList);

    private T turn<T>(
        T value,
        int forward,
        IList<T> clockwiseList)
    {
        var existingIndex = clockwiseList.IndexOf(value);
        var newIndex = (existingIndex + clockwiseList.Count + forward);
        var circledIndex = newIndex % clockwiseList.Count;
        return clockwiseList[circledIndex];
    }
}
