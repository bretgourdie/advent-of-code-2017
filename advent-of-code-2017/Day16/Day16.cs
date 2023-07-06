namespace advent_of_code_2017.Day16;
internal class Day16 : AdventSolutionTemplate<string, string>
{
    protected override string part1ExampleExpected => "baedc";

    protected override string part1InputExpected => "ionlbkfeajgdmphc";

    protected override string part2ExampleExpected => "abcde";

    protected override string part2InputExpected => "fdnphiegakolcmjb";

    private IList<string> prepareInstructionLines(IList<string> input) => input.First().Split(',');

    private string danceOnce(DanceLine danceLine, IList<string> lines)
    {
        foreach (var line in lines)
        {
            danceLine.Handle(line);
        }

        return danceLine.ToString();
    }

    private int getDanceLineLength(IList<string> input)
    {
        if (input.Count <= 3)
        {
            return 5;
        }

        else
        {
            return 16;
        }
    }
    protected override string part1Work(string[] input)
    {
        var lines = prepareInstructionLines(input);
        var danceLine = new DanceLine(getDanceLineLength(lines));

        return danceOnce(danceLine, lines);
    }

    protected override string part2Work(string[] input)
    {
        const long target = 1_000_000_000;

        var lines = prepareInstructionLines(input);
        var danceLine = new DanceLine(getDanceLineLength(lines));
        var states = new Dictionary<string, long>();

        for (long ii = 0; ii < 1_000_000_000; ii++)
        {
            var result = danceOnce(danceLine, lines);

            if (states.ContainsKey(result))
            {
                var diff = ii - states[result];

                while (ii + diff < target)
                {
                    ii += diff;
                }

                states[result] = ii;
            }

            else
            {
                states[result] = ii;
            }
        }

        return danceLine.ToString();
    }
}
