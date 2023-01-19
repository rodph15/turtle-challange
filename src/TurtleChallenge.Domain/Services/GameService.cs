using TurtleChallenge.Domain.Helper;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Domain.Services;

public class GameService
{
    private readonly IBoard _board;
    private readonly ITurtle _turtle;

    public GameService(IBoard board, ITurtle turtle)
    {
        _board = board;
        _turtle = turtle;
    }

    public void PlayMoveSequence(List<string> moveSequence)
    {
        foreach (var move in moveSequence)
        {
            if (move == "r")
            {
                _turtle.Rotate();
                continue;
            }

            _turtle.Move();

            var positionMove = _board.GetBoard()[_turtle.Position.Y, _turtle.Position.X];

            if (!MessageHandler.GetInstance().CheckMove(positionMove)) break;
        }
    }
}