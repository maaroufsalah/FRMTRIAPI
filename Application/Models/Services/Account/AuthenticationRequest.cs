using System.ComponentModel.DataAnnotations;

namespace Application.Models.Services.Account
{
    public class AuthenticationRequest
    {
        //[Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public string UserName { get; set; }
        //[Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = "Required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}