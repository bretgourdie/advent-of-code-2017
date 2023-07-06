namespace advent_of_code_2017.Day17;
internal class Day17 : AdventSolution
{
    protected override long part1ExampleExpected => 638;

    protected override long part1InputExpected => 1914;

    protected override long part2ExampleExpected => 1222153;

    protected override long part2InputExpected => 41797835;


    protected long work(
        string[] input,
        long insertions,
        long target)
    {
        var stepForward = int.Parse(input.First());

        var list = new LinkedList<long>();
        list.AddLast(0);
        var current = list.First!;

        for (int ii = 1; ii <= insertions; ii++)
        {
            for (int steps = 0; steps < stepForward; steps++)
            {
                current = getNext(current!, list);
            }

            if (current != null)
            {
                list.AddAfter(current, ii);
                current = getNext(current, list);
            }
        }

        var found = list.Find(target);

        if (found != null)
        {
            return getNext(found, list).Value;
        }

        else
        {
            return -1;
        }
    }

    private static LinkedListNode<T> getNext<T>(LinkedListNode<T> node, LinkedList<T> list) =>
        node.Next ?? list.First!;

    protected override long part1Work(string[] input) => work(input, 2017, 2017);

    protected override long part2Work(string[] input) => work(input, 50_000_000, 0);
}
