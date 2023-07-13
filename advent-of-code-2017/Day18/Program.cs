﻿namespace advent_of_code_2017.Day18;
internal class Program
{
    public readonly long Id;
    public readonly IDictionary<string, long> Registers;
    public int InstructionCounter = 0;
    public bool IsReceiving { get; private set; }
    private readonly Queue<long> sendBuffer;

    public Program()
    {
        Registers = new Dictionary<string, long>();
        sendBuffer = new Queue<long>();
    }

    public Program(long id)
    {
        Id = id;
        Registers = new Dictionary<string, long>();
        Registers["p"] = id;
        sendBuffer = new Queue<long>();
    }

    public bool ShouldStillRun(IList<string> instructions) =>
        InstructionCounter >= 0 && InstructionCounter < instructions.Count
        && !IsReceiving;

    public bool HasAnythingInQueue()
    {
        return sendBuffer.Any();
    }

    public long ConsumeSendBuffer()
    {
        if (!sendBuffer.Any())
            throw new InvalidOperationException($"{nameof(sendBuffer)} is empty");

        return sendBuffer.Dequeue();
    }
}
