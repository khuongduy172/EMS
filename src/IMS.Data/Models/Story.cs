using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IMS.Data.Models.Common;
using IMS.Data.Enums;

namespace social_network.src.Models
{
    public class Story : Auditable
    {
        public Story(string url, string key, Guid ownerId, StoryTypeEnum type)
        {
            Url = url;
            Key = key;
            OwnerId = ownerId;
            Type = type;
        }

        public string Url { get; set; }
        public string Key { get; set; }
        public StoryTypeEnum Type { get; set; }
        public Guid OwnerId { get; set; }

        public virtual User Owner { get; set; } = default!;
        public virtual ICollection<UserViewStory> UserViewStory { get; set; } = default!;
    }

    public class StoryConfig : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(s => s.Owner).WithMany(u => u.Stories).HasForeignKey(s => s.OwnerId);
            builder.HasMany(s => s.UserViewStory).WithOne(us => us.Story).HasForeignKey(s => s.StoryId);
        }
    }
}