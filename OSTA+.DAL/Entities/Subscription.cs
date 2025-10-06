using OSTA_.DAL.Enum;

namespace OSTA_.DAL.Entities
{
    public class Subscription
    {
        private Subscription() { }

        public Subscription(string type, decimal price, int clientId, SubscriptionStatus status, DateTime startDate, DateTime endDate)
        {
            Type = type;
            Price = price;
            ClientId = clientId;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int Id { get; private set; }
        public string Type { get; private set; }
        public decimal Price { get; private set; }
        public SubscriptionStatus Status { get; private set; }

        public int ClientId { get; private set; }
        public User Client { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}
