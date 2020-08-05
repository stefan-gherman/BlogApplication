using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogApplication.Controllers
{
    public class PostsController : Controller
    {
        BlogContext _context;

        public PostsController(BlogContext context)
        {
            _context = context;
        }

        [ActionName("sort")]
       public IActionResult OnGetSortPostsByDate()
        {
           return Ok(_context.Post.OrderByDescending( p => p.CreationDate));
           
        }
    }
}
