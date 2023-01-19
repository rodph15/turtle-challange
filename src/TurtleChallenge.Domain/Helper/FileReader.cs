using Newtonsoft.Json;
using TurtleChallenge.Domain.Configs;

namespace TurtleChallenge.Domain.Helper;

public static class FileReader
{
    public static async Task<GameSettings?> ReadGameSettingsAsync(string fileName)
    {
        var jsonString = await File.ReadAllTextAsync(fileName);
        return JsonConvert.DeserializeObject<GameSettings>(jsonString);
    }

    public static async Task<MoveSequence?> ReadMoveSequenceAsync(string fileName)
    {
        var jsonString = await File.ReadAllTextAsync(fileName);
        return JsonConvert.DeserializeObject<MoveSequence>(jsonString);
    }
}