using OSTA.DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Payment
    {
        [Key]

        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public CurrencyTypeEnum Currency { get; set; } = CurrencyTypeEnum.Pound;

        public decimal Amount { get; set; }

        [ForeignKey(nameof(Request))]
        public string RequestId { get; set; }
        public ServiceRequest Request { get; set; }
        [ForeignKey(nameof(User))]
        public string PayerId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(Provider))]
        public string PayeeId { get; set; }
        public ProviderService Provider { get; set; }

        public PaymentStatusEnum Status { get; set; } = PaymentStatusEnum.Pending;
        public PaymentMethodEnum PaymentMethodEnum { get; set; } = PaymentMethodEnum.cash;
    }
}
