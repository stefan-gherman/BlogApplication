using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Data;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApplication.Pages.Posts
{
    public class UsersByPostsModel : PageModel
    {
        private readonly BlogApplication.Data.BlogContext _context;
        private readonly ILogger<UsersByPostsModel> _logger;

        public UsersByPostsModel(BlogContext context, ILogger<UsersByPostsModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public List<Post> PostsByUser { get; set; }
        public List<User> UserPosts { get; set; }
        public async Task OnGetAsync()
        {
            UserPosts = await _context.User.Where(usr => usr.Posts.Count > 0).OrderByDescending(usr => usr.Posts.Count).ToListAsync();/*await _context.Post.Include(p => p.User).OrderByDescending(p => p.User.Posts.Count).ToListAsync();*/
            PostsByUser = await _context.Post.Include(p => p.User).OrderByDescending(p => p.User.Posts.Count).ToListAsync();
            foreach (var item in UserPosts)
            {
                _logger.LogInformation(item.Posts.Count().ToString());
            }
        }

    }
}