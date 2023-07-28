namespace advent_of_code_2017.Day25;
internal class Tape
{
    private readonly ISet<long> setValues;
    private long cursor;

    public Tape()
    {
        setValues = new HashSet<long>();
        cursor = 0;
    }

    public void Move(int direction)
    {
        cursor += direction;
    }

    public void Write(int value)
    {
        if (value == 0)
        {
            setValues.Remove(cursor);
        }

        else
        {
            setValues.Add(cursor);
        }
    }

    public int Read()
    {
        if (!setValues.Contains(cursor))
        {
            return 0;
        }

        return 1;
    }

    public long Checksum() => setValues.Count;
}
