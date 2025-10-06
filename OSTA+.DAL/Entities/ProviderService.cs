namespace OSTA_.DAL.Entities
{
    public class ProviderService
    {
        private ProviderService() { }

        public ProviderService(int providerId, int serviceId, decimal? fixedPrice, decimal? hourlyRate, int experienceYears)
        {
            ProviderId = providerId;
            ServiceId = serviceId;
            FixedPrice = fixedPrice;
            HourlyRate = hourlyRate;
            ExperienceYears = experienceYears;
        }

        public int ProviderId { get; private set; }
        public User Provider { get; private set; }

        public int ServiceId { get; private set; }
        public Service Service { get; private set; }

        public decimal? FixedPrice { get; private set; }
        public decimal? HourlyRate { get; private set; }
        public int ExperienceYears { get; private set; }
    }
}
