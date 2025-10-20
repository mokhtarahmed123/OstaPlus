using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OSTA.DAL.Entities
{
    public class ProviderService
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(Provider))]
        public string ProviderId { get; private set; }
        public ApplicationUser Provider { get; private set; }


        [ForeignKey(nameof(Service))]
        public string ServiceId { get; private set; }
        public Service Service { get; set; }


        public decimal? FixedPrice { get; private set; }
        public decimal? HourlyRate { get; private set; }
        public int ExperienceYears { get; private set; }






        public ICollection<Payment> Payment { get; set; } = new List<Payment>();

    }
}
