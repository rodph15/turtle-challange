using Moq;
using TurtleChallenge.Domain.Interfaces;
using TurtleChallenge.Domain.Services;
using Xunit;

namespace TurtleChallenge.Tests.Domain.Services;

public class GameServicesTests
{
    private GameService? _gameService;
    private Mock<IBoard>? _mockBoard;
    private Mock<ITurtle>? _mockTurtle;

    [Fact]
    public void PlayMoveSequence_ShouldMoveTurtleCorrectly()
    {
        // Arrange
        var grid = new[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };

        _mockBoard = new Mock<IBoard>();
        _mockTurtle = new Mock<ITurtle>();
        _gameService = new GameService(_mockBoard.Object, _mockTurtle.Object);
        var moveSequence = new List<string> { "r", "m", "r", "m" };
        _mockBoard.Setup(b => b.GetBoard())
            .Returns(grid);

        // Act
        _gameService.PlayMoveSequence(moveSequence);

        // Assert
        _mockTurtle.Verify(t => t.Rotate(), Times.Exactly(2));
        _mockTurtle.Verify(t => t.Move(), Times.Exactly(2));
    }
}