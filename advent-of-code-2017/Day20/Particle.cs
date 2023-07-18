namespace advent_of_code_2017.Day20;
internal class Particle
{
    public Vector3 Position { get; private set; }
    private Vector3 velocity;
    private readonly Vector3 acceleration;

    public readonly long Id;

    public Particle(
        int id,
        string line)
    {
        Id = id;

        var split = line.Split(", ", StringSplitOptions.RemoveEmptyEntries);
        Position = parseVector(split[0]);
        velocity = parseVector(split[1]);
        acceleration = parseVector(split[2]);
    }

    private Vector3 parseVector(string lineSegment)
    {
        var split = lineSegment.Split('=');
        var cleanedVectorPart = split[1].Replace("<", "").Replace(">", "");
        var splitVectorPart = cleanedVectorPart.Split(',');

        return new Vector3(
            int.Parse(splitVectorPart[0]),
            int.Parse(splitVectorPart[1]),
            int.Parse(splitVectorPart[2])
        );
    }

    public void Update()
    {
        velocity += acceleration;
        Position += velocity;
    }

    public int GetManhattanDistance()
    {
        return Math.Abs(Position.X)
           + Math.Abs(Position.Y)
           + Math.Abs(Position.Z);
    }
}
