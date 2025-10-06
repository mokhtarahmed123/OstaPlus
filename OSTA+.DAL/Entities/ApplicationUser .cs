using Microsoft.AspNetCore.Identity;

namespace OSTA_.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Identity handles authentication
        public string? FullName { get; set; }
        public int? LinkedUserId { get; set; }  // Foreign key to your domain user

        public User? LinkedUser { get; set; }   // Navigation property
    }
}
