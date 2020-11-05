using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập tên chủ đề!!!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập nội dung!!!")]
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
