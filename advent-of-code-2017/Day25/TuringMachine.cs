namespace advent_of_code_2017.Day25;
internal class TuringMachine
{
    private readonly IDictionary<string, State> states;

    private string currentState;
    private readonly long steps;

    public TuringMachine(IList<string> input)
    {
        currentState = parseStartingState(input.Skip(0).Take(1).Single());
        steps = parseSteps(input.Skip(1).Take(1).Single());

        states = parseStates(input.Skip(3).ToList());
    }

    public long GetChecksum()
    {
        var tape = new Tape();

        for (int ii = 0; ii < steps; ii++)
        {
            currentState = states[currentState].Handle(tape);
        }

        return tape.Checksum();
    }

    private IDictionary<string, State> parseStates(IList<string> statesLines)
    {
        var states = new Dictionary<string, State>();

        for (int ii = 0; ii < statesLines.Count; ii += 10)
        {
            var state = new State(
                statesLines[ii],
                statesLines.Skip(ii + 1).Take(8));

            states.Add(state.Name, state);
        }

        return states;
    }

    private string parseStartingState(string startingStateLine)
    {
        return startingStateLine.GetValueBetween(
            "Begin in state ",
            ".");
    }

    private long parseSteps(string stepLine)
    {
        return stepLine.GetLongValueBetween(
            "Perform a diagnostic checksum after ",
            " steps.");
    }
}
