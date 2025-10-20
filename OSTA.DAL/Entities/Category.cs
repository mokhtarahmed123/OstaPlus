using System.ComponentModel.DataAnnotations;

namespace OSTA.DAL.Entities
{
    public class Category
    {
        [Key]

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }


        public ICollection<Products> Products { get; set; } = new List<Products>();
        public ICollection<ServiceRequest> ServiceRequest { get; set; } = new List<ServiceRequest>();
        public ICollection<Service> Service { get; set; } = new List<Service>();

    }
}
