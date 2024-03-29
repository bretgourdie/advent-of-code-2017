﻿namespace advent_of_code_2017.Day20;
internal class Day20 : AdventSolution
{
    private const int iterations = 400;

    protected long work(
        string[] input,
        IRemovalStrategy strategy)
    {
        var particles = new List<Particle>();

        for (int ii = 0; ii < input.Length; ii++)
        {
            particles.Add(new Particle(ii, input[ii]));
        }

        for (int ii = 0; ii < iterations; ii++)
        {
            foreach (var particle in particles)
            {
                particle.Update();
            }

            var remainingParticles = strategy.Remove(particles);
            if (particles.Count > remainingParticles.Count())
            {
                particles = remainingParticles.ToList();
            }
        }

        return strategy.GetAnswer(particles);
    }

    protected override long part1Work(string[] input) =>
        work(input, new DoNotRemove());

    protected override long part1ExampleExpected => 3;
    protected override long part1InputExpected => 258;
    protected override long part2Work(string[] input) =>
        work(input, new RemoveColliding());

    protected override long part2ExampleExpected => 1;
    protected override long part2InputExpected => 707;
}
