namespace advent_of_code_2017.Day20;
internal class Day20 : AdventSolution
{
    protected override long part1Work(string[] input)
    {
        var particles = new List<Particle>();

        for (int ii = 0; ii < input.Length; ii++)
        {
            particles.Add(new Particle(ii, input[ii]));
        }

        for (int ii = 0; ii < 500; ii++)
        {
            foreach (var particle in particles)
            {
                particle.Update();
            }
        }

        return particles
            .OrderBy(x => x.GetManhattanDistance())
            .First()
            .Id;
    }

    protected override long part1ExampleExpected => 0;
    protected override long part1InputExpected => 258;
    protected override long part2Work(string[] input)
    {
        throw new NotImplementedException();
    }

    protected override long part2ExampleExpected { get; }
    protected override long part2InputExpected { get; }
}
