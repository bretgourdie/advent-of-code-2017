using System.Text;

namespace advent_of_code_2017.Common;
internal class KnotHash
{
    private readonly int[] standardLengthSuffixValues =
        new[] { 17, 31, 73, 47, 23 };

    private const int sparseHashRounds = 64;
    private const int sparseHashLength = 256;
    private const int denseHashLength = 16;

    public long PracticeHash(int numbersLength, string line)
    {
        var split = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
        var lengths = split.Select(x => int.Parse(x)).ToList();

        var result = getSparseHash(numbersLength, lengths, 1);

        return result[0] * result[1];
    }

    public string Hash(string line)
    {
        var lengths = getLengths(line);

        var sparseHash = getSparseHash(sparseHashLength, lengths, sparseHashRounds);

        var denseHash = getDenseHash(sparseHash);

        var hexString = getHexString(denseHash);

        return hexString;
    }

    private string getHexString(int[] denseHash)
    {
        var hexBuilder = new StringBuilder();

        foreach (var number in denseHash)
        {
            var hex = number.ToString("x2");
            hexBuilder.Append(hex);
        }

        return hexBuilder.ToString();
    }

    private int[] getDenseHash(int[] sparseHash)
    {
        int[] denseHash = new int[denseHashLength];

        for (int denseHashChunkStart = 0; denseHashChunkStart < denseHashLength; denseHashChunkStart += 1)
        {
            var result = sparseHash[denseHashChunkStart * denseHashLength];

            for (int ii = 1; ii < denseHashLength; ii++)
            {
                result ^= sparseHash[denseHashChunkStart * denseHashLength + ii];
            }

            denseHash[denseHashChunkStart] = result;
        }

        return denseHash;
    }

    private IList<int> getLengths(string line)
    {
        var lengths = line.Select(x => (int)x).ToList();
        lengths.AddRange(standardLengthSuffixValues);
        return lengths;
    }

    private int[] getSparseHash(
        int numbersLength,
        IList<int> lengths,
        int numberOfRounds)
    {
        var numbers = startingNumbers(numbersLength);
        var currentIndex = 0;
        var skipSize = 0;

        for (int round = 0; round < numberOfRounds; round++)
        {
            for (int lengthIteration = 0; lengthIteration < lengths.Count; lengthIteration++)
            {
                var lengthSize = lengths[lengthIteration];

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
                skipSize += 1;
            }
        }

        return numbers;
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
