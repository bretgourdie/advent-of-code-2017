using System.Xml.XPath;

namespace advent_of_code_2017.Day07;
internal class Day07 : AdventSolutionTemplate<string, long>
{
    protected override string part1ExampleExpected => "tknk";

    protected override string part1InputExpected => "rqwgj";

    protected override long part2ExampleExpected => 60;

    protected override long part2InputExpected => 333;

    private Node getRoot(IDictionary<string, Node> nodeLookup)
    {
        var nodes = nodeLookup.Keys;
        var candidateNodes = new HashSet<string>(nodes);

        foreach (var node in nodes)
        {
            if (nodeLookup.Values.Any(x => x.Children.Contains(node)))
            {
                candidateNodes.Remove(node);
            }
        }

        return nodeLookup[candidateNodes.Single()];
    }

    private IDictionary<string, Node> getNodeLookup(string[] input)
    {
        var dict = new Dictionary<string, Node>();

        foreach (var element in input)
        {
            var node = new Node(element);

            dict[node.Name] = node;
        }

        return dict;
    }

    protected override string part1Work(string[] input) =>
        getRoot(getNodeLookup(input)).Name;

    protected override long part2Work(string[] input)
    {
        var nodeLookup = getNodeLookup(input);
        var root = getRoot(nodeLookup);

        var balanceNeeded = determineBalancing(root, nodeLookup);

        return balanceNeeded.Weight;
    }

    private BalancingResult determineBalancing(
        Node root,
        IDictionary<string, Node> nodeLookup)
    {
        var nodeToChildrenWeight = new Dictionary<string, long>();
        foreach (var child in root.Children)
        {
            var result = determineBalancing(nodeLookup[child], nodeLookup);

            if (result.Type == BalancingResult.ResultType.ChildWeight)
            {
                nodeToChildrenWeight[child] = result.Weight;
            }
            else
            {
                return result;
            }
        }

        if (nodeToChildrenWeight.Values.Distinct().Count() > 1)
        {
            var oddOneOut = nodeToChildrenWeight
                .Where(x => nodeToChildrenWeight.Count(y => y.Value == x.Value) == 1)
                .Single();

            var otherWeight = nodeToChildrenWeight.Values
                .Where(x => nodeToChildrenWeight.Values.Count(y => y == x) > 1)
                .Distinct()
                .Single();

            var correctingWeight =
                nodeLookup[oddOneOut.Key].Weight
                + (otherWeight - oddOneOut.Value);

            return new BalancingResult(correctingWeight, BalancingResult.ResultType.BalanceCorrection);
        }

        else
        {
            var childrenWeight = nodeToChildrenWeight.Values.Sum() + root.Weight;
            return new BalancingResult(childrenWeight, BalancingResult.ResultType.ChildWeight);
        }
    }

    private struct BalancingResult
    {
        public readonly long Weight;
        public readonly ResultType Type;

        public BalancingResult(
            long weight,
            ResultType resultType)
        {
            Weight = weight;
            Type = resultType;
        }

        public enum ResultType
        {
            ChildWeight,
            BalanceCorrection
        }
    }
}
