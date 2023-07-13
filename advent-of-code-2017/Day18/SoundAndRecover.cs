namespace advent_of_code_2017.Day18;
internal class SoundAndRecover : Duet
{
    private long lastPlayedSound = 0;

    public override long Play(IList<string> instructions)
    {
        var program = new Program();

        while (program.ShouldStillRun(instructions))
        {
            var result = HandleInstruction(instructions, program);

            if (result != 0)
            {
                return result;
            }
        }

        throw new ArgumentException();
    }

    protected override long GetAnswer() => lastPlayedSound;

    protected override void snd(string argument, Program program)
    {
        lastPlayedSound = sound(argument, program);
    }

    protected override bool rcv(string arg1, Program program) =>
        recover(arg1, program);
}
