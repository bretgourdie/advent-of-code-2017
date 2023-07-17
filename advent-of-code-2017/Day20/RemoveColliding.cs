namespace advent_of_code_2017.Day20;
internal class RemoveColliding : IRemovalStrategy
{
    public void Remove(IEnumerable<Particle> particles)
    {
        foreach (var particle in particles.Where(x => !x.Collided))
        {
            var colliding = particles.Where(
                x => x.Id != particle.Id
                     && x.Position.Equals(particle.Position)
                     && !x.Collided);

            if (colliding.Any())
            {
                foreach (var collided in colliding)
                {
                    collided.MarkCollided();
                }

                particle.MarkCollided();
            }
        }
    }

    public long GetAnswer(IEnumerable<Particle> particles) => particles.Count(x => !x.Collided);
}
