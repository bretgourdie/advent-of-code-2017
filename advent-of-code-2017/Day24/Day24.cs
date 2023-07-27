namespace advent_of_code_2017.Day24;
internal class Day24 : AdventSolution
{
    private long work(
        string[] input,
        Func<IDictionary<string, long>,long> resultFunction)
    {
        var bridgesToStrength = new Dictionary<string, long>();
        var components = parseComponents(input) ?? throw new ArgumentException(nameof(input));

        var starters = components.Where(x => x.Ports.Contains(0));

        foreach (var starter in starters)
        {
            var startingBridge = new Bridge(starter);
            buildAllBridges(
                startingBridge,
                components.Where(x => x != starter).ToList(),
                bridgesToStrength);
        }

        return resultFunction(bridgesToStrength);
    }

    private void buildAllBridges(
        Bridge startingBridge,
        IList<Component> availableComponents,
        IDictionary<string, long> builtBridges)
    {
        if (availableComponents == null) throw new ArgumentNullException(nameof(availableComponents));

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

    private IList<Component> parseComponents(IList<string> input)
    {
        var components = new List<Component>();

        foreach (var line in input)
        {
            components.Add(new Component(line));
        }

        return components;
    }

    private long strongestBridge(IDictionary<string, long> bridgesToStrength)
    {
        return bridgesToStrength.Values.Max();
    }

    private long longestStrongestBridge(IDictionary<string, long> bridgesToStrength)
    {
        var longestBridgeLinks =
            bridgesToStrength.Keys
                .Select(x => x.Count(letter => letter == '-'))
                .Max();

        var longestBridges = bridgesToStrength.Where(x => x.Key.Count(letter => letter == '-') == longestBridgeLinks);

        return longestBridges.Max(x => x.Value);
    }

    protected override long part1Work(string[] input) =>
        work(input, strongestBridge);

    protected override long part1ExampleExpected => 31;
    protected override long part1InputExpected => 1859;

    protected override long part2Work(string[] input) =>
        work(input, longestStrongestBridge);

    protected override long part2ExampleExpected => 19;
    protected override long part2InputExpected => 1799;
}
