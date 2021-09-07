using System;

namespace PA1
{
    class Post : IComparable<Post>
    {
        public int PostID {get; set;}
        public string PostText {get; set;}
        public DateTime TimeStamp {get; set;}

        public int CompareTo(Post temp) 
        {
            return temp.TimeStamp.CompareTo(this.TimeStamp);
        }

        public static int CompareByID(Post x, Post y)
        {
            return y.PostID.CompareTo(x.PostID);
        }
    }
}