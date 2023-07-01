using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class UserViewReel : Auditable
    {
        public Guid UserId { get; set; }
        public Guid ReelId { get; set; }

        public virtual User User { get; set; } = default!;
        public virtual Reel Reel { get; set; } = default!;
    }

    public class UserViewReelConfig : IEntityTypeConfiguration<UserViewReel>
    {
        public void Configure(EntityTypeBuilder<UserViewReel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.UserViewReels).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Reel).WithMany(x => x.UserViewReel).HasForeignKey(x => x.ReelId);
        }
    }
}