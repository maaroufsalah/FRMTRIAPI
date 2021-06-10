using Application.Models.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IHelper
{
    public interface ITokenService
    {
        string CreateToken(AuthenticationRequest authenticationRequest);
    }
}
