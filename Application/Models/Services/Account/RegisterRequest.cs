using Application.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Services.Account
{
    public class RegisterRequest
    {

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string RoleId { get; set; }

        [Required(ErrorMessage = ApplicationMessage.ChampObligatoire)]
        [MinLength(6, ErrorMessage = "Le nom d'utilisateur doit contient plus que 6 caractères")]
        public string UserName { get; set; }

        [Required(ErrorMessage = ApplicationMessage.ChampObligatoire)]
        [StringLength(100, ErrorMessage = "Le mot de passe doit contient plus que 4 caractères", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = ApplicationMessage.ChampObligatoire)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

    }
}