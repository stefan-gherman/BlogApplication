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
                new Post {Content = "Learn how to change a tire in just 45 seconds!", UserId = 1},
                new Post {Content = "Hunting foxes has never been easier", UserId = 1},
                new Post {Content = "3 times", UserId = 1},
                new Post {Content = "Clubbing is for losers", UserId = 2},
                new Post {Content = "Vamos todos a la plaza!", UserId = 3},
            };

            context.Post.AddRange(Posts);
            context.SaveChanges();
        }
    }
}
