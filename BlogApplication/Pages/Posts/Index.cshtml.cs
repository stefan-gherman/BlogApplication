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

        public async Task OnGetAsync()
        {
            Post = await _context.Post
                .Include(p => p.User).ToListAsync();
        }
    }
}
