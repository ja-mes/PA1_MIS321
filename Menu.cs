using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    class Menu
    {
        private bool error;
        private string[] menuItems;

        public Menu(string[] items)
        {
            menuItems = items;
        }

        public int GetInput()
        {
            Console.WriteLine();

            for (int i = 0; i < menuItems.Length; i++)
            {
                string output;
                output = $"({Convert.ToString(i + 1)}) {menuItems[i]}";

                Console.WriteLine(output);
            }
            Utils.Divider('_', 50);

            if (error)
            {
                Console.WriteLine($"Invalid Input. Select a value between {1} and {menuItems.Length}");
            }

            Console.Write("Please select an option: ");
            int selection;
            bool valid = int.TryParse(Console.ReadLine(), out selection);

            // Ensure that input is a valid menu item
            if (!valid || selection < 1 || selection > menuItems.Length)
            {
                error = true;
                return GetInput();
            }

            return selection;
        }
    }
}