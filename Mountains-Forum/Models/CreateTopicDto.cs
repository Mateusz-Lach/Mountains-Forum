using System.ComponentModel.DataAnnotations;

namespace Mountains_Forum.Models
{
    public class CreateTopicDto
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate = DateTime.Today;
    }
}
