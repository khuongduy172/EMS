namespace EMS.Data.Models.Common;

public abstract class Auditable
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Auditable()
    {
        Id = Guid.NewGuid();
    }
}