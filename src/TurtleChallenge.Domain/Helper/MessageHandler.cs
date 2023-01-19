using TurtleChallenge.Domain.Enums;

namespace TurtleChallenge.Domain.Helper;

public class MessageHandler
{
    private static readonly MessageHandler Instance = new();
    private readonly Dictionary<int, Func<bool>> _messageDictionary;

    private MessageHandler()
    {
        _messageDictionary = new Dictionary<int, Func<bool>>
        {
            { (int)PositionMove.Safe, Safe },
            { (int)PositionMove.Exit, Win },
            { (int)PositionMove.Mine, Dead }
        };
    }

    public static MessageHandler GetInstance()
    {
        return Instance;
    }

    public bool CheckMove(int positionMove)
    {
        return _messageDictionary[positionMove].Invoke();
    }

    private static bool Safe()
    {
        Console.WriteLine("safe");
        return true;
    }

    private static bool Dead()
    {
        Console.WriteLine("dead");
        return false;
    }

    private static bool Win()
    {
        Console.WriteLine("Win");
        return false;
    }
}