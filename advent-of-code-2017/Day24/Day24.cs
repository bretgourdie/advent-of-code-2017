namespace advent_of_code_2017.Day24;
internal class Day24 : AdventSolution
{
    protected override long part1Work(string[] input)
    {
        var components = new List<Component>();

        foreach (var line in input)
        {
            components.Add(new Component(line));
        }

        return buildMaximumStrengthBridge(components);
    }

    private long buildMaximumStrengthBridge(
        IList<Component> components)
    {
        var bridgesToStrength = new Dictionary<string, long>();

        var starters = components.Where(x => x.Ports.Contains(0));

        foreach (var starter in starters)
        {
            var startingBridge = new Bridge(starter);
            buildAllBridges(
                startingBridge,
                components.Where(x => x != starter).ToList(),
                bridgesToStrength);
        }

        return bridgesToStrength.Values.Max();
    }

    private void buildAllBridges(
        Bridge startingBridge,
        IList<Component> availableComponents,
        IDictionary<string, long> builtBridges)
    {
        var startingBridgeString = startingBridge.ToString();
        if (builtBridges.ContainsKey(startingBridgeString))
        {
            return;
        }

        builtBridges[startingBridgeString] = startingBridge.GetStrength();

        var eligibleComponents = availableComponents.Where(x => x.Ports.Contains(startingBridge.Connector));

        foreach (var component in eligibleComponents)
        {
            var newBridge = new Bridge(startingBridge);
            newBridge.Connect(component);
            var remainingComponents = availableComponents.Where(x => x != component).ToList();
            buildAllBridges(newBridge, remainingComponents, builtBridges);
        }
    }

    protected override long part1ExampleExpected => 31;
    protected override long part1InputExpected => 1859;
    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }

    protected override long part2ExampleExpected { get; }
    protected override long part2InputExpected { get; }
}
