using System;
using Xunit;

namespace Simulator.Tests
{
    public class ValidatorTest
    {
        // Testy dla Limiter
        [Theory]
        [InlineData(5, 1, 10, 5)]  // Wartość w zakresie
        [InlineData(0, 1, 10, 1)]  // Wartość poniżej minimum
        [InlineData(15, 1, 10, 10)] // Wartość powyżej maksimum
        [InlineData(10, 10, 10, 10)] // Minimalny zakres
        public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
        {
            // Act
            int result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Limiter_ShouldHandleReversedBounds()
        {
            // Arrange
            int value = 5;
            int min = 10;
            int max = 1;

            // Act
            int result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(5, result); // Math.Clamp automatycznie poprawia zakres
        }

        // Testy dla Shortener
        [Theory]
        [InlineData("test", 3, 5, '-', "test")]   // Krótkie słowo, powinno się wydłużyć
        [InlineData("test", 3, 5, '*', "test")]   // Krótkie słowo z innym placeholderem
        [InlineData("verylongword", 3, 5, '-', "veryl")] // Długie słowo, powinno się skrócić
        [InlineData("  test  ", 3, 5, '-', "test")]     // Słowo z białymi znakami, powinno zostać przycięte
        [InlineData(null, 3, 5, '-', "---")]       // Wartość null, powinien być placeholder
        public void Shortener_ShouldReturnCorrectValue(string value, int min, int max, char placeholder, string expected)
        {
            // Act
            string result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Shortener_ShouldHandleReversedBounds()
        {
            // Arrange
            string value = "test";
            int min = 5;
            int max = 3;
            char placeholder = '-';

            // Act
            string result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal("test", result); // Reversed bounds powinny działać
        }

        [Theory]
        [InlineData("", 5, 10, '-', "-----")]  // Pusty string, powinien być uzupełniony placeholderem
        [InlineData("a", 5, 10, '-', "a----")] // Krótszy string, powinien być uzupełniony
        [InlineData("abcdefghijklm", 5, 10, '-', "abcdefghij")] // Dłuższy string, powinien być skrócony
        [InlineData(" ", 2, 5, '-', "--")] // Pojedyncza spacja
        public void Shortener_ShouldHandleEdgeCases(string value, int min, int max, char placeholder, string expected)
        {
            // Act
            string result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
