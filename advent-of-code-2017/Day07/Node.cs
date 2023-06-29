namespace advent_of_code_2017.Day07;
internal class Node
{
    public readonly IEnumerable<string> Children;
    public readonly string Name;
    public readonly long Weight;

    public Node(string line)
    {
        var arrowSplit = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        var nameAndWeight = arrowSplit[0].Split(' ');
        this.Name = nameAndWeight[0];
        this.Weight = long.Parse(nameAndWeight[1].Replace("(", "").Replace(")", ""));

        if (arrowSplit.Length >= 2)
        {
            var childrenSplit = arrowSplit[1].Split(", ", StringSplitOptions.RemoveEmptyEntries);

            this.Children = childrenSplit;
        }

        else
        {
            Children = Enumerable.Empty<string>();
        }
    }
}
