namespace OSTA_.DAL.Entities
{
    public class User
    {
        private User() { }

        public User(string name, string email, string password, string phone, int roleId, bool isActive = true)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            RoleId = roleId;
            IsActive = isActive;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        public int RoleId { get; private set; }
        public BusinessRole Role { get; private set; } = null!;

        // 🔗 Navigation to ApplicationUser (Identity)
        public ApplicationUser? ApplicationUser { get; set; }

        // 🔁 Relationships
        public ICollection<ServiceRequest> ServiceRequests { get; private set; } = new List<ServiceRequest>();
        public ICollection<ProviderService> ProviderServices { get; private set; } = new List<ProviderService>();
        public ICollection<Payment> PaymentsMade { get; private set; } = new List<Payment>();
        public ICollection<Payment> PaymentsReceived { get; private set; } = new List<Payment>();
        public ICollection<Review> Reviews { get; private set; } = new List<Review>();
        public ICollection<Store> Stores { get; private set; } = new List<Store>();
        public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();
        public ICollection<Support> Supports { get; private set; } = new List<Support>();
    }
}
