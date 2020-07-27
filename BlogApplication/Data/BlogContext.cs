using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogApplication.Models;

namespace BlogApplication.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext (DbContextOptions<BlogContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
