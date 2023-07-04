namespace advent_of_code_2017.Day13;
internal class Scanner
{
    public readonly int Range;

    public Scanner(int range)
    {
        Range = range;
    }
 
    public bool WillBeCaught(
        int step,
        int delay)
    {
        int currentStep = step + delay;
        int cycle = (Range * 2) - 2;
        return currentStep % cycle == 0;
    }
}
