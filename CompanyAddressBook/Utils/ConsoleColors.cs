using System;

namespace CompanyAddressBook.Utils
{
    /// <summary>
    /// Provides methods for writing colored text to the console.
    /// </summary>
    internal class ConsoleTextColorizer
    {
        /// <summary>
        /// Writes the specified text to the console in the given color,
        /// without appending a newline (equivalent to Console.Write).
        /// </summary>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="color">The color in which to display the text.</param>
        public static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the specified text to the console in the given color,
        /// and appends a newline at the end (equivalent to Console.WriteLine).
        /// </summary>
        /// <param name="text">The text to be displayed.</param>
        /// <param name="color">The color in which to display the text.</param>
        public static void WriteColoredLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
