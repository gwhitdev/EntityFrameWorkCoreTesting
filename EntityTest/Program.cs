using System;
using EntityTest.DbContexts;
using EntityTest.Models;
using System.Linq;

namespace EntityTest
{
    class Program
    {
        private static Blog Blog { get; set; } = new Blog();

        static void Main(string[] args)
        {
        
            using(var db = new BloggingContext())
            {
                Console.WriteLine("Insert a new blog? Y/N");
                var a1 = Console.ReadLine();
                var a1String = a1.ToString();
                string expectedAnswer = "Y";
                if (a1String.Equals(expectedAnswer))
                {
                    Console.WriteLine("Inserting a new blog");
                    db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Thanks. Bye!");
                    Environment.Exit(0);
                }

                Console.WriteLine("Would you like to query blogs? Y/N");
                var a2 = Console.ReadLine();
                var a2String = a2.ToString();
                if (a2String.Equals("Y"))
                {
                    Console.WriteLine("Querying for a blog...");
                    Blog = db.Blogs
                        .OrderBy(b => b.BlogId)
                        .First();
                }
                else
                {
                    Console.WriteLine("Thanks. Bye!");
                    Environment.Exit(0);
                }

                Console.WriteLine("Would you like to update the blog by adding a post? Y/N");
                var a3 = Console.ReadLine();
                var a3String = a3.ToString();
                if (a3String.Equals("Y"))
                {
                    Console.WriteLine("Updating the blog and adding a post...");
                    Blog.Url = "https://devblogs.microsoft.com/dotnet";
                    Blog.Posts.Add(
                        new Post
                        {
                            Title = "Hello World",
                            Content = "I wrote this post"
                        });
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Thanks. Bye!");
                    Environment.Exit(0);
                }

                Console.WriteLine("Would you like to delete the blog? Y/N");
                var a4 = Console.ReadLine();
                var a4String = a4.ToString();
                if (a4.Equals("Y"))
                {
                    Console.WriteLine("Delete the blog...");
                    db.Remove(Blog);
                    db.SaveChanges();
                }

                Console.WriteLine("That's all folks! Goodbye!");
                Console.ReadLine();
            }
        }
    }
}
