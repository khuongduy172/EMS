using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IMS.Data.Models.Common;

namespace social_network.src.Models
{
    public class ReelComment : Auditable
    {
        public Guid ReelId { get; set; }
        public Guid OwnerId { get; set; }
        public string? Content { get; set; }

        public virtual Reel Reel { get; set; } = default!;
        public virtual User Owner { get; set; } = default!;
    }

    public class ReelCommentConfig : IEntityTypeConfiguration<ReelComment>
    {
        public void Configure(EntityTypeBuilder<ReelComment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Owner).WithMany(x => x.ReelComments).HasForeignKey(x => x.OwnerId);
            builder.HasOne(x => x.Reel).WithMany(x => x.ReelComments).HasForeignKey(x => x.ReelId);
        }
    }
}