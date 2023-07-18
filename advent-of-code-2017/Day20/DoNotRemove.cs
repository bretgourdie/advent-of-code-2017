namespace advent_of_code_2017.Day20;

internal class DoNotRemove : IRemovalStrategy
{
    public void Remove(IEnumerable<Particle> particles) { }

    public long GetAnswer(IEnumerable<Particle> particles)
    {
        return particles
            .OrderBy(x => x.GetManhattanDistance())
            .First()
            .Id;
    }

    public bool ShouldConsider(Particle particle) => true;
}
