using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogApplication.Data;
using BlogApplication.Models;

namespace BlogApplication.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly BlogApplication.Data.BlogContext _context;

        public IndexModel(BlogApplication.Data.BlogContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }
        public string Message { get; set; } = "Get Message";

        public async Task OnGetAsync(string sortOrder)
        {
            if(sortOrder == null)
            {
                Post = await _context.Post
               .Include(p => p.User).Include(p => p.Blog).ToListAsync();
            } else
            {
                Message = "Sorted";
                Post = await _context.Post.OrderByDescending(p => p.CreationDate).Include(p => p.User).Include(p => p.Blog).ToListAsync();
            }
            
           
        }


    }
}
