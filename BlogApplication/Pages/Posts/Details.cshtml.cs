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
    public class DetailsModel : PageModel
    {
        private readonly BlogApplication.Data.BlogContext _context;

        public DetailsModel(BlogApplication.Data.BlogContext context)
        {
            _context = context;
        }

        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Post
                .Include(p => p.User).FirstOrDefaultAsync(m => m.PostId == id);

            if (Post == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
