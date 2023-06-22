namespace advent_of_code_2017.Day06;
internal class Day06 : AdventSolution
{
    protected override long part1ExampleExpected => 5;

    protected override long part1InputExpected => 14029;

    protected override long part2ExampleExpected => 4;

    protected override long part2InputExpected => 2765;

    private string getBankString(int[] banks) =>
        String.Join(' ', banks);

    private long work(string[] input, ITerminateStrategy strategy)
    {
        var banks = input.Single().Split('\t').Select(x => int.Parse(x)).ToArray();

        while (!strategy.IsDone(getBankString(banks)))
        {
            strategy.Add(getBankString(banks));

            var firstIndexOfMaxBlocks = banks
                .Select( (blocks, index) => (blocks, index) )
                .First(bank => bank.blocks == banks.Max())
                .index;

            var blocksToSpread = banks[firstIndexOfMaxBlocks];
            banks[firstIndexOfMaxBlocks] = 0;

            for (int ii = 0; ii < blocksToSpread; ii++)
            {
                var currentIndex = (firstIndexOfMaxBlocks + ii + 1) % banks.Length;

                banks[currentIndex] += 1;
            }
        }

        return strategy.GetSteps();
    }

    protected override long part1Work(string[] input) =>
        work(input, new InfiniteLoopDetection());

    protected override long part2Work(string[] input) =>
        work(input, new CycleLengthDetection());
}
