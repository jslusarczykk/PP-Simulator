using System;
using System.Drawing;
using Xunit;

namespace RectangleTests
{
    public class RectangleTest
    {
        [Fact]
        public void Constructor_ShouldInitializeCoordinatesCorrectly_WhenValidPointsProvided()
        {
            // Arrange
            int x1 = 2, y1 = 3, x2 = 5, y2 = 7;

            // Act
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Assert
            Assert.Equal(2, rectangle.X1);
            Assert.Equal(3, rectangle.Y1);
            Assert.Equal(5, rectangle.X2);
            Assert.Equal(7, rectangle.Y2);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenRectangleIsThin()
        {
            // Arrange
            int x1 = 4, y1 = 4, x2 = 4, y2 = 8; // Vertical line

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
        }

        [Fact]
        public void Constructor_ShouldSortCoordinatesAutomatically()
        {
            // Arrange
            int x1 = 8, y1 = 6, x2 = 3, y2 = 1;

            // Act
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Assert
            Assert.Equal(3, rectangle.X1);
            Assert.Equal(1, rectangle.Y1);
            Assert.Equal(8, rectangle.X2);
            Assert.Equal(6, rectangle.Y2);
        }

        [Fact]
        public void Constructor_UsingPoints_ShouldInitializeCorrectly()
        {
            // Arrange
            var point1 = new Point(3, 3);
            var point2 = new Point(7, 10);

            // Act
            var rectangle = new Rectangle(point1, point2);

            // Assert
            Assert.Equal(3, rectangle.X1);
            Assert.Equal(3, rectangle.Y1);
            Assert.Equal(7, rectangle.X2);
            Assert.Equal(10, rectangle.Y2);
        }

        [Theory]
        [InlineData(3, 3, 7, 10, 5, 5, true)]  // Inside rectangle
        [InlineData(3, 3, 7, 10, 3, 3, true)]  // On top-left corner
        [InlineData(3, 3, 7, 10, 7, 10, true)] // On bottom-right corner
        [InlineData(3, 3, 7, 10, 8, 5, false)] // Outside rectangle
        public void Contains_ShouldReturnCorrectResult(
            int x1, int y1, int x2, int y2, int px, int py, bool expected)
        {
            // Arrange
            var rectangle = new Rectangle(x1, y1, x2, y2);
            var point = new Point(px, py);

            // Act
            bool result = rectangle.Contains(point);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
