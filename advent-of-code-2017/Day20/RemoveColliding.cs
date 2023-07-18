namespace advent_of_code_2017.Day20;
internal class RemoveColliding : IRemovalStrategy
{
    public void Remove(IEnumerable<Particle> particles)
    {
        foreach (var particle in particles.Where(x => ShouldConsider(x)))
        {
            foreach (var other in particles.Where(x => ShouldConsider(x) && x.Id != particle.Id))
            {
                if (particle.Position.Equals(other.Position))
                {
                    particle.MarkCollided();
                    other.MarkCollided();
                }
            }
        }
    }

    public long GetAnswer(IEnumerable<Particle> particles) => particles.Count(x => !x.Collided);

    public bool ShouldConsider(Particle particle) => !particle.Collided;
}
