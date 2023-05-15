namespace Bcrypt.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PasswordHashed { get; set; }
        public string Salt { get; set; }
    }
}