namespace OSTA_.DAL.Entities
{
    public class Order
    {
        private Order() { }

        public Order(int customerId)
        {
            CustomerId = customerId;
        }

        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public User Customer { get; private set; }

        public ICollection<OrderProduct> OrderProducts { get; private set; } = new List<OrderProduct>();
    }
}
