using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static DateTime DTNow = DateTime.Now;

    // This is the entry point for the program.
    /// <summary>
    /// Prints messages to the console
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static int Main(string[] args)
    {
        return WriteMessage(DTNow, Console.Out);
    }

    /// <summary>
    /// Writes a message. Content depends on the current date.
    /// </summary>
    /// <param name="CurrentDate"></param>
    /// <param name="writer"></param>
    /// <returns></returns>
    public static int WriteMessage(DateTime CurrentDate, TextWriter writer)
    {
        var resultValue = 0;
        const int messageCount = 5;
        for (int myIndex = 0; myIndex < messageCount; myIndex++)
            // This if statement makes sure the date is greater than 2016.
            if (CurrentDate.Year > 2016)
            {
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + CurrentDate.Year);
            }
        // The following statement returns the result value.
        return resultValue;
    }
}

