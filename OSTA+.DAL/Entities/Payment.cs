using OSTA_.DAL.Enum;

namespace OSTA_.DAL.Entities
{
    public class Payment
    {
        private Payment() { }

        public Payment(int appointmentId, int requestId, decimal amount, int payerId, int payeeId, string currency, PaymentMethod method, PaymentStatus status = PaymentStatus.Pending)
        {
            AppointmentId = appointmentId;
            RequestId = requestId;
            Amount = amount;
            PayerId = payerId;
            PayeeId = payeeId;
            Currency = currency;
            Method = method;
            Status = status;
        }

        public int Id { get; private set; }
        public int AppointmentId { get; private set; }
        public Appointment Appointment { get; private set; }

        public int RequestId { get; private set; }
        public ServiceRequest Request { get; private set; }

        public decimal Amount { get; private set; }
        public int PayerId { get; private set; }
        public int PayeeId { get; private set; }

        public string Currency { get; private set; }
        public PaymentMethod Method { get; private set; }
        public PaymentStatus Status { get; private set; }
    }
}
