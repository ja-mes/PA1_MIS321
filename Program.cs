using System;

namespace PA1
{

    class Program
    {
        private static void RenderMenu() 
        {
            string[] menuItems = 
            {
                "Show all Posts",
                "Add a Post",
                "Delete a Post by ID",
                "Quit"
            };
            Menu menu = new Menu(menuItems);

            int selection = menu.GetInput();
            
            if(selection == 1) 
            {
                PostFile.DisplayScreen();
            }
            else if (selection == 2) 
            {
                PostFile.AddScreen();
            }
            else if(selection == 3) 
            {
                PostFile.DeleteScreen();
            }
            else if(selection == 4)
            {
                Utils.Exit();
            }
        }

        public static void MainScreen() 
        {
            Utils.BuildScreen("BIG AL GOES SOCIAL");
            RenderMenu();
        }

        static void Main(string[] args)
        {
            MainScreen();
        }
    }

}
