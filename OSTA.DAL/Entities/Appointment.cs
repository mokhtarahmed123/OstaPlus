using OSTA.DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Appointment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Request))]
        public string RequestId { get; set; }
        public ServiceRequest Request { get; set; }

        [ForeignKey(nameof(Provider))]
        public string ProviderId { get; set; }
        public ApplicationUser Provider { get; set; }

        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledEnd { get; set; }
        public AppointmentStatusEnum Status { get; set; } = AppointmentStatusEnum.Scheduled;



        public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
        public ICollection<Review> Reviews { get; private set; } = new List<Review>();
    }
}
