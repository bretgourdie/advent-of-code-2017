namespace advent_of_code_2017.Day16;
internal class DanceLine
{
    private IList<char> programs = new List<char>();
    private readonly int lastIndex;

    public DanceLine(int length)
    {
        const char start = 'a';

        for (int ii = 0; ii < length; ii++)
        {
            programs.Add((char)(start + ii));
        }

        lastIndex = programs.Count - 1;
    }

    public void Handle(string instruction)
    {
        var firstLetter = instruction.First();
        var rest = instruction.Substring(1);
        var split = rest.Split("/");

        switch (firstLetter)
        {
            case 's':
                Spin(int.Parse(split[0]));
                break;
            case 'x':
                Exchange(
                    int.Parse(split[0]),
                    int.Parse(split[1]));
                break;
            case 'p':
                Partner(
                    split[0][0],
                    split[1][0]);
                break;
            default:
                throw new ArgumentException(nameof(instruction));
        }
    }

    public void Spin(int n)
    {
        for (int ii = 0; ii < n; ii++)
        {
            var toRemove = programs[lastIndex];
            programs.RemoveAt(lastIndex);
            programs.Insert(0, toRemove);
        }
    }

    public void Exchange(int positionA, int positionB)
    {
        var temp = programs[positionA];
        programs[positionA] = programs[positionB];
        programs[positionB] = temp;
    }

    public void Partner(char programA, char programB) =>
        Exchange(programs.IndexOf(programA), programs.IndexOf(programB));

    public override string ToString()
    {
        return String.Join(String.Empty, programs);
    }
}
