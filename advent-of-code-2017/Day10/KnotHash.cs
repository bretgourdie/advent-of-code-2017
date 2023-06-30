namespace advent_of_code_2017.Day10;
internal class KnotHash
{
    public long Hash(string line, int numbersLength)
    {
        return
            Hash(
                numbersLength,
                line
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToList()
            );

    }

    public long Hash(IList<int> lengths) => Hash(256, lengths);

    public long Hash(int numbersLength, IList<int> lengths)
    {
        var numbers = startingNumbers(numbersLength);
        var currentIndex = 0;

        for (int skipSize = 0; skipSize < lengths.Count; skipSize++)
        {
            var lengthSize = lengths[skipSize];

            var list = new List<int>();
            for (int ii = 0; ii < lengthSize; ii++)
            {
                var sliceIndex = (currentIndex + ii) % numbers.Length;
                list.Add(numbers[sliceIndex]);
            }

            list.Reverse();

            for (int ii = 0; ii < lengthSize; ii++)
            {
                var putIndex = (currentIndex + ii) % numbers.Length;
                numbers[putIndex] = list[ii];
            }

            currentIndex += lengthSize + skipSize;
        }

        return numbers[0] * numbers[1];
    }

    private int[] startingNumbers(int length) => startingNumberYields(length).ToArray();

    private IEnumerable<int> startingNumberYields(int length)
    {
        for (int ii = 0; ii < length; ii++)
        {
            yield return ii;
        }
    }
}
