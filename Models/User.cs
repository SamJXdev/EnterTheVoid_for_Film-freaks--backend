using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Film.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string UserName { get; set; } = null!;

        [Required, MaxLength(30)]
        public string Name { get; set; } = null!;
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public UserProgress? Progress { get; set; }
        public bool EmailVerified { get; set; } = false;
    }
}