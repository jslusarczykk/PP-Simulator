using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Simulator.Tests
{
    public class PointTest
    {
        [Fact]
        public void Constructor_ShouldInitializeCoordinatesCorrectly()
        {
            // Arrange
            int x = 3;
            int y = 5;

            // Act
            GridPoint point = new GridPoint(x, y);

            // Assert
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            GridPoint point = new GridPoint(4, -2);

            // Act
            string result = point.ToString();

            // Assert
            Assert.Equal("(4, -2)", result);
        }

        [Theory]
        [InlineData(0, 0, Direction.Right, 1, 0)]
        [InlineData(0, 0, Direction.Left, -1, 0)]
        [InlineData(0, 0, Direction.Up, 0, 1)]
        [InlineData(0, 0, Direction.Down, 0, -1)]
        public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            GridPoint point = new GridPoint(x, y);

            // Act
            GridPoint nextPoint = point.Next(direction);

            // Assert
            Assert.Equal(expectedX, nextPoint.X);
            Assert.Equal(expectedY, nextPoint.Y);
        }

        [Theory]
        [InlineData(0, 0, Direction.Right, 1, -1)]
        [InlineData(0, 0, Direction.Left, -1, 1)]
        [InlineData(0, 0, Direction.Up, 1, 1)]
        [InlineData(0, 0, Direction.Down, -1, -1)]
        public void NextDiagonal_ShouldReturnCorrectNextDiagonalPoint(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            GridPoint point = new GridPoint(x, y);

            // Act
            GridPoint nextDiagonalPoint = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(expectedX, nextDiagonalPoint.X);
            Assert.Equal(expectedY, nextDiagonalPoint.Y);
        }
    }
}
