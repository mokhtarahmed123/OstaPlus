using OSTA_.DAL.Enum;

namespace OSTA_.DAL.Entities
{
    public class Appointment
    {
        private Appointment() { }

        public Appointment(int requestId, int providerId, DateTime scheduledStart, DateTime scheduledEnd, AppointmentStatus status = AppointmentStatus.Scheduled)
        {
            RequestId = requestId;
            ProviderId = providerId;
            ScheduledStart = scheduledStart;
            ScheduledEnd = scheduledEnd;
            Status = status;
        }

        public int Id { get; private set; }
        public int RequestId { get; private set; }
        public ServiceRequest Request { get; private set; }

        public int ProviderId { get; private set; }
        public User Provider { get; private set; }

        public DateTime ScheduledStart { get; private set; }
        public DateTime ScheduledEnd { get; private set; }
        public AppointmentStatus Status { get; private set; }

        public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
        public ICollection<Review> Reviews { get; private set; } = new List<Review>();
    }
}
