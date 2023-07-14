namespace advent_of_code_2017.Day18;
internal class Program
{
    public readonly long Id;
    public readonly IDictionary<string, long> Registers;
    public int InstructionCounter = 0;
    private readonly Queue<long>? sendBuffer;

    public Program()
    {
        Registers = new Dictionary<string, long>();
    }

    public Program(long id)
    {
        Id = id;
        Registers = new Dictionary<string, long>();
        Registers["p"] = id;
        sendBuffer = new Queue<long>();
    }

    public bool IsReceiving(IList<string> instructions) =>
        sendBuffer != null
        && instructions[InstructionCounter].StartsWith("rcv");

    public bool ShouldStillRun(IList<string> instructions) =>
        InstructionCounter >= 0 && InstructionCounter < instructions.Count
        &&
        (
            (IsReceiving(instructions) && HasAnythingInQueue())
            || !IsReceiving(instructions)
        );

    public bool HasAnythingInQueue()
    {
        return sendBuffer?.Any() ?? false;
    }

    public void Receive(long value)
    {
        sendBuffer?.Enqueue(value);
    }

    public long ConsumeSendBuffer()
    {
        if (sendBuffer == null) throw new InvalidOperationException();

        if (!HasAnythingInQueue())
            throw new InvalidOperationException($"{nameof(sendBuffer)} is empty");

        return sendBuffer.Dequeue();
    }
}
