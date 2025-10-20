using OSTA.DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSTA.DAL.Entities
{
    public class Support
    {
        [Key]

        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Subject { get; private set; }
        public string Description { get; private set; }
        public SupportStatusEnum Status { get; private set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; private set; }
        public ApplicationUser User { get; private set; }
    }
}
