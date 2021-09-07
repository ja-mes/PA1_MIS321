using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA1
{
    static class PostFile
    {
        private const string FILE_NAME = "posts.txt";

        static public void AddScreen() 
        {
           Utils.BuildScreen("Create a post");

           Console.WriteLine("\nEnter Post Text: ");

           string postText = Console.ReadLine();

            try 
            {
                using (StreamWriter write = File.AppendText(FILE_NAME))
                {
                    write.WriteLine($"{GetNewID()}#{DateTime.Now}#{postText}");

                    write.Close();
                }
            }
            catch(Exception e)
            {
                Utils.WaitForUser(e.Message);
                Program.MainScreen();
            }

            Utils.WaitForUser("Post successfully created!");
            Program.MainScreen();

        }

        public static List<Post> GetPosts() 
        {
            List<Post> posts = new List<Post>();

            try
            {
                using (StreamReader read = new StreamReader(FILE_NAME)) 
                {
                    string line;

                    while((line = read.ReadLine()) != null) 
                    {
                        string[] temp = line.Split('#');

                        int id = int.Parse(temp[0]);
                        DateTime date = DateTime.Parse(temp[1]);
                        string text = temp[2];

                        posts.Add(new Post(){PostID = id, TimeStamp = date, PostText = text});
                    }
                    
                    read.Close();
                }
            }
            catch (FileNotFoundException)
            {
                using(FileStream fs = File.Create(FILE_NAME))
                    fs.Close();

                Console.WriteLine($"The file {FILE_NAME} does not exist. An empty {FILE_NAME} file has been created.");
                Utils.WaitForUser();
                Program.MainScreen();
            }
            
            return posts;
        }

        private static int GetNewID()
        {
            List<Post> posts = GetPosts();
            posts.Sort(Post.CompareByID);

            if(!posts.Any())
                return 0;
            else 
                return posts.First().PostID + 1;
        }

        public static void DisplayScreen() 
        {
            Utils.BuildScreen("Show all posts");
            Console.WriteLine("\n");
            List<Post> posts = GetPosts();
            posts.Sort();

            Console.WriteLine($"ID \t TIME STAMP \t\t POST TEXT\n");

            foreach (Post post in posts)
            {
                Console.WriteLine($"{post.PostID} \t {post.TimeStamp} \t {post.PostText}");
            }

            Utils.WaitForUser();
            Program.MainScreen();

        }

        private static int GetDeleteID(bool error = false)
        {
            if (error)
            {
                Console.WriteLine("Invalid Input. Please enter a valid post ID");
            }

            Console.WriteLine("\nEnter Post ID to delete: ");
            int selection;
            bool valid = int.TryParse(Console.ReadLine(), out selection);

            if(!valid)
            {
                return GetDeleteID(true);
            }

            return selection;

        }

        public static void DeleteScreen()
        {
            Utils.BuildScreen("Delete Post");

            int id = GetDeleteID();
            bool found = false;

            List<Post> posts = GetPosts();

            try 
            {
                using (StreamWriter write = new StreamWriter(FILE_NAME))
                {
                    foreach(Post post in posts) 
                    {
                        if(post.PostID == id)
                        {
                            found = true;
                            continue;
                        }

                        write.WriteLine($"{post.PostID}#{post.TimeStamp}#{post.PostText}");
                    }

                    write.Close();
                }
            }
            catch(Exception e)
            {
                Utils.WaitForUser(e.Message);
                Program.MainScreen();
            }

            if(!found)
                Utils.WaitForUser($"Could not find post with id {id}");
            else 
                Utils.WaitForUser("Post succesfully deleted!");
            Program.MainScreen();
        }

    }
}