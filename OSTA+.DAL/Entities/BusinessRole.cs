namespace OSTA_.DAL.Entities
{
    public class BusinessRole
    {
        private BusinessRole() { }

        public BusinessRole(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<User> Users { get; private set; } = new List<User>();
    }
}
