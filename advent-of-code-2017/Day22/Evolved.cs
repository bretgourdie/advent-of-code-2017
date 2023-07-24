namespace advent_of_code_2017.Day22;
internal class Evolved : VirusStrategy
{
    private readonly IList<NodeStatus> statusCycle = new List<NodeStatus>()
    {
        NodeStatus.Clean,
        NodeStatus.Weakened,
        NodeStatus.Infected,
        NodeStatus.Flagged
    };

    private readonly ISet<NodeStatus> trackableStatuses = new HashSet<NodeStatus>()
    {
        NodeStatus.Flagged,
        NodeStatus.Infected,
        NodeStatus.Weakened
    };

    private long numberOfInfections;

    private readonly IDictionary<NodeStatus, ISet<Point2D>> statusToNodes =
        new Dictionary<NodeStatus, ISet<Point2D>>();

    public Evolved(ISet<Point2D> infectedGrid)
    {
        statusToNodes[NodeStatus.Weakened] = new HashSet<Point2D>();
        statusToNodes[NodeStatus.Infected] = infectedGrid;
        statusToNodes[NodeStatus.Flagged] = new HashSet<Point2D>();
    }

    public override Direction DetermineDirection(Point2D location, Direction direction)
    {
        if (statusToNodes[NodeStatus.Weakened].Contains(location))
        {
            return direction;
        }

        else if (statusToNodes[NodeStatus.Infected].Contains(location))
        {
            return turnClockwise(direction, clockwiseDirections);
        }

        else if (statusToNodes[NodeStatus.Flagged].Contains(location))
        {
            return turnClockwise(turnClockwise(direction, clockwiseDirections), clockwiseDirections);
        }

        // assume clean
        return turnCounterClockwise(direction, clockwiseDirections);
    }

    public override void AffectNode(Point2D virusLocation)
    {
        bool found = false;
        foreach (var status in statusToNodes.Keys)
        {
            if (statusToNodes[status].Contains(virusLocation))
            {
                statusToNodes[status].Remove(virusLocation);
                var toStatus = turnClockwise(status, statusCycle);

                if (trackableStatuses.Contains(toStatus))
                {
                    statusToNodes[toStatus].Add(virusLocation);
                }

                handleToStatusEvent(toStatus);

                found = true;
                break;
            }
        }

        if (!found)
        {
            // assume clean
            statusToNodes[turnClockwise(NodeStatus.Clean, statusCycle)].Add(virusLocation);
            handleToStatusEvent(turnClockwise(NodeStatus.Clean, statusCycle));
        }
    }

    private void handleToStatusEvent(NodeStatus toStatus)
    {
        if (toStatus == NodeStatus.Infected)
        {
            numberOfInfections += 1;
        }
    }

    private enum NodeStatus
    {
        Clean,
        Weakened,
        Infected,
        Flagged
    }

    public override int NumberOfIterations => 10_000_000;
    public override long NumberOfInfections => numberOfInfections;
}
