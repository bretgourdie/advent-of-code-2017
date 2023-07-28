namespace advent_of_code_2017.Day25;
internal class ConditionalInstruction
{
    private readonly int currentValueComparison;
    private readonly int writeValue;
    private readonly int direction;
    private readonly string resultingState;

    public ConditionalInstruction(
        string currentValueComparisonLine,
        string writeValueLine,
        string directionLine,
        string resultingStateLine)
    {
        currentValueComparison = parseCurrentValueComparison(currentValueComparisonLine);
        writeValue = parseWriteValue(writeValueLine);
        direction = parseDirection(directionLine);
        resultingState = parseResultingState(resultingStateLine);
    }

    private int parseCurrentValueComparison(string currentValueComparisonString)
    {
        return currentValueComparisonString.GetIntegerValueBetween(
            "  If the current value is ",
            ":");
    }

    private int parseWriteValue(string writeValueString)
    {
        return writeValueString.GetIntegerValueBetween(
            "    - Write the value ",
            ".");
    }

    private int parseDirection(string directionString)
    {
        return directionString.GetValueBetween(
            "    - Move one slot to the ",
            ".")
            == "right" ? 1 : -1;
    }

    private string parseResultingState(string resultingStateString)
    {
        return resultingStateString.GetValueBetween(
            "    - Continue with state ",
            ".");
    }

    public bool Applies(int currentValue)
    {
        return currentValueComparison == currentValue;
    }

    public string PerformWork(Tape tape)
    {
        tape.Write(writeValue);
        tape.Move(direction);
        return resultingState;
    }
}
