namespace advent_of_code_2017.Day20;
internal interface IRemovalStrategy
{
    void Remove(IEnumerable<Particle> particles);
    long GetAnswer(IEnumerable<Particle> particles);

    bool ShouldConsider(Particle particle);
}
