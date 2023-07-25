namespace advent_of_code_2017.Day23;
internal class Troubleshooting : ICoProcessorStrategy
{
    public IDictionary<string, long> InitializeRegisters()
    {
        var registers = new Dictionary<string, long>();

        for (int ii = 0; ii < 8; ii++)
        {
            registers[('a' + ii).ToString()] = 0;
        }

        registers["a"] = 1;

        return registers;
    }

    public long GetAnswer(IDictionary<string, long> registers) => registers["h"];

    public void HandleInstructionProcessed(string instruction) { }
}
