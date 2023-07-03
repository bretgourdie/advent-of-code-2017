namespace advent_of_code_2017.Day13;
internal class Day13 : AdventSolution
{
    protected override long part1ExampleExpected => 24;

    protected override long part1InputExpected => 1624;

    protected override long part2ExampleExpected => throw new NotImplementedException();

    protected override long part2InputExpected => throw new NotImplementedException();

    protected override long part1Work(string[] input)
    {
        var scanners = new Dictionary<int, Scanner>();

        foreach (var line in input)
        {
            var split = line.Split(": ");
            var depth = int.Parse(split[0]);
            var range = int.Parse(split[1]);
            scanners.Add(depth, new Scanner(range));
        }

        int severity = 0;
        var maxDepth = scanners.Keys.Max();

        for (int depth = 0; depth <= maxDepth; depth++)
        {
            if (scanners.ContainsKey(depth) && scanners[depth].Detected)
            {
                severity += depth * scanners[depth].Range;
            }

            updateScanners(scanners);
        }

        return severity;
    }

    private void updateScanners(IDictionary<int, Scanner> scanners)
    {
        foreach (var scanner in scanners.Keys)
        {
            scanners[scanner].Update();
        }
    }

    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }
}
