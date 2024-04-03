using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Shared;

namespace Totvs.ATS.Service.Contract
{
    public class LoginContract : BaseContract<LoginInput>
    {
        public LoginContract(LoginInput input)
        {
            Validate(input);
        }

        protected override void Validate(LoginInput entity)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(entity.Email, "Email", "Email is required")
                .IsNotNullOrWhiteSpace(entity.Password, "Password", "Password is required"));
        }
    }
}
