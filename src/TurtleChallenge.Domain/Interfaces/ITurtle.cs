using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Interfaces;

public interface ITurtle
{
    public Point Position { get; set; }
    public void Rotate();
    public void Move();
}