using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Products
    {
        [Key]

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }


        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; }
        public Category Category { get; set; }


        [ForeignKey(nameof(store))]
        public string StoreId { get; set; }
        public Store store { get; set; }


        public ICollection<Order_Product> Order_Product { get; set; } = new List<Order_Product>();


    }
}
