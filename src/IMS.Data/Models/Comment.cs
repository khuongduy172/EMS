using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class Comment : Auditable
    {
        public Guid StatusId { get; set; }
        public Guid OwnerId { get; set; }
        public string? Content { get; set; }

        public virtual Status Status { get; set; } = default!;
        public virtual User Owner { get; set; } = default!;

        public Comment(Guid statusId, Guid ownerId, string? content)
        {
            StatusId = statusId;
            OwnerId = ownerId;
            Content = content;
        }

        public Comment()
        {
        }
    }

    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Owner).WithMany(c => c.Comments).HasForeignKey(c => c.OwnerId);
            builder.HasOne(c => c.Status).WithMany(c => c.Comments).HasForeignKey(c => c.StatusId);
        }
    }
}