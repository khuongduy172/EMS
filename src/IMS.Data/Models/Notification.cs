using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IMS.Data.Models.Common;
using IMS.Data.Enums;

namespace social_network.src.Models
{
    public class Notification : Auditable
    {
        public TypeNotiEnum TypeNoti { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? FromId { get; set; }
        public Guid? StatusId { get; set; }
        public Guid? ReelId { get; set; }
        public bool IsRead { get; set; }

        public virtual User FromUser { get; set; } = default!;
    }

    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(n => n.FromUser).WithMany().HasForeignKey(n => n.FromId);
        }
    }
}