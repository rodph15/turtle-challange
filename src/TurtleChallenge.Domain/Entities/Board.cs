using TurtleChallenge.Domain.Configs;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Domain.Entities;

public sealed class Board : IBoard
{
    private readonly int[,] _grid;

    public Board(GameSettings gameSettings)
    {
        _grid = new int[gameSettings.BoardHeight, gameSettings.BoardWidth];
        SetMines(gameSettings.Mines!.ToArray());
        SetExit(gameSettings.ExitPoint!);
    }

    public int[,] GetBoard()
    {
        return _grid;
    }

    private void SetMines(params Mine[] mines)
    {
        foreach (var mine in mines) _grid[mine.Position.Y, mine.Position.X] = (int)PositionMove.Mine;
    }

    private void SetExit(Exit exit)
    {
        _grid[exit.Position.Y, exit.Position.X] = (int)PositionMove.Exit;
    }
}