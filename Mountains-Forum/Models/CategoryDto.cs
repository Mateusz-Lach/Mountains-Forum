namespace Mountains_Forum.Models
{
    public class CategoryDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<TopicDto> Topics { get; set; }
    }
}
