using Newtonsoft.Json;
using System.Collections.Generic;

namespace Application.Models.Services.Account
{
    public class AuthenticatedUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string JWToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}