using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsJSON
{
    internal class CommentsData
    {
        public Comment[] comments { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }

        public void Display()
        {
            foreach (Comment comment in comments)
            {

                Console.WriteLine(comment);
                Console.WriteLine(new String('-', 100));
            }
        }

        public LinkedList<User> GetUsers()
        {
            LinkedList<User> users = new LinkedList<User>();
            HashSet<int> user_ids = new HashSet<int>();
            foreach (Comment comment in comments)
            {
                User user = comment.user;
                int user_id = user.id;
                if (!user_ids.Contains(user_id))
                {
                    user_ids.Add(user_id);
                    users.AddLast(user);
                }
            }
            return users;
        }
    }

    internal class Comment
    {
        public int id { get; set; }
        public string body { get; set; }
        public int postId { get; set; }
        public User user { get; set; }

        public override string ToString()
        {
            return $"id: {id}\n" +
                $"body: {body}\n" +
                $"postId: {postId}\n" +
                $"user: \n" +
                $"{user}";
        }

    }

    internal class User
    {
        public int id { get; set; }
        public string username { get; set; }

        public override string ToString()
        {
            return $"\tid: {id}\n" +
                $"\tusername: {username}\n";
        }
    }
}
