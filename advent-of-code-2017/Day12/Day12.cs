namespace advent_of_code_2017.Day12;
internal class Day12 : AdventSolution
{
    protected override long part1ExampleExpected => 6;

    protected override long part1InputExpected => 283;

    protected override long part2ExampleExpected => 2;

    protected override long part2InputExpected => 195;

    private IList<IList<int>> work(string[] input)
    {
        var paths = getPaths(input);
        var pathGroups = new List<IList<int>>();

        foreach (var path in paths.Keys)
        {
            if (!pathGroups.Any(x => x.Contains(path)))
            {
                pathGroups.Add(getGroup(
                    paths,
                    path,
                    new HashSet<int>()));
            }
        }

        return pathGroups;
    }

    private IList<int> getGroup(
        IDictionary<int, IList<int>> paths,
        int path,
        ISet<int> visitedPaths)
    {
        visitedPaths.Add(path);

        var options = paths[path];

        foreach (var option in options)
        {
            if (!visitedPaths.Contains(option))
            {
                getGroup(paths, option, visitedPaths);
            }
        }

        return visitedPaths.ToList();
    }

    private IDictionary<int, IList<int>> getPaths(IList<string> input)
    {
        var paths = new Dictionary<int, IList<int>>();

        foreach (var line in input)
        {
            var sourceAndDestinations = line.Split(" <-> ");

            var source = sourceAndDestinations[0];

            var destinations = sourceAndDestinations[1].Split(", ");

            paths[int.Parse(source)] = destinations.Select(x => int.Parse(x)).ToList();
        }

        return paths;
    }

    protected override long part1Work(string[] input)
    {
        return work(input)
            .Where(x => x.Contains(0))
            .SelectMany(x => x)
            .Count();
    }

    protected override long part2Work(string[] input)
    {
        return work(input).Count();
    }
}
