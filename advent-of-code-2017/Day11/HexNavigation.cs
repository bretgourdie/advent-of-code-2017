namespace advent_of_code_2017.Day11;
internal class HexNavigation
{
    private readonly IDictionary<string, Navigation> instructionToNavigation =
        new Dictionary<string, Navigation>()
        {
            {"n", new Navigation(+0, -1) },
            {"ne", new Navigation(+1, -1) },
            {"se", new Navigation(+1, +0) },
            {"s", new Navigation(+0, +1) },
            {"sw", new Navigation(-1, +1) },
            {"nw", new Navigation(-1, +0) }
        };

    public long Navigate(
        string[] instructions,
        Func<long, long, long> returnStrategy)
    {
        long q = 0;
        long r = 0;
        long maxDistance = -1;

        foreach (var instruction in instructions)
        {
            var navigation = instructionToNavigation[instruction];

            q += navigation.Q;
            r += navigation.R;

            maxDistance = Math.Max(maxDistance, manhattanDistance(q, r));
        }

        return returnStrategy(manhattanDistance(q, r), maxDistance);
    }

    private long manhattanDistance(long q, long r)
    {
        return
            (q > 0 ? q : 0)
            + (r > 0 ? r : 0)
            + (-q - r > 0 ? -q - r : 0);
    }

    private struct Navigation
    {
        public long Q;
        public long R;

        public Navigation(long q, long r)
        {
            Q = q;
            R = r;
        }
    }
}
