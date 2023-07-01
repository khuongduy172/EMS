using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class Status : Auditable
    {
        public string? Content { get; set; }
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; } = default!;
        public virtual ICollection<React> Reacts { get; set; } = default!;
        public virtual ICollection<Comment> Comments { get; set; } = default!;
        public virtual ICollection<StatusImage> StatusImages { get; set; } = default!;
        public virtual ICollection<UserViewStatus> UserViewStatuses { get; set; } = default!;

        public Status(string? content, Guid ownerId)
        {
            Content = content;
            OwnerId = ownerId;
        }

        public Status()
        {
        }
    }

    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Comments).WithOne(c => c.Status).HasForeignKey(c => c.StatusId);
            builder.HasMany(c => c.Reacts).WithOne(c => c.Status).HasForeignKey(c => c.StatusId);
            builder.HasMany(c => c.StatusImages).WithOne(c => c.Status).HasForeignKey(c => c.StatusId);
            builder.HasOne(c => c.Owner).WithMany(c => c.Statuses).HasForeignKey(c => c.OwnerId);
            builder.HasMany(x => x.UserViewStatuses).WithOne(x => x.Status).HasForeignKey(x => x.StatusId);
        }
    }
}