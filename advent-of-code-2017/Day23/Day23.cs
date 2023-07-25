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

    protected override long part2Work(string[] input) =>
        work(input, new Troubleshooting());

    protected override long part2ExampleExpected => 0;
    protected override long part2InputExpected => -1;
}
