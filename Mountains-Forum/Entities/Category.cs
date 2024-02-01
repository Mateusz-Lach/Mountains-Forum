﻿namespace Mountains_Forum.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public virtual List<Topic> Topics { get; set; }
    }
}
