using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Writes a celebratory new year message.
/// </summary>
class Program
{
    private static DateTime Now = DateTime.Now;

    // This is the entry point for the program.
    /// <summary>
    /// Prints five new year messages.
    /// </summary>
    /// <param name="args">Arguments for the application.</param>
    /// <returns>The integer 0.</returns>
    static int Main(string[] args)
    {
        return WriteMessage(Now, Console.Out);
    }

    /// <summary>
    /// Writes a new year message when the supplied date is past 2016.
    /// </summary>
    /// <param name="currentDate">The current date.</param>
    /// <param name="writer">The textwriter that will be used to write the message.</param>
    /// <returns>The integer 0.</returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        int returnValue = 0;
        const int messageCount = 5;
        for (int myIndex = 0; myIndex < messageCount; myIndex++)
        {
            // This checks if the current year is greater than 2016.
            if (currentDate.Year > 2016)
            {
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + currentDate.Year);
            }
        }

        // This returns the current value.
        return returnValue;
    }
}