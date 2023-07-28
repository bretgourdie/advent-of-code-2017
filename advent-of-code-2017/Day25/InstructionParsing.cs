namespace advent_of_code_2017.Day25;
internal static class InstructionParsing
{
    public static int GetIntegerValueBetween(
        this string wholeString,
        string prefix,
        string suffix)
    {
        return int.Parse(wholeString.GetValueBetween(prefix, suffix));
    }

    public static long GetLongValueBetween(
        this string wholeString,
        string prefix,
        string suffix)
    {
        return long.Parse(wholeString.GetValueBetween(prefix, suffix));
    }

    public static string GetValueBetween(
        this string wholeString,
        string prefix,
        string suffix)
    {
        return wholeString.Substring(
            prefix.Length,
            wholeString.LastIndexOf(suffix, StringComparison.Ordinal) - prefix.Length);
    }
}
