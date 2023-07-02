using System.Data;

namespace advent_of_code_2017.Day12;
internal class Day12 : AdventSolution
{
    protected override long part1ExampleExpected => 6;

    protected override long part1InputExpected => 283;

    protected override long part2ExampleExpected => throw new NotImplementedException();

    protected override long part2InputExpected => throw new NotImplementedException();

    protected override long part1Work(string[] input)
    {
        var paths = getPaths(input);
        const int target = 0;
        int numbersThatCanReachTarget = 0;

        foreach (var path in paths.Keys)
        {
            if (canReach(paths, path, target, new HashSet<int>()))
            {
                numbersThatCanReachTarget += 1;
            }
        }

        return numbersThatCanReachTarget;
    }

    private bool canReach(
        IDictionary<int, IList<int>> paths,
        int path,
        int target,
        ISet<int> visitedPaths)
    {
        var options = paths[path];

        if (path == target || options.Contains(target))
        {
            return true;
        }

        visitedPaths.Add(path);

        foreach (var option in options)
        {
            if (!visitedPaths.Contains(option))
            {
                if (canReach(paths, option, target, visitedPaths))
                {
                    return true;
                }
            }
        }

        return false;
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

    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }
}
