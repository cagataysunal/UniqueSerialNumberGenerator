using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueSerialNumberGenerator
{
    public class SerialNumberGenerator
    {
        private static readonly Random random = new();

        public static string GenerateSerialNumber()
        {
            const string alphabeticChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numericChars = "0123456789";

            // Generate 10 alphabetic characters
            StringBuilder builder = new();
            for (int i = 0; i < 10; i++)
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

            return builder.ToString();
        }
    }
}