using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostsJSON
{
    internal class PostsData
    {
        public Post[] posts { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }

        public void Display()
        {
            foreach (Post post in posts)
            {
                Console.WriteLine(post);
                Console.WriteLine(new String('-', 150));
            }
        }

        public LinkedList<Tag> GetTags()
        {
            LinkedList<Tag> tags = new LinkedList<Tag> ();
            HashSet<string> tag_names = new HashSet<string> ();
            foreach (Post post in posts)
            {
                foreach (string tag in post.tags)
                {
                    if (!tag_names.Contains(tag))
                    {
                        tag_names.Add(tag);
                        Tag newTag = new Tag(tag);
                        tags.AddLast(newTag);
                    }
                }
            }
            return tags;
        }
       
    }

    internal class Tag
    {
        public int id { get; set; }
        public string name { get; set; }

        public Tag(string name)
        {
            id = 0;
            this.name = name;
        }
    }

    internal class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public string[] tags { get; set; }
        public int reactions { get; set; }

        public override string ToString()
        {
            string tags = string.Empty;
            foreach (string tag in this.tags)
            {
                tags += "\t";
                tags += tag;
                tags += "\n";
            }

            return $"id: {id}\n" +
                $"title: {title}\n" +
                $"body: {body}\n" +
                $"userId: {userId}\n" +
                $"tags: \n" +
                $"{tags}" +
                $"reactions: {reactions}\n";
        }
    }
}
