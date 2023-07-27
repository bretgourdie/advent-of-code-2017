namespace advent_of_code_2017.Day24;
internal class Component
{
    public readonly IList<long> Ports;

    public Component(string line)
    {
        var split = line.Split('/');
        Ports = new long[]
        {
            long.Parse(split[0]),
            long.Parse(split[1])
        };
    }

    public long Strength() => Ports.Sum();

    public override string ToString() => $"{Ports[0]}/{Ports[1]}";
}
