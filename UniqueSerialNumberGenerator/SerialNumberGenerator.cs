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

            StringBuilder builder = new();

            // Generate 10 alphabetic characters
            for (int i = 0; i < 10; i++)
            {
                builder.Append(alphabeticChars[random.Next(alphabeticChars.Length)]);
            }

            // Generate 2 numeric characters
            for (int i = 0; i < 2; i++)
            {
                builder.Append(numericChars[random.Next(numericChars.Length)]);
            }

            return builder.ToString();
        }
    }
}