namespace OSTA_.DAL.Entities
{
    public class Product
    {
        private Product() { }

        public Product(string name, decimal price, int categoryId, int stock, string image)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
            Stock = stock;
            Image = image;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<OrderProduct> OrderProducts { get; private set; } = new List<OrderProduct>();
    }
}
