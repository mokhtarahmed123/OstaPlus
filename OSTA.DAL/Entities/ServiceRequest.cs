using OSTA.DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class ServiceRequest
    {
        [Key]

        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Title { get; private set; }
        public string Address { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public RequestStatusEnum Status { get; private set; } = RequestStatusEnum.Pending;

        [ForeignKey(nameof(Client))]
        public string ClientId { get; private set; }
        public ApplicationUser Client { get; private set; }

        [ForeignKey(nameof(Category))]
        public string CategoryId { get; private set; }
        public Category Category { get; private set; }

        [ForeignKey(nameof(Service))]
        public string ServiceId { get; private set; }
        public Service Service { get; private set; }





        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();

    }
}
