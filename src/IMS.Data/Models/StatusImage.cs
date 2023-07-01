using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using IMS.Data.Models.Common;

namespace social_network.src.Models
{
    public class StatusImage : Auditable
    {
        public StatusImage()
        {
            Name = string.Empty;
            Url = string.Empty;
        }

        public StatusImage(string name, Guid statusId, string url)
        {
            Name = name;
            StatusId = statusId;
            Url = url;
        }

        public string Name { get; set; }
        public Guid StatusId { get; set; }
        public string Url { get; set; }

        public virtual Status Status { get; set; } = default!;
    }

    public class StatusImageConfig : IEntityTypeConfiguration<StatusImage>
    {
        public void Configure(EntityTypeBuilder<StatusImage> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Status).WithMany(c => c.StatusImages).HasForeignKey(c => c.StatusId);
        }
    }
}