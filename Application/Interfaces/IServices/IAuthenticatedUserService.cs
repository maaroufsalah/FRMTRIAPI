using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IAuthenticatedUserService
    {
        public string UserId { get; }
        public string UserName { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public string Email { get; }
        public string[] UserRoles { get; }

    }
}
