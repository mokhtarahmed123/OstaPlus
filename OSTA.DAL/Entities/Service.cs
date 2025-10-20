using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OSTA.DAL.Entities
{
    public class Service
    {
        [Key]
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Description { get; private set; }
        public decimal BasePrice { get; private set; }
        public int Duration { get; private set; }
        [ForeignKey(nameof(Category))]
        public string CategoryId { get; private set; }
        public Category Category { get; private set; }





        public ICollection<ServiceRequest> ServiceRequest { get; set; } = new List<ServiceRequest>();
        public ICollection<ProviderService> ProviderService { get; set; } = new List<ProviderService>();

    }
}
