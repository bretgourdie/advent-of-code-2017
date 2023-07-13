namespace advent_of_code_2017.Day18;
internal abstract class Duet
{
    public abstract long Play(IList<string> instructions);

    protected long HandleInstruction(
        IList<string> instructions,
        Program program)
    {
        var instruction = instructions[program.InstructionCounter];

        var split = instruction.Split(' ');

        var instructionCode = split[0];

        int jumpAmount = 0;

        switch (instructionCode)
        {
            case "snd":
                snd(split[1], program);
                break;
            case "set":
                set(split[1], split[2], program);
                break;
            case "add":
                add(split[1], split[2], program);
                break;
            case "mul":
                multiply(split[1], split[2], program);
                break;
            case "mod":
                modulo(split[1], split[2], program);
                break;
            case "rcv":
                if (rcv(split[1], program))
                {
                    return GetAnswer();
                }
                break;
            case "jgz":
                jumpAmount =  (int)jumpGreaterThanZero(split[1], split[2], program);

                if (jumpAmount < 0)
                {
                    jumpAmount -= 1;
                }
                break;
        }

        program.InstructionCounter += 1 + jumpAmount;

        return 0;
    }

    protected abstract long GetAnswer();

    protected abstract void snd(string argument, Program program);

    protected void send(
        string argument,
        Queue<long> thisSendQueue,
        Program program)
    {
        thisSendQueue.Enqueue(getValue(argument, program.Registers));
    }

    protected long sound(
        string argument,
        Program program)
    {
        return getValue(argument, program.Registers);
    }

    protected void set(
        string arg1,
        string arg2,
        Program program)
    {
        program.Registers[arg1] = getValue(arg2, program.Registers);
    }

    protected void add(
        string arg1,
        string arg2,
        Program program)
    {
        program.Registers[arg1] = getValue(arg1, program.Registers) + getValue(arg2, program.Registers);
    }
    
    protected void multiply(
        string arg1,
        string arg2,
        Program program)
    {
        program.Registers[arg1] = getValue(arg1, program.Registers) * getValue(arg2, program.Registers);
    }

    protected void modulo(
        string arg1,
        string arg2,
        Program program)
    {
        program.Registers[arg1] = getValue(arg1, program.Registers) % getValue(arg2, program.Registers);
    }

    protected abstract bool rcv(string arg1, Program program);

    protected bool recover(
        string arg1,
        Program program)
    {
        return getValue(arg1, program.Registers) != 0;
    }

    protected bool receive(
        string argument,
        Program sender,
        Program receiver)
    {
        if (sender.HasAnythingInQueue())
        {
            receiver.Registers[argument] = sender.ConsumeSendBuffer();
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
        Program program)
    {
        if (getValue(arg1, program.Registers) > 0)
        {
            return getValue(arg2, program.Registers);
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
