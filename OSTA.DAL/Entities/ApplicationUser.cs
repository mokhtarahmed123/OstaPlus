using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {

        #region Atrributes
        public string Address { get; set; }
        public bool IsActive { get; set; } = false; // init Value

        [ForeignKey(nameof(RoleApplication))]
        public string RoleID { get; set; }
        public RoleApplication RoleApplication { get; set; }
        #endregion
        #region lists
        public ICollection<ServiceRequest> ServiceRequests { get; private set; } = new List<ServiceRequest>();
        public ICollection<ProviderService> ProviderServices { get; private set; } = new List<ProviderService>();
        //public ICollection<Payment> PaymentsMade { get; private set; } = new List<Payment>();
        public ICollection<Payment> Payments { get; private set; } = new List<Payment>();
        public ICollection<Review> Reviews { get; private set; } = new List<Review>();
        public ICollection<Store> Stores { get; private set; } = new List<Store>();
        public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();
        public ICollection<Support> Supports { get; private set; } = new List<Support>();


        #endregion






    }
}
