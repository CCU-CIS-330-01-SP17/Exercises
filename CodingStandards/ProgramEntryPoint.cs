using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Creates Program class to get current date and time to display appropriate message.
/// </summary>
class Program
{
    //This is the entry point for the program.
    static DateTime currentDate = DateTime.Now;

    /// <summary>
    /// Calls the WriteMessage method and passes the dateTime variable.  
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    static int Main(string[] args)
    {
        return WriteMessage(currentDate, Console.Out);
    }

    /// <summary>
    /// Writes the appropriate message based on the dateTime variable. 
    /// </summary>
    /// <param name="currentDate"></param>
    /// <param name="writer"></param>
    /// <returns></returns>
    public static int WriteMessage(DateTime currentDate, TextWriter writer)
    {
        var returnValue = 0;
        const int messageCount = 5;

        for (int myIndex = 0; myIndex < messageCount; myIndex++)
        {
            //Checks to see if the current date is greater than 2016.
            if (currentDate.Year > 2016)
            {
                writer.WriteLine("Happy New Year!");
            }
            else
            {
                writer.WriteLine("Hello From " + currentDate.Year);
            }
        }
        
        //Returns the result value.
        return returnValue;
    }
}

