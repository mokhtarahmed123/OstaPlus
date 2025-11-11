using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OSTA.DAL.Entities
{
    public class Service
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public int Duration { get; set; }
        [ForeignKey(nameof(Category))]
        public string CategoryId { get; set; }
        public Category Category { get; set; }





        public ICollection<ServiceRequest> ServiceRequest { get; set; } = new List<ServiceRequest>();
        public ICollection<ProviderService> ProviderService { get; set; } = new List<ProviderService>();

    }
}
