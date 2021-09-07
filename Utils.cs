using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    static class Utils
    {
        /* Divider creates a line accross the screen with the specified char */
        public static void Divider(char c, int length)
        {
            string outputStr = "";
            for (int i = 0; i < length; i++)
                outputStr += c;

            Console.WriteLine(outputStr);
        }

        /* The BuildScreen method first clears the terminal, and then builds a header with a optional subheader */
        public static void BuildScreen(string title, string subHeader = null)
        {
            Console.Clear(); // clear the screen
            Divider('-', 50);
            Console.Write($"\n{title.ToUpper()}");

            // display sub header if provided
            if (subHeader != null)
                Console.WriteLine($" / {subHeader}");
            else
                Console.WriteLine();

            Console.WriteLine();
            Divider('-', 50);
        }

        public static void WaitForUser(string message = "") 
        {
            Console.WriteLine(message);
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }

        /* The Exit method terminates the program */
        public static void Exit() 
        {
            System.Environment.Exit(0);
        }

    }
}