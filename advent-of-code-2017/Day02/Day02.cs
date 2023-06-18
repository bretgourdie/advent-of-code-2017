namespace advent_of_code_2017.Day02
{
    internal class Day02 : AdventSolution
    {
        protected override long part1ExampleExpected => 18;

        protected override long part1InputExpected => 32020;

        protected override long part2ExampleExpected => 9;

        protected override long part2InputExpected => 236;

        protected override long part1Work(string[] input)
        {
            var list = new List<int>();

            foreach (var line in input)
            {
                var split = line.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                list.Add(split.Select(x => int.Parse(x)).Max() - split.Select(x => int.Parse(x)).Min());
            }

            return list.Sum();
        }

        protected override long part2Work(string[] input)
        {
            var list = new List<int>();

            long sum = 0;

            foreach (var line in input)
            {
                var split = line.Split("\t", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x));

                foreach (var item in split)
                {
                    foreach (var otherItem in split)
                    {
                        if (item != otherItem)
                        {
                            var max = Math.Max(item, otherItem);
                            var min = Math.Min(item, otherItem);

                            if ((double)max / min == (int)(max / min))
                            {
                                sum += max / min;
                            }
                        }
                    }
                }

            }

            return sum / 2;
        }
    }
}
