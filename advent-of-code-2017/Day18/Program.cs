namespace advent_of_code_2017.Day18;
internal class Program
{
    public readonly long Id;
    public readonly IDictionary<string, long> Registers;
    public bool IsReceiving { get; private set; }
    private readonly Queue<long> sendBuffer;
    private readonly Duet playingStrategy;

    public Program()
    {
        Registers = new Dictionary<string, long>();
        playingStrategy = new SoundAndRecover();
        sendBuffer = new Queue<long>();
    }

    public Program(long id)
    {
        Id = id;
        Registers = new Dictionary<string, long>();
        Registers["p"] = id;
        sendBuffer = new Queue<long>();
        playingStrategy = new SendAndReceive();
    }

    public bool HasAnythingInQueue()
    {
        return sendBuffer?.Any() ?? false;
    }

    public long ReceiveFromQueue()
    {
        if (!sendBuffer.Any())
            throw new InvalidOperationException($"{nameof(sendBuffer)} is empty");

        return sendBuffer.Dequeue();
    }
}
