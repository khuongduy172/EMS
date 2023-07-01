using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using social_network.src.Models;
using System.Reflection;

namespace IMS.Data.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<React> Reacts { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<StatusImage> StatusImages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<UserViewStory> UserViewStories { get; set; }
    public DbSet<Reel> Reels { get; set; }
    public DbSet<UserViewReel> UserViewReels { get; set; }
    public DbSet<UserViewStatus> UserViewStatuses { get; set; }
    public DbSet<ReelReact> ReelReacts { get; set; }
    public DbSet<ReelComment> ReelComments { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken c)
    {
        AddTimestamps();
        return await base.SaveChangesAsync(c);
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(x => x.Entity is Auditable && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;

            if (entity.State == EntityState.Added)
            {
                ((Auditable)entity.Entity).CreatedAt = now;
            }
            ((Auditable)entity.Entity).UpdatedAt = now;
        }
    }
}