namespace advent_of_code_2017.Day18;
internal class Duet
{
    public long Play(IList<string> instructions)
    {
        IDictionary<string, long> registers = new Dictionary<string, long>();

        long lastPlayedSound = 0;

        for (int ii = 0; ii < instructions.Count; ii++)
        {
            var instruction = instructions[ii];
            var split = instruction.Split(' ');

            var instructionCode = split[0];

            switch (instructionCode)
            {
                case "snd":
                    lastPlayedSound = sound(split[1], registers);
                    break;
                case "set":
                    set(split[1], split[2], registers);
                    break;
                case "add":
                    add(split[1], split[2], registers);
                    break;
                case "mul":
                    multiply(split[1], split[2], registers);
                    break;
                case "mod":
                    modulo(split[1], split[2], registers);
                    break;
                case "rcv":
                    if (recover(split[1], registers))
                    {
                        return lastPlayedSound;
                    }
                    break;
                case "jgz":
                    long jumpAmount = jumpGreaterThanZero(split[1], split[2], registers);
                    if (jumpAmount < 0)
                    {
                        ii += (int)jumpAmount - 1;
                    }
                    else
                    {
                        ii += (int)jumpAmount;
                    }
                    break;
            }
        }

        throw new ArgumentException(nameof(instructions));
    }

    private long sound(
        string argument,
        IDictionary<string, long> registers)
    {
        return getValue(argument, registers);
    }

    private void set(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg2, registers);
    }

    private void add(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg1, registers) + getValue(arg2, registers);
    }

    private void multiply(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg1, registers) * getValue(arg2, registers);
    }

    private void modulo(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg1, registers) % getValue(arg2, registers);
    }

    private bool recover(
        string arg1,
        IDictionary<string, long> registers)
    {
        return getValue(arg1, registers) != 0;
    }

    private long jumpGreaterThanZero(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        if (getValue(arg1, registers) > 0)
        {
            return getValue(arg2, registers);
        }

        else
        {
            return 0;
        }
    }

    private long getValue(
        string arg,
        IDictionary<string, long> registers)
    {
        if (long.TryParse(arg, out long immediateValue))
        {
            return immediateValue;
        }

        else
        {
            registers.TryGetValue(arg, out long registerValue);
            return registerValue;
        }
    }
}
