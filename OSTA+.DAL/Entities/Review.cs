namespace OSTA_.DAL.Entities
{
    public class Review
    {
        private Review() { }

        public Review(string comment, int rating, int reviewerId, int appointmentId)
        {
            Comment = comment;
            Rating = rating;
            ReviewerId = reviewerId;
            AppointmentId = appointmentId;
        }

        public int Id { get; private set; }
        public string Comment { get; private set; }
        public int Rating { get; private set; }

        public int ReviewerId { get; private set; }
        public User Reviewer { get; private set; }

        public int AppointmentId { get; private set; }
        public Appointment Appointment { get; private set; }
    }
}
