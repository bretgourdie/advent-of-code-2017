namespace advent_of_code_2017.Day23;
internal interface ICoProcessorStrategy
{
    IDictionary<string, long> InitializeRegisters();
    long GetAnswer(IDictionary<string, long> registers);
    void HandleInstructionProcessed(string instruction);
}
