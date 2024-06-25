using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;

namespace api.Dtos.Page
{
    public class PageDto
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set;} = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public List<CommentDto> Comments { get; set; }
    }
}