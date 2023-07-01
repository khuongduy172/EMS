using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class Reel : Auditable
    {
        public Reel()
        {
            Url = string.Empty;
            Key = string.Empty;
            ThumbnailKey = string.Empty;
            ThumbnailUrl = string.Empty;
        }

        public Reel(string url, string key)
        {
            Url = url;
            Key = key;
            ThumbnailKey = string.Empty;
            ThumbnailUrl = string.Empty;
        }

        public string Url { get; set; }
        public string Key { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ThumbnailKey { get; set; }
        public string? Caption { get; set; }
        public Guid OwnerId { get; set; }

        public virtual User Owner { get; set; } = default!;
        public virtual ICollection<UserViewReel> UserViewReel { get; set; } = default!;
        public virtual ICollection<ReelReact> ReelReacts { get; set; } = default!;
        public virtual ICollection<ReelComment> ReelComments { get; set; } = default!;
    }

    public class ReelConfig : IEntityTypeConfiguration<Reel>
    {
        public void Configure(EntityTypeBuilder<Reel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.UserViewReel).WithOne(x => x.Reel).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.ReelReacts).WithOne(x => x.Reel).HasForeignKey(x => x.ReelId);
            builder.HasMany(x => x.ReelComments).WithOne(x => x.Reel).HasForeignKey(x => x.ReelId);
            builder.HasOne(x => x.Owner).WithMany(x => x.Reels).HasForeignKey(x => x.OwnerId);
        }
    }
}