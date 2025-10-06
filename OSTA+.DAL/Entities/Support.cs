using OSTA_.DAL.Enum;

namespace OSTA_.DAL.Entities
{
    public class Support
    {
        private Support() { }

        public Support(string subject, string description, int userId, SupportStatus status = SupportStatus.Open)
        {
            Subject = subject;
            Description = description;
            UserId = userId;
            Status = status;
        }

        public int Id { get; private set; }
        public string Subject { get; private set; }
        public string Description { get; private set; }
        public SupportStatus Status { get; private set; }

        public int UserId { get; private set; }
        public User User { get; private set; }
    }
}
