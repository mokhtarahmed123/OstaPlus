using OSTA_.DAL.Enum;

namespace OSTA_.DAL.Entities
{
    public class ServiceRequest
    {
        private ServiceRequest() { }

        public ServiceRequest(string title, string address, int clientId, int categoryId, int serviceId, string description, decimal price, RequestStatus status = RequestStatus.Pending)
        {
            Title = title;
            Address = address;
            ClientId = clientId;
            CategoryId = categoryId;
            ServiceId = serviceId;
            Description = description;
            Price = price;
            Status = status;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Address { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public RequestStatus Status { get; private set; }

        public int ClientId { get; private set; }
        public User Client { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public int ServiceId { get; private set; }
        public Service Service { get; private set; }

        public ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();
    }
}
