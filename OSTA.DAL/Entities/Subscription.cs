using OSTA.DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Subscription
    {
        [Key]

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public TypeOfSubscriptionEnum Type { get; set; } = TypeOfSubscriptionEnum.Monthly;
        public decimal Price { get; set; }
        public SubscriptionStatusEnum Status { get; set; } = SubscriptionStatusEnum.Paused;

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public ApplicationUser Client { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
