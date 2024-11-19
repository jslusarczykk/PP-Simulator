using System;
using System.Collections.Generic;

namespace Simulator
{
    public static class Validator
    {
        public static int Limiter(int value, int min, int max)
        {
            if (min > max)
            {
                (min, max) = (max, min); // Zamień wartości, jeśli są odwrócone
            }
            return Math.Clamp(value, min, max);
        }


        public static string Shortener(string value, int min, int max, char placeholder)
        {
            if (max < min)
            {
                (min, max) = (max, min); // Zamiana min i max, jeśli są odwrócone
            }

            if (value == null)
            {
                return new string(placeholder, min);
            }

            value = value.Trim();

            if (value.Length > max)
            {
                value = value.Substring(0, max);
            }

            if (value.Length < min)
            {
                value = value.PadRight(min, placeholder);
            }

            return value;
        }

    }
}
