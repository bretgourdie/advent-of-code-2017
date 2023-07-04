namespace advent_of_code_2017.Day13;
internal class Day13 : AdventSolution
{
    protected override long part1ExampleExpected => 24;

    protected override long part1InputExpected => 1624;

    protected override long part2ExampleExpected => 10;

    protected override long part2InputExpected => 3923436;


    private long work(
        IDictionary<int, Scanner> scanners,
        int delay,
        out bool wasCaught)
    {
        wasCaught = false;


        int severity = 0;
        var maxDepth = scanners.Keys.Max();

        for (int depth = 0; depth <= maxDepth; depth++)
        {
            if (scanners.ContainsKey(depth) && scanners[depth].WillBeCaught(depth, delay))
            {
                wasCaught = true;
                severity += depth * scanners[depth].Range;
            }
        }

        return severity;
    }
    
    private IDictionary<int, Scanner> getScanners(string[] input)
    {
        var scanners = new Dictionary<int, Scanner>();

        foreach (var line in input)
        {
            var split = line.Split(": ");
            var depth = int.Parse(split[0]);
            var range = int.Parse(split[1]);
            scanners.Add(depth, new Scanner(range));
        }

        return scanners;
    }

    protected override long part1Work(string[] input) =>
        work(getScanners(input), 0, out bool wasCaught);

    protected override long part2Work(string[] input)
    {
        int delay = 0;
        bool wasCaught = true;

        var scanners = getScanners(input);

        while (wasCaught)
        {
            long severity = work(scanners, delay, out wasCaught);

            if (!wasCaught)
            {
                return delay;
            }

            delay += 1;
        }

        return -1;
    }
}
