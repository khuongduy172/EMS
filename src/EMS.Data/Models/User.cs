using EMS.Data.Models.Common;
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
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}