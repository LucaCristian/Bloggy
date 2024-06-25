using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace api.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set;} = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}