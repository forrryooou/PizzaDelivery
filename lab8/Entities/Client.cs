namespace lab8.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string Number { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
