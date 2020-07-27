using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }
        public DateTime CreationDate { get; set; }

        //Navigation Properties
        public User User { get; set; }
    }
}
