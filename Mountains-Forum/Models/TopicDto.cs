namespace Mountains_Forum.Models
{
    public class TopicDto
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<PostDto> Posts { get; set; }
    }
}
