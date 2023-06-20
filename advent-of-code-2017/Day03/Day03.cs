namespace advent_of_code_2017.Day03
{
    internal class Day03 : AdventSolution
    {
        protected override long part1ExampleExpected => 31;

        protected override long part1InputExpected => 419;

        protected override long part2ExampleExpected => throw new NotImplementedException();

        protected override long part2InputExpected => throw new NotImplementedException();

        protected override long part1Work(string[] input)
        {
            return new Grid().Generate(int.Parse(input.First()), x => x + 1);
        }

        protected override long part2Work(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}
