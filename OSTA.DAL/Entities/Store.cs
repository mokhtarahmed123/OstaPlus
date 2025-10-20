using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Store
    {
        [Key]

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }



        [ForeignKey(nameof(User))]
        public string Merchantid { get; set; }
        public ApplicationUser User { get; set; }


        public ICollection<Order> orders { get; set; } = new List<Order>();
        public ICollection<Products> products { get; set; } = new List<Products>();


    }
}
