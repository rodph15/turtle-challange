using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Helper;
using TurtleChallenge.Domain.Services;

const string gameSettingsFile = "GameSettings.json"; //args[0];
const string movesFile = "MovesWin.json"; //args[1];

var gameSettings = await FileReader.ReadGameSettingsAsync(gameSettingsFile);
var moveSequences = await FileReader.ReadMoveSequenceAsync(movesFile);

var board = new Board(gameSettings!);
var turtle = new Turtle(gameSettings!.StartingPoint, board);

var game = new GameService(board, turtle);

game.PlayMoveSequence(moveSequences!.Moves!);