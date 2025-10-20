using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Order
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(store))]
        public string StoreId { get; set; }
        public Store store { get; set; }


        public ICollection<Order_Product> Order_Product { get; set; } = new List<Order_Product>();

    }
}
