using System.ComponentModel.DataAnnotations;

namespace Application.Models.Services.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
