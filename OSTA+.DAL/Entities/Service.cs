namespace OSTA_.DAL.Entities
{
    public class Service
    {
        private Service() { }

        public Service(string description, decimal basePrice, int duration, int categoryId)
        {
            Description = description;
            BasePrice = basePrice;
            Duration = duration;
            CategoryId = categoryId;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal BasePrice { get; private set; }
        public int Duration { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<ProviderService> ProviderServices { get; private set; } = new List<ProviderService>();
    }
}
