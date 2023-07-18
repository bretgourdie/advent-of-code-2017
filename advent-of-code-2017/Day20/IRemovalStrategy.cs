namespace advent_of_code_2017.Day20;
internal interface IRemovalStrategy
{
    IEnumerable<Particle> Remove(IEnumerable<Particle> particles);
    long GetAnswer(IEnumerable<Particle> particles);
}
