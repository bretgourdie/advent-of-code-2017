namespace advent_of_code_2017.Day25;
internal class State
{
    private readonly IEnumerable<ConditionalInstruction> conditionalInstructions;
    public readonly string Name;

    public State(
        string inStateLine,
        IEnumerable<string> conditionalInstructionStrings)
    {
        Name = parseState(inStateLine);
        conditionalInstructions = parseConditionalInstructions(conditionalInstructionStrings);
    }

    private string parseState(string inStateLine)
    {
        return inStateLine.Substring("In state ".Length, 1);
    }

    private IEnumerable<ConditionalInstruction> parseConditionalInstructions(
        IEnumerable<string> conditionalInstructionStrings)
    {
        var instructions = new List<ConditionalInstruction>();

        for (int ii = 0; ii < conditionalInstructionStrings.Count(); ii += 4)
        {
            instructions.Add(
                new ConditionalInstruction(
                    conditionalInstructionStrings.Skip(ii + 0).Take(1).Single(),
                    conditionalInstructionStrings.Skip(ii + 1).Take(1).Single(),
                    conditionalInstructionStrings.Skip(ii + 2).Take(1).Single(),
                    conditionalInstructionStrings.Skip(ii + 3).Take(1).Single()));
        }

        return instructions;
    }

    public string Handle(Tape tape)
    {
        var value = tape.Read();

        foreach (var condition in conditionalInstructions)
        {
            if (condition.Applies(value))
            {
                return condition.PerformWork(tape);
            }
        }

        throw new ApplicationException($"State {this.Name}, Tape Value {value}");
    }

    public override string ToString() => $"State {this.Name}";
}
