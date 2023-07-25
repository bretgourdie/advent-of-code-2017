namespace advent_of_code_2017.Day23;
internal class Debugging : ICoProcessorStrategy
{
    private long numberOfMultiplies;

    public IDictionary<string, long> InitializeRegisters()
    {
        var registers = new Dictionary<string, long>();

        for (int ii = 0; ii < 8; ii++)
        {
            registers[('a' + ii).ToString()] = 0;
        }

        return registers;
    }

    public void HandleInstructionProcessed(string instruction)
    {
        if (instruction == "mul")
        {
            numberOfMultiplies += 1;
        }
    }

    public long GetAnswer(IDictionary<string, long> registers) => numberOfMultiplies;
}
