using TurtleChallenge.Domain.Entities;

namespace TurtleChallenge.Domain.Configs;

public class GameSettings
{
    public int BoardWidth { get; set; }
    public int BoardHeight { get; set; }
    public Point StartingPoint { get; set; }
    public Exit? ExitPoint { get; set; }
    public List<Mine>? Mines { get; set; }
}