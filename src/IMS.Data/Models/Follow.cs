using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class Follow : Auditable
    {
        public Guid UserId { get; set; }
        public Guid FollowerId { get; set; }

        public virtual User User { get; set; } = default!;
        public virtual User Follower { get; set; } = default!;

        public Follow(Guid userId, Guid followerId)
        {
            UserId = userId;
            FollowerId = followerId;
        }

        public Follow()
        {
        }
    }

    public class FollowConfig : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.User).WithMany(c => c.Followers).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.Follower).WithMany(c => c.Followings).HasForeignKey(c => c.FollowerId);
        }
    }
}