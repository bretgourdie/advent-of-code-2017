namespace advent_of_code_2017.Day18;
internal class SoundAndRecover : Duet
{
    private readonly IDictionary<string, long> registers;
    private long lastPlayedSound = 0;

    public SoundAndRecover()
    {
        registers = new Dictionary<string, long>();
    }

    public override long Play(IList<string> instructions)
    {
        int instructionIndex = 0;

        while (instructionIndex >= 0 && instructionIndex < instructions.Count)
        {
            var instruction = instructions[instructionIndex];

            var result = HandleInstruction(instruction, registers, out int jumpAmount);

            if (result != 0)
            {
                return result;
            }

            if (jumpAmount < 0)
            {
                jumpAmount -= 1;
            }

            instructionIndex += 1 + jumpAmount;
        }

        throw new ArgumentException();
    }

    protected override long GetAnswer() => lastPlayedSound;

    protected override void snd(string argument, IDictionary<string, long> registers)
    {
        lastPlayedSound = sound(argument, registers);
    }

    protected override bool rcv(string arg1, IDictionary<string, long> registers) =>
        recover(arg1, registers);

}
