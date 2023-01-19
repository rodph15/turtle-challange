using FluentAssertions;
using Moq;
using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Interfaces;
using Xunit;

namespace TurtleChallenge.Tests.Domain.Entities;

public class TurtleTests
{
    private Mock<IBoard>? _mockBoard;
    private Turtle? _turtle;

    [Fact]
    public void Move_ShouldMoveLeft()
    {
        // Arrange
        var grid = new[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
        _mockBoard = new Mock<IBoard>();
        _turtle = new Turtle(new Point(1, 1), _mockBoard.Object);
        _mockBoard.Setup(b => b.GetBoard())
            .Returns(grid);
        // Act
        _turtle.Rotate();
        _turtle.Rotate();
        _turtle.Rotate();
        _turtle.Move();

        // Assert
        _turtle.Position.Should().Be(new Point(0, 1));
    }

    [Fact]
    public void Move_ShouldMoveDown()
    {
        // Arrange
        var grid = new[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
        _mockBoard = new Mock<IBoard>();
        _turtle = new Turtle(new Point(0, 1), _mockBoard.Object);
        _mockBoard.Setup(b => b.GetBoard())
            .Returns(grid);
        // Act
        _turtle.Rotate();
        _turtle.Rotate();
        _turtle.Move();

        // Assert
        _turtle.Position.Should().Be(new Point(0, 2));
    }

    [Fact]
    public void Move_ShouldMoveRight()
    {
        // Arrange
        var grid = new[,] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
        _mockBoard = new Mock<IBoard>();
        _turtle = new Turtle(new Point(0, 1), _mockBoard.Object);
        _mockBoard.Setup(b => b.GetBoard())
            .Returns(grid);
        // Act
        _turtle.Rotate();
        _turtle.Move();

        // Assert
        _turtle.Position.Should().Be(new Point(1, 1));
    }

    [Fact]
    public void Move_ShouldMoveUp()
    {
        // Arrange
        var grid = new[,] { { 1, 1 } };
        _mockBoard = new Mock<IBoard>();
        _turtle = new Turtle(new Point(0, 1), _mockBoard.Object);
        _mockBoard.Setup(b => b.GetBoard())
            .Returns(grid);
        // Act
        _turtle.Move();

        // Assert
        _turtle.Position.Should().Be(new Point(0, 0));
    }

    [Fact]
    public void Move_ShouldNotMoveTurtleOutOfBoard()
    {
        // Arrange
        _mockBoard = new Mock<IBoard>();
        _turtle = new Turtle(new Point(0, 0), _mockBoard.Object);
        _mockBoard.Setup(b => b.GetBoard())
            .Throws<IndexOutOfRangeException>();

        // Act
        _turtle.Move();

        // Assert
        _turtle.Position.Should().Be(new Point(0, 0));
    }
}