using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UniqueSerialNumberGenerator
{
    public class SerialNumberGenerator
    {
        private static readonly Random random = new();
        const string alphabeticChars = "ABCDEFGHKMNPRSTVWXYZ";
        const string numericChars = "0123456789";

        public static string GenerateNonConsecutiveIncreasing()
        {
            bool hasConsecutiveIncreasingChars = true;

            string generatedNumber = null!;
            while (hasConsecutiveIncreasingChars)
            {
                // Generate 10 alphabetic characters
                StringBuilder builder = new();
                for (int i = 0; i < 12; i++)
                {
                    builder.Append(alphabeticChars[random.Next(alphabeticChars.Length)]);
                }

                // Insert 2 numeric characters at random positions
                for (int i = 0; i < 2; i++)
                {
                    char numericChar = numericChars[random.Next(numericChars.Length)];
                    int position = random.Next(builder.Length + 1);

                    builder.Insert(position, numericChar);
                }

                generatedNumber = builder.ToString();

                hasConsecutiveIncreasingChars = HasConsecutiveIncreasingChars(generatedNumber);
            }



            return generatedNumber;
        }

        public static string GenerateNonConsecutiveRepeating()
        {
            bool hasConsecutiveRepeatingChars = true;

            string generatedNumber = null!;
            while (hasConsecutiveRepeatingChars)
            {
                // Generate 10 alphabetic characters
                StringBuilder builder = new();
                for (int i = 0; i < 12; i++)
                {
                    builder.Append(alphabeticChars[random.Next(alphabeticChars.Length)]);
                }

                // Insert 2 numeric characters at random positions
                for (int i = 0; i < 2; i++)
                {
                    char numericChar = numericChars[random.Next(numericChars.Length)];
                    int position = random.Next(builder.Length + 1);

                    builder.Insert(position, numericChar);
                }

                generatedNumber = builder.ToString();

                hasConsecutiveRepeatingChars = HasConsecutiveRepeatingChars(generatedNumber);
            }



            return generatedNumber;
        }

        public static string GenerateNonConsecutiveIncreasingNorRepeating()
        {
            bool hasConsecutiveIncreasingChars = true;
            bool hasConsecutiveRepeatingChars = true;

            string generatedNumber = null!;
            while (hasConsecutiveIncreasingChars ||hasConsecutiveRepeatingChars)
            {
                // Generate 10 alphabetic characters
                StringBuilder builder = new();
                for (int i = 0; i < 12; i++)
                {
                    builder.Append(alphabeticChars[random.Next(alphabeticChars.Length)]);
                }

                // Insert 2 numeric characters at random positions
                for (int i = 0; i < 2; i++)
                {
                    char numericChar = numericChars[random.Next(numericChars.Length)];
                    int position = random.Next(builder.Length + 1);

                    builder.Insert(position, numericChar);
                }

                generatedNumber = builder.ToString();

                hasConsecutiveIncreasingChars = HasConsecutiveIncreasingChars(generatedNumber);
                hasConsecutiveRepeatingChars = HasConsecutiveRepeatingChars(generatedNumber);
            }

            return generatedNumber;
        }

        private static bool HasConsecutiveRepeatingChars(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i+1])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasConsecutiveIncreasingChars(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (IsConsecutive(input[i], input[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsConsecutive(char a, char b)
        {
            // Check if 'b' is the next character in the sequence after 'a'
            if (char.IsDigit(a) && char.IsDigit(b))
            {
                return b - a == 1;
            }
            if (char.IsLetter(a) && char.IsLetter(b) && char.ToUpper(a) != 'Z')
            {
                return char.ToUpper(b) - char.ToUpper(a) == 1;
            }
            return false;
        }
    }
}