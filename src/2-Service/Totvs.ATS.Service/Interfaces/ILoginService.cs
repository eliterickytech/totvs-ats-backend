using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResult> AuthenticationAsync(LoginInput login);
    }
}
