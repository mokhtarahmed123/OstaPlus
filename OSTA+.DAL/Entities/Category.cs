namespace OSTA_.DAL.Entities
{
    public class Category
    {
        private Category() { }

        public Category(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<Service> Services { get; private set; } = new List<Service>();
        public ICollection<Product> Products { get; private set; } = new List<Product>();
    }
}
