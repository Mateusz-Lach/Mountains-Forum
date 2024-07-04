namespace Mountains_Forum.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Description { get; set; }

        public DateTime DateOfJoin { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
