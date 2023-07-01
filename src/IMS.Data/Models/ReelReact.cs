using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IMS.Data.Models.Common;
using IMS.Data.Enums;

namespace social_network.src.Models
{
    public class ReelReact : Auditable
    {
        public Guid ReelId { get; set; }
        public Guid UserId { get; set; }
        public ReactEnums Type { get; set; }

        public virtual Reel Reel { get; set; } = default!;
        public virtual User User { get; set; } = default!;
    }

    public class ReelReactConfig : IEntityTypeConfiguration<ReelReact>
    {
        public void Configure(EntityTypeBuilder<ReelReact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.ReelReacts).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Reel).WithMany(x => x.ReelReacts).HasForeignKey(x => x.ReelId);
        }
    }
}