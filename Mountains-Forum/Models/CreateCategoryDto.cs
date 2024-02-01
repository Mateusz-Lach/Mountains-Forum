using System.ComponentModel.DataAnnotations;

namespace Mountains_Forum.Models
{
    public class CreateCategoryDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
