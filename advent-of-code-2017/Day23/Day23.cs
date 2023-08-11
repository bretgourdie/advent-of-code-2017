using System.Text;

namespace advent_of_code_2017.Day23;
internal class Day23 : AdventSolution
{
    protected override long part1Work(string[] input)
    {
        int ii = 0;
        var registers = initializeRegisters();
        long numberOfMultiples = 0;

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
                    numberOfMultiples += 1;
                    break;
                case "jnz":
                    jumpAmount = (int)jumpNotEqualToZero(split[1], split[2], registers);
                    break;
                default:
                    throw new ArgumentException(nameof(input));
            }

            ii += jumpAmount == 0 ? 1 : jumpAmount;
        }

        return numberOfMultiples;
    }

    private IDictionary<string, long> initializeRegisters()
    {
        var registers = new Dictionary<string, long>();

        for (int ii = 0; ii < 8; ii++)
        {
            registers[('a' + ii).ToString()] = 0;
        }

        return registers;
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

    protected override long part2Work(string[] input)
    {
        long numberOfCompositeNumbers = 0;

        long start = 67 * 100 + 100_000;
        long end = start + 17_000;

        for (long testing = start; testing <= end; testing += 17)
        {
            var isComposite = false;
            for (long divisor = 2; divisor < testing && !isComposite; divisor++)
            {
                isComposite |= testing % divisor == 0;
            }

            if (isComposite)
            {
                numberOfCompositeNumbers += 1;
            }
        }

        return numberOfCompositeNumbers;
    }

    protected override long part1ExampleExpected => 2;
    protected override long part1InputExpected => 4225;

    protected override long part2ExampleExpected => 905;
    protected override long part2InputExpected => 905;
}
