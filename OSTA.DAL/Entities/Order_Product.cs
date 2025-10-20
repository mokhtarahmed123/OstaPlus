using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Order_Product
    {


        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; }
        public Order Order { get; set; }


        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }

        public Products Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
