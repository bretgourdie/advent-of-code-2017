using System.Data;

namespace advent_of_code_2017.Day08;
internal class Instruction
{
    readonly string TargetRegister;
    readonly TargetOperation TheTargetOperation;
    readonly long Immediate;

    readonly string If;
    readonly string SourceRegister;
    readonly string ComparisonOperator;
    readonly long ComparisonImmediate;


    public Instruction(string line)
    {
        var split = line.Split(' ');

        TargetRegister = split[0];
        TheTargetOperation = Enum.Parse<TargetOperation>(split[1]);
        Immediate = long.Parse(split[2]);

        If = split[3];
        SourceRegister = split[4];
        ComparisonOperator = split[5];
        ComparisonImmediate = long.Parse(split[6]);
    }

    public void Affect(IDictionary<string, long> registers)
    {
        var conditionsWereMet = conditionMet(
            getRegisterValue(registers, SourceRegister),
            ComparisonOperator,
            ComparisonImmediate);

        if (conditionsWereMet)
        {
            var targetValue = getRegisterValue(registers, TargetRegister);
            var toAdd = getChange(TheTargetOperation, Immediate);

            registers[TargetRegister] = targetValue + toAdd;
        }
    }

    private long getChange(TargetOperation targetOperation, long value)
    {
        switch (targetOperation)
        {
            case TargetOperation.inc: return value;
            case TargetOperation.dec: return value * -1;
            default:
                throw new ArgumentException(nameof(TargetOperation));
        }
    }

    private long getRegisterValue(IDictionary<string, long> registers, string register) =>
        registers.ContainsKey(register)
            ? registers[register]
            : 0;

    private bool conditionMet(
        long value,
        string comparisonOperator,
        long comparisonImmediate)
    {
        var dt = new DataTable();
        var expression = value.ToString() + comparisonOperator + comparisonImmediate.ToString();
        bool answer = (bool)dt.Compute(expression, String.Empty);
        return answer;
    }

    private enum TargetOperation
    {
        inc,
        dec
    }
}
