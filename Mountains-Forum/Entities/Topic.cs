namespace Mountains_Forum.Entities
{
    public class Topic
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }



        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }


        public List<Post> Posts { get; set; }
    }
}
