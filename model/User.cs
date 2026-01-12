using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace user_management_api.model
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string? FirstName { get; set; } = null!;

        public string? LastName { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "UserName must be between 3 and 50 characters")]
        public string UserName { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}
