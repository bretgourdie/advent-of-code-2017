namespace advent_of_code_2017.Day01;

internal class Day01 : AdventSolution
{
    protected override long part1ExampleExpected => 3;

    protected override long part1InputExpected => 1175;

    protected override long part2ExampleExpected => 0;

    protected override long part2InputExpected => 1166;

    protected override long part1Work(string[] input)
    {
        var line = input[0];
        var prev = -1;
        long sum = 0;
        for (int ii = 0; ii < line.Length; ii++)
        {
            var current = int.Parse(line[ii].ToString());

            if (current == prev)
            {
                sum += current;
            }

            prev = current;
        }

        if (line[0] == line[line.Length - 1])
        {
            sum += int.Parse(line[0].ToString());
        }

        return sum;
    }

    protected override long part2Work(string[] input)
    {
        var line = input[0];
        var around = -1;
        long sum = 0;

        for (int ii = 0; ii < line.Length; ii++)
        {
            var current = int.Parse(line[ii].ToString());
            var aroundIndex = (ii + line.Length / 2) % line.Length;
            around = int.Parse(line[aroundIndex].ToString());

            if (current == around)
            {
                sum += current;
            }
        }

        return sum;
    }
}
