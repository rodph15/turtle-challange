using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Domain.Entities;

public sealed class Turtle : Quadrant, ITurtle
{
    private readonly IBoard _board;
    private Direction _headingTo = Direction.Up;

    public Turtle(Point position, IBoard board)
    {
        _board = board;
        Position = position;
    }

    public void Rotate()
    {
        _headingTo = _headingTo switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            _ => _headingTo
        };
    }

    public void Move()
    {
        Position = _headingTo switch
        {
            Direction.Up => TryMove(Position with { Y = Position.Y - 1 }) ?? Position,
            Direction.Down => TryMove(Position with { Y = Position.Y + 1 }) ?? Position,
            Direction.Right => TryMove(Position with { X = Position.X + 1 }) ?? Position,
            Direction.Left => TryMove(Position with { X = Position.X - 1 }) ?? Position,
            _ => Position
        };
    }

    private Point? TryMove(Point point)
    {
        try
        {
            _ = _board.GetBoard()[point.Y, point.X];
            return point;
        }
        catch
        {
            Console.WriteLine("cannot move out of quadrant!");
            return null;
        }
    }
}