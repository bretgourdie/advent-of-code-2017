namespace advent_of_code_2017.Day24;
internal class Bridge
{
    private Queue<Component> _bridge;
    public long Connector;

    private const long startingPort = 0;

    public Bridge(Component component)
    {
        _bridge = new Queue<Component>();
        _bridge.Enqueue(component);

        Connector = determineConnector(component);
    }

    public Bridge(Bridge other)
    {
        _bridge = new Queue<Component>(other._bridge);
        Connector = other.Connector;
    }

    public void Connect(Component component)
    {
        _bridge.Enqueue(component);

        Connector = determineConnector(component);
    }

    private long determineConnector(
        Component component)
    {
        if (component.Ports.All(x => x == Connector))
        {
            return component.Ports[0];
        }

        return component.Ports.Where(x => x != this.Connector).Distinct().Single();
    }

    public long GetStrength() =>
        _bridge.Sum(x => x.Strength());

    public override string ToString() =>
        String.Join("--", _bridge);
}
