namespace advent_of_code_2017.Day18;
internal class SendAndReceive : Duet
{
    private readonly IDictionary<long, long> programSends;

    private readonly IList<Program> programs;

    public SendAndReceive()
    {
        programSends = new Dictionary<long, long>();

        programs = new Program[]
        {
            new Program(0),
            new Program(1),
        };

        foreach (var program in programs)
        {
            programSends[program.Id] = 0;
        }
    }

    public override long Play(IList<string> instructions)
    {
        while (getRunnablePrograms(instructions).Any())
        {
            var runnable = getRunnablePrograms(instructions);

            foreach (var program in runnable)
            {
                while (program.ShouldStillRun(instructions))
                {
                    var result = HandleInstruction(instructions, program);
                }
            }
        }

        return GetAnswer();
    }

    private IList<Program> getRunnablePrograms(
        IList<string> instructions) =>
        programs
            .Where(x => x.ShouldStillRun(instructions))
            .ToList();

    protected override long GetAnswer() => programSends[1];

    protected override void snd(string argument, Program sender)
    {
        var receiver = programs.Single(x => x.Id != sender.Id);
        send(argument, sender, receiver);
        programSends[sender.Id] += 1;
    }

    protected override bool rcv(string argument, Program program) => receive(argument, program);
}
