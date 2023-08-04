namespace advent_of_code_2017.Day23;
internal class Day23 : AdventSolution
{
    protected override long part1Work(string[] input) =>
        work(input, new Debugging());

    private long work(string[] input, ICoProcessorStrategy strategy)
    {
        int ii = 0;
        var registers = strategy.InitializeRegisters();

        while (ii >= 0 && ii < input.Length)
        {
            var instruction = input[ii];
            var split = instruction.Split(' ');
            var instructionCode = split[0];

            int jumpAmount = 0;

            switch (instructionCode)
            {
                case "set":
                    set(split[1], split[2], registers);
                    break;
                case "sub":
                    subtract(split[1], split[2], registers);
                    break;
                case "mul":
                    multiply(split[1], split[2], registers);
                    break;
                case "jnz":
                    jumpAmount = (int)jumpNotEqualToZero(split[1], split[2], registers);
                    break;
                default:
                    throw new ArgumentException(nameof(input));
            }

            strategy.HandleInstructionProcessed(instructionCode);

            ii += jumpAmount == 0 ? 1 : jumpAmount;
        }

        return strategy.GetAnswer(registers);
    }

    private void set(
        string register,
        string registerOrValue,
        IDictionary<string, long> registers)
    {
        registers[register] = getValue(registerOrValue, registers);
    }

    private void subtract(
        string register,
        string registerOrValue,
        IDictionary<string, long> registers)
    {
        registers[register] -= getValue(registerOrValue, registers);
    }

    private void multiply(
        string register,
        string registerOrValue,
        IDictionary<string, long> registers)
    {
        registers[register] *= getValue(registerOrValue, registers);
    }

    private long jumpNotEqualToZero(
        string register,
        string registerOrValue,
        IDictionary<string, long> registers)
    {
        if (getValue(register, registers) != 0)
        {
            return getValue(registerOrValue, registers);
        }

        return 0;
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

    protected override long part1ExampleExpected => 2;
    protected override long part1InputExpected => 4225;

    protected override long part2Work(string[] input)
    {
        return originalProcedure();
    }

    private long reduced()
    {
        throw new NotImplementedException();
    }

    private long originalProcedure()
    {
        long
            a = 0,
            b = 0,
            c = 0,
            d = 0,
            e = 0,
            f = 0,
            g = 0,
            h = 0;

        a = 0;

        line_1: b = 67;
        line_2: c = b;
        line_3: if (a != 0) goto line_5;
        line_4: if (1 != 0) goto line_9;
        line_5: b *= 100;
        line_6: b -= -100_000;
        line_7: c = b;
        line_8: c -= -17_000;
        line_9: f = 1;
        line_10: d = 2;
        line_11: e = 2;
        line_12: g = d;
        line_13: g *= e;
        line_14: g -= b;
        line_15: if (g != 0) goto line_17;
        line_16: f = 0;
        line_17: e -= 1;
        line_18: g = e;
        line_19: g -= b;
        line_20: if (g != 0) goto line_12;
        line_21: d -= 1;
        line_22: g = d;
        line_23: g -= b;
        line_24: if(g != 0) goto line_11;
        line_25: if (f != 0) goto line_27;
        line_26: h -= -1;
        line_27: g = b;
        line_28: g -= c;
        line_29: if (g != 0) goto line_31;
        line_30: return h;
        line_31: b -= -17;
        line_32: if (1 != 0) goto line_9;
    }

    protected override long part2ExampleExpected => 0;
    protected override long part2InputExpected => -1;
}
