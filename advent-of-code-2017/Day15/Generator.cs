namespace advent_of_code_2017.Day15;
internal class Generator
{
    private static readonly IDictionary<string, long> GeneratorToFactors =
        new Dictionary<string, long>()
        {
            {"A", 16807},
            {"B", 48271}
        };

    private static readonly IDictionary<string, Func<long, bool>> GeneratorToConditions =
        new Dictionary<string, Func<long, bool>>()
        {
            {"A", x => x % 4 == 0 },
            {"B", x => x % 8 == 0 }
        };

    private readonly long factor;
    private readonly bool useCondition;
    private const long divisor = 2147483647;
    private Func<long, bool> condition;

    private long lastValue;

    public Generator(
        string line,
        bool useCondition)
    {
        var split = line.Split(" starts with ");
        var generator = split[0].Replace("Generator ", String.Empty);
        factor = Generator.GeneratorToFactors[generator];

        var startValue = long.Parse(split[1]);
        lastValue = startValue;

        this.useCondition = useCondition;
        this.condition = Generator.GeneratorToConditions[generator];
    }

    public long Generate()
    {
        long remainder;

        do
        {
            var next = lastValue * factor;

            remainder = next % divisor;

            lastValue = remainder;
        } while (this.useCondition && !this.condition(remainder));

        return remainder;
    }
}
