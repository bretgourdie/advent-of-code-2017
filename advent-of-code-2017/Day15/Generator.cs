namespace advent_of_code_2017.Day15;
internal class Generator
{
    private static readonly IDictionary<string, long> GeneratorToFactors =
        new Dictionary<string, long>()
        {
            {"A", 16807},
            {"B", 48271}
        };

    private readonly long factor;
    private const long divisor = 2147483647;

    private long lastValue;

    public Generator(string line)
    {
        var split = line.Split(" starts with ");
        var generator = split[0].Replace("Generator ", String.Empty);
        factor = Generator.GeneratorToFactors[generator];

        var startValue = long.Parse(split[1]);
        lastValue = startValue;
    }

    public long Generate()
    {
        var next = lastValue * factor;

        var remainder = next % divisor;

        lastValue = remainder;

        return remainder;
    }
}
