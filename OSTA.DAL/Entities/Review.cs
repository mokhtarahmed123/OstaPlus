using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Review
    {
        [Key]

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Comment { get; set; }
        public int Rating { get; set; }

        [ForeignKey(nameof(Reviewer))]
        public string ReviewerId { get; set; }
        public ApplicationUser Reviewer { get; set; }

        [ForeignKey(nameof(Appointment))]
        public string AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
