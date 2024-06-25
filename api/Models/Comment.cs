using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set;} = string.Empty;
        public DateTime CreatedOn  { get; set; } = DateTime.Now;
        public int? PageId { get; set; }
        public Page? Page{ get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}