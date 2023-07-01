using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IMS.Data.Models.Common;

namespace social_network.src.Models
{
    public class UserViewStory : Auditable
    {
        public Guid UserId { get; set; }
        public Guid StoryId { get; set; }

        public virtual User User { get; set; } = default!;
        public virtual Story Story { get; set; } = default!;
    }

    public class UserViewStoryConfig : IEntityTypeConfiguration<UserViewStory>
    {
        public void Configure(EntityTypeBuilder<UserViewStory> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(s => s.User).WithMany(u => u.UserViewStories).HasForeignKey(s => s.UserId);
            builder.HasOne(s => s.Story).WithMany(us => us.UserViewStory).HasForeignKey(s => s.StoryId);
        }
    }
}