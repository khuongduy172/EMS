using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class React : Auditable
    {
        public Guid StatusId { get; set; }
        public Guid UserId { get; set; }
        public string TypeReact { get; set; }

        public virtual Status Status { get; set; } = default!;
        public virtual User User { get; set; } = default!;

        public React(Guid statusId, Guid userId, string typeReact)
        {
            StatusId = statusId;
            UserId = userId;
            TypeReact = typeReact;
        }

        public React()
        {
            TypeReact = string.Empty;
        }
    }

    public class ReactConfig : IEntityTypeConfiguration<React>
    {
        public void Configure(EntityTypeBuilder<React> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.User).WithMany(c => c.Reacts).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.Status).WithMany(c => c.Reacts).HasForeignKey(c => c.StatusId);
        }
    }
}