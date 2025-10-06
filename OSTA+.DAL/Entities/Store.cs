namespace OSTA_.DAL.Entities
{
    public class Store
    {
        private Store() { }

        public Store(string name, string address, string location, int ownerId)
        {
            Name = name;
            Address = address;
            Location = location;
            OwnerId = ownerId;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Location { get; private set; }

        public int OwnerId { get; private set; }
        public User Owner { get; private set; }
    }
}
