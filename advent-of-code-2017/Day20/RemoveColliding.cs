namespace advent_of_code_2017.Day20;
internal class RemoveColliding : IRemovalStrategy
{
    public IEnumerable<Particle> Remove(IEnumerable<Particle> particles)
    {
        var toRemove = new HashSet<long>();

        foreach (var particle in particles)
        {
            foreach (var other in particles.Where(x => x.Id != particle.Id))
            {
                if (particle.Position.Equals(other.Position))
                {
                    toRemove.Add(particle.Id);
                    toRemove.Add(other.Id);
                }
            }
        }

        return particles
            .Where(x => !toRemove.Contains(x.Id));
    }

    public long GetAnswer(IEnumerable<Particle> particles) => particles.Count();
}
