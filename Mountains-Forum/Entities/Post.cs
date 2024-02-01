namespace Mountains_Forum.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
