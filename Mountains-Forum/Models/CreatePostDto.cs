using System.ComponentModel.DataAnnotations;

namespace Mountains_Forum.Models
{
    public class CreatePostDto
    {
        [Required]
        public string Content { get; set; }

        public DateTime CreatedDate = DateTime.Now;
    }
}
