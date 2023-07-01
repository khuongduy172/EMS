using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class UserViewStatus : Auditable
    {
        public Guid UserId { get; set; }
        public Guid StatusId { get; set; }

        public virtual User User { get; set; } = default!;
        public virtual Status Status { get; set; } = default!;
    }

    public class UserViewStatusConfig : IEntityTypeConfiguration<UserViewStatus>
    {
        public void Configure(EntityTypeBuilder<UserViewStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Status).WithMany(x => x.UserViewStatuses).HasForeignKey(x => x.StatusId);
        }
    }
}