namespace advent_of_code_2017.Day20;
internal class RemoveColliding : IRemovalStrategy
{
    public IEnumerable<Particle> Remove(IEnumerable<Particle> particles)
    {
        var toRemove = new Dictionary<Vector3, IList<long>>();

        foreach (var particle in particles)
        {
            if (!toRemove.ContainsKey(particle.Position))
            {
                toRemove[particle.Position] = new List<long>();
            }
            toRemove[particle.Position].Add(particle.Id);
        }

        return particles
            .Where(x => toRemove[x.Position].Count == 1);
    }

    public long GetAnswer(IEnumerable<Particle> particles) => particles.Count();
}
