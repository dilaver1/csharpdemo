namespace CourseAdoNet.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public User() { }

        public User(int id,string userName,string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }
    }
}
