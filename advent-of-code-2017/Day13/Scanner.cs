namespace advent_of_code_2017.Day13;
internal class Scanner
{
    public int Index { get; private set; }
    int direction = 1;

    public readonly int Range;
    public bool Detected { get { return Index == 0; } }

    public Scanner(int range)
    {
        Range = range;
    }
 
    public void Update()
    {
        Index += direction;

        if (Index == 0 || Index == Range - 1)
        {
            direction *= -1;
        }
    }
}
