using System.Collections.Generic;

namespace advent_of_code_2017.Day04;

internal class Day04 : AdventSolution
{
    protected override long part1ExampleExpected => 7;

    protected override long part1InputExpected => 325;

    protected override long part2ExampleExpected => 5;

    protected override long part2InputExpected => 119;

    private long work(string[] input, Func<string, string> phraseTransform)
    {
        long validPassphrases = 0;

        foreach (var line in input)
        {
            var valid = true;
            var set = new HashSet<string>();

            foreach (var phrase in line.Split(' '))
            {
                var transformed = phraseTransform(phrase);

                valid &= !set.Contains(transformed);

                if (!set.Contains(transformed))
                {
                    set.Add(transformed);
                }
            }

            if (valid)
            {
                validPassphrases += 1;
            }
        }

        return validPassphrases;
    }

    private string duplicateDetection(string phrase)
    {
        return phrase;
    }

    private string anagramDetection(string phrase)
    {
        return new string(phrase.Select(x => x).OrderBy(x => x).ToArray());
    }

    protected override long part1Work(string[] input)
    {
        return work(input, duplicateDetection);
    }

    protected override long part2Work(string[] input)
    {
        return work(input, anagramDetection);
    }
}
