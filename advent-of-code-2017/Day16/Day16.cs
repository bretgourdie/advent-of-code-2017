namespace advent_of_code_2017.Day16;
internal class Day16 : AdventSolutionTemplate<string, string>
{
    protected override string part1ExampleExpected => "baedc";

    protected override string part1InputExpected => "ionlbkfeajgdmphc";

    protected override string part2ExampleExpected => throw new NotImplementedException();

    protected override string part2InputExpected => throw new NotImplementedException();

    protected override string part1Work(string[] input)
    {
        var lines = input.First().Split(',');
        var danceLine = new DanceLine(getDanceLineLength(lines));

        foreach (var line in lines)
        {
            danceLine.Handle(line);
        }

        return danceLine.ToString();
    }

    private int getDanceLineLength(string[] input)
    {
        if (input.Length <= 3)
        {
            return 5;
        }

        else
        {
            return 16;
        }
    }

    protected override string part2Work(string[] input)
    {
        throw new NotImplementedException();
    }
}
