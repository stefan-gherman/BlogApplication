using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Data
{
    public class DbSeeder
    {
        public static void Init(BlogContext context)
        {
            if (context.Post.Any())
            {
                return;
            }

            var blogs = new Blog[]
            {
                new Blog { Name="Tony's Blog", Url="www.tony.com"},
                new Blog { Name="FrankFrank", Url="www.frank.com"}
            };

            context.Blog.AddRange(blogs);
            context.SaveChanges();
            var users = new User[]
            {
                new User{ FirstName="Tony", LastName="Gonzalez"},
                new User{ FirstName="Albert", LastName="Thompson"},
                new User{ FirstName="Frank", LastName="Nunez"},
                new User{ FirstName="Karen", LastName="Powell"},
            };
            context.User.AddRange(users);
            context.SaveChanges();


            var Posts = new Post[]
            {
                new Post {Content = "Learn how to change a tire in just 45 seconds!", UserId = 1, CreationDate = DateTime.Parse("02/01/2015 23:31:27"), BlogId=1},
                new Post {Content = "Hunting foxes has never been easier", UserId = 1, CreationDate =DateTime.Parse("22/12/2009 15:22:08"),BlogId=1},
                new Post {Content = "3 times", UserId = 1, CreationDate = DateTime.Parse("12/04/2008 09:45:21"), BlogId=1},
                new Post {Content = "Clubbing is for losers", UserId = 2, CreationDate = DateTime.Parse("02/01/2005 03:22:12"), BlogId=2},
                new Post {Content = "Vamos todos a la plaza!", UserId = 3, CreationDate = DateTime.Parse("01/09/2025 12:01:52"), BlogId=1},
            };

            context.Post.AddRange(Posts);
            context.SaveChanges();
        }
    }
}
