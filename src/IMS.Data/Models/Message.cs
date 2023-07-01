using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IMS.Data.Models.Common;

namespace social_network.src.Models
{
    public class Message : Auditable
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageKey { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User Sender { get; set; } = default!;
        public virtual User Receiver { get; set; } = default!;

        public Message(Guid senderId, Guid receiverId, string? content, string? imageUrl, string? imageKey)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            IsRead = false;
            IsDeleted = false;
            ImageKey = imageKey;
            ImageUrl = imageUrl;
        }

        public Message()
        {
        }
    }

    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Sender).WithMany(c => c.SendTo).HasForeignKey(c => c.SenderId);
            builder.HasOne(c => c.Receiver).WithMany(c => c.ReceiveFrom).HasForeignKey(c => c.ReceiverId);
        }
    }
}