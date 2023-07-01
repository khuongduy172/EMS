using IMS.Data.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace social_network.src.Models
{
    public class User : Auditable
    {
        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Name = string.Empty;
            Gender = string.Empty;
        }

        public User(string username, string password, string email, string name, DateTime dayOfBirth, string gender)
        {
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Gender = gender;
            DayOfBirth = dayOfBirth;
        }

        public User(string facebookUserId, string name, DateTime dayOfBirth, string gender)
        {
            Username = string.Empty;
            Password = string.Empty;
            Name = name;
            Gender = gender;
            DayOfBirth = dayOfBirth;
            FacebookUserId = facebookUserId;
        }

        public User(string username, string password, string email, string? bio, string name, string? avatar, string? avatarKey, DateTime dayOfBirth, string gender, string? phone, bool isDeleted, DateTime? deletedAt)
        {
            Username = username;
            Password = password;
            Email = email;
            Bio = bio;
            Name = name;
            Avatar = avatar;
            AvatarKey = avatarKey;
            DayOfBirth = dayOfBirth;
            Gender = gender;
            Phone = phone;
            IsDeleted = isDeleted;
            DeletedAt = deletedAt;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public string Name { get; set; }
        public string? Avatar { get; set; }
        public string? AvatarKey { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Gender { get; set; }
        public string? Phone { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string? FacebookUserId { get; set; }

        public virtual ICollection<Status> Statuses { get; set; } = default!;
        public virtual ICollection<Follow> Followers { get; set; } = default!;
        public virtual ICollection<Follow> Followings { get; set; } = default!;
        public virtual ICollection<React> Reacts { get; set; } = default!;
        public virtual ICollection<Comment> Comments { get; set; } = default!;
        public virtual ICollection<Message> SendTo { get; set; } = default!;
        public virtual ICollection<Message> ReceiveFrom { get; set; } = default!;
        public virtual ICollection<Story> Stories { get; set; } = default!;
        public virtual ICollection<UserViewStory> UserViewStories { get; set; } = default!;
        public virtual ICollection<Reel> Reels { get; set; } = default!;
        public virtual ICollection<UserViewReel> UserViewReels { get; set; } = default!;
        public virtual ICollection<ReelReact> ReelReacts { get; set; } = default!;
        public virtual ICollection<ReelComment> ReelComments { get; set; } = default!;

        public User Update(string? bio, string? name, DateTime? dayOfBirth, string? gender, string? phone, string? username)
        {
            if (bio != null && bio != Bio) Bio = bio;
            if (name != null && name != Name) Name = name;
            if (dayOfBirth != null && dayOfBirth != DayOfBirth) DayOfBirth = (DateTime)dayOfBirth;
            if (gender != null && gender != Gender) Gender = gender;
            if (phone != null && phone != Phone) Phone = phone;
            if (username != null && username != Username) Username = username;
            return this;
        }

        public User Update(string? avatar, string? avatarKey)
        {
            if (avatar != null && avatar != Avatar) Avatar = avatar;
            if (avatarKey != null && avatarKey != AvatarKey) AvatarKey = avatarKey;
            return this;
        }
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasMany(c => c.Statuses).WithOne(c => c.Owner).HasForeignKey(c => c.OwnerId);
            builder.HasMany(c => c.Comments).WithOne(c => c.Owner).HasForeignKey(c => c.OwnerId);
            builder.HasMany(c => c.Reacts).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            builder.HasMany(c => c.Followers).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            builder.HasMany(c => c.Followings).WithOne(c => c.Follower).HasForeignKey(c => c.FollowerId);
            builder.HasMany(c => c.SendTo).WithOne(c => c.Sender).HasForeignKey(c => c.SenderId);
            builder.HasMany(c => c.ReceiveFrom).WithOne(c => c.Receiver).HasForeignKey(c => c.ReceiverId);
            builder.HasMany(c => c.Stories).WithOne(c => c.Owner).HasForeignKey(c => c.OwnerId);
            builder.HasMany(c => c.UserViewStories).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            builder.HasMany(c => c.Reels).WithOne(c => c.Owner).HasForeignKey(c => c.OwnerId);
            builder.HasMany(c => c.UserViewReels).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            builder.HasMany(c => c.ReelReacts).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            builder.HasMany(c => c.ReelComments).WithOne(c => c.Owner).HasForeignKey(c => c.OwnerId);
        }
    }
}