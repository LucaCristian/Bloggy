using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Page
{
    public class UpdatePageRequestDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Content { get; set;} = string.Empty;
    }
}