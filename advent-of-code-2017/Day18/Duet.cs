namespace advent_of_code_2017.Day18;
internal abstract class Duet
{
    public abstract long Play(IList<string> instructions);

    protected long HandleInstruction(
        string instruction,
        IDictionary<string, long> registers,
        out int jumpAmount)
    {
        jumpAmount = 0;

        var split = instruction.Split(' ');

        var instructionCode = split[0];

        switch (instructionCode)
        {
            case "snd":
                snd(split[1], registers);
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
                if (rcv(split[1], registers))
                {
                    return GetAnswer();
                }
                break;
            case "jgz":
                jumpAmount =  (int)jumpGreaterThanZero(split[1], split[2], registers);
                break;
        }

        return 0;
    }

    protected abstract long GetAnswer();

    protected abstract void snd(string argument, IDictionary<string, long> registers);

    protected void send(
        string argument,
        Queue<long> thisSendQueue,
        IDictionary<string, long> registers)
    {
        thisSendQueue.Enqueue(getValue(argument, registers));
    }

    protected long sound(
        string argument,
        IDictionary<string, long> registers)
    {
        return getValue(argument, registers);
    }

    protected void set(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg2, registers);
    }

    protected void add(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg1, registers) + getValue(arg2, registers);
    }
    
    protected void multiply(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg1, registers) * getValue(arg2, registers);
    }

    protected void modulo(
        string arg1,
        string arg2,
        IDictionary<string, long> registers)
    {
        registers[arg1] = getValue(arg1, registers) % getValue(arg2, registers);
    }

    protected abstract bool rcv(string arg1, IDictionary<string, long> registers);

    protected bool recover(
        string arg1,
        IDictionary<string, long> registers)
    {
        return getValue(arg1, registers) != 0;
    }

    protected bool receive(
        string argument,
        Queue<long> otherSendQueue,
        IDictionary<string, long> registers)
    {
        if (otherSendQueue.Any())
        {
            registers[argument] = otherSendQueue.Dequeue();
            return true;
        }

        else
        {
            return false;
        }
    }

    protected long jumpGreaterThanZero(
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
