namespace advent_of_code_2017.Day22;
internal class PreEvolution : VirusStrategy
{
    private readonly ISet<Point2D> infectedPoints;
    private long numberOfInfections;

    public PreEvolution(ISet<Point2D> infectedPoints)
    {
        this.infectedPoints = infectedPoints;
    }
    
    public override Direction DetermineDirection(Point2D location, Direction direction)
    {
        if (infectedPoints.Contains(location))
        {
            return turnClockwise(direction, clockwiseDirections);
        }

        else
        {
            return turnCounterClockwise(direction, clockwiseDirections);
        }
    }

    public override void AffectNode(Point2D virusLocation)
    {
        if (infectedPoints.Contains(virusLocation))
        {
            infectedPoints.Remove(virusLocation);
        }

        else
        {
            infectedPoints.Add(virusLocation);
            numberOfInfections += 1;
        }
    }

    public override int NumberOfIterations => 10_000;

    public override long NumberOfInfections => numberOfInfections;
}
