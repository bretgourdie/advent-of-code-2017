namespace advent_of_code_2017.Day13;
internal class Day13 : AdventSolution
{
    protected override long part1ExampleExpected => 24;

    protected override long part1InputExpected => 1624;

    protected override long part2ExampleExpected => 10;

    protected override long part2InputExpected => 3923436;


    private long work(
        IDictionary<int, int> scanners,
        int delay,
        out bool wasCaught)
    {
        wasCaught = false;


        int severity = 0;
        var maxDepth = scanners.Keys.Max();

        for (int depth = 0; depth <= maxDepth; depth++)
        {
            int time = depth + delay;
            if (scanners.ContainsKey(depth) && willBeCaught(scanners[depth], time))
            {
                wasCaught = true;
                severity += depth * scanners[depth];
            }
        }

        return severity;
    }
    
    private IDictionary<int, int> getScanners(string[] input)
    {
        var scanners = new Dictionary<int, int>();

        foreach (var line in input)
        {
            var split = line.Split(": ");
            var depth = int.Parse(split[0]);
            var range = int.Parse(split[1]);
            scanners.Add(depth, range);
        }

        return scanners;
    }

    private bool willBeCaught(int range, int time)
    {
        int cycle = (range * 2 - 2);
        return time % cycle == 0;
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
