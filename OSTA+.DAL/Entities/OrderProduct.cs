namespace OSTA_.DAL.Entities
{
    public class OrderProduct
    {
        private OrderProduct() { }

        public OrderProduct(int orderId, int productId, int quantity)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
        }

        public int OrderId { get; private set; }
        public Order Order { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public int Quantity { get; private set; }
    }
}
