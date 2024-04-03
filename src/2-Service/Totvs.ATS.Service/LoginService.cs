using ServiceStack.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Crosscuting.Shared;
using Totvs.ATS.Domain.Interfaces.Repository;
using Totvs.ATS.Service.Contract;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Service.Mapping;
using Totvs.ATS.Service.Results;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Service
{
    public class LoginService : ILoginService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IBaseNotification _baseNotification;
        private readonly ITokenApplication _tokenApplication;

        public LoginService(ICandidateRepository candidateRepository, IBaseNotification baseNotification, ITokenApplication tokenApplication)
        {
            _candidateRepository = candidateRepository;
            _baseNotification = baseNotification;
            _tokenApplication = tokenApplication;
        }

        public async Task<LoginResult> AuthenticationAsync(LoginInput login)
        {
            var contract = new LoginContract(login);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var result = await _candidateRepository.GetByEmail(login.Email);

            if ((result is { Email: null }))
                return default;
            
            if (!Utils.VerifyPassword(result, login.Password))
                return default;

            var map = result.Map();

            var token = _tokenApplication.GenerateToken(map);

            return new LoginResult() { Id = map.Id, Token = token };
        }
    }
}
