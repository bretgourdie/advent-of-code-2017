namespace advent_of_code_2017.Day09;
internal class Day09 : AdventSolution
{
    const char groupStart = '{';
    const char groupEnd = '}';
    const char garbageStart = '<';
    const char garbageEnd = '>';
    const char cancelNext = '!';

    protected override long part1ExampleExpected => 9;

    protected override long part1InputExpected => 10616;

    protected override long part2ExampleExpected => 0;

    protected override long part2InputExpected => 5101;

    private long work(string[] input, Func<long, long, long> returnStrategy)
    {
        var line = input.Single();
        var stack = new Stack<char>();
        long garbageCharacters = 0;

        foreach (var letter in line)
        {
            if (peekIfAny(stack) == garbageStart)
            {
                if (letter == garbageEnd)
                {
                    stack.Pop();
                }

                else if (letter == cancelNext)
                {
                    stack.Push(cancelNext);
                }

                else
                {
                    garbageCharacters += 1;
                }
            }

            else if (peekIfAny(stack) == cancelNext)
            {
                stack.Pop();
            }

            else
            {
                stack.Push(letter);
            }
        }

        long score = 0;
        long level = 0;
        while (stack.Any())
        {
            var letter = stack.Pop();

            if (letter == groupStart)
            {
                score += level;
                level -= 1;
            }

            else if (letter == groupEnd)
            {
                level += 1;
            }
        }

        return returnStrategy(score, garbageCharacters);
    }

    private char peekIfAny(Stack<char> stack)
    {
        if (!stack.Any()) return default(char);
        return stack.Peek();
    }

    private long returnScore(long score, long garbageCharacters) => score;

    private long returnGarbageCharacters(long score, long garbageCharacters) => garbageCharacters;

    protected override long part1Work(string[] input) => work(input, returnScore);

    protected override long part2Work(string[] input) => work(input, returnGarbageCharacters);
}
