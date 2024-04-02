using AutoMapper;
using ServiceStack.Html;
using Totvs.ATS.Domain;
using Totvs.ATS.Domain.Interfaces.Repository;
using Totvs.ATS.Service.Contract;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Service.Mapping;
using Totvs.ATS.Service.Results;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IBaseNotification _baseNotification;

        public CandidateService(ICandidateRepository candidateRepository, IBaseNotification baseNotification)
        {
            _candidateRepository = candidateRepository;
            _baseNotification = baseNotification;
        }

        public async Task<IEnumerable<CandidateResult>> GetAllAsync()
        {
            var result = await _candidateRepository.GetAllAsync();
            return result.Map();
        }

        public async Task<CandidateResult> GetByIdAsync(Guid id)
        {
            var contract = new CandidateRemoveContract(id.ToString());

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }
            var result = await _candidateRepository.GetByIdAsync(id);

            if ((result is {  Email: null }))
                return null;

            return result.Map();
        }

        public async Task<CandidateResult> GetByEmailAsync(string email)
        {
            var result = await _candidateRepository.GetByEmail(email);

            if ((result is { Email: null }))
                return null;

            return result.Map();
        }

        public async Task<bool> AddAsync(CandidateAddInput input)
        {
            var contract = new CandidateAddContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = input.Map();

            await _candidateRepository.AddAsync(map);

            return true;
        }

        public async Task<bool> UpdateAsync(CandidateUpdateInput input)
        {
            var contract = new CandidateUpdateContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var candidateFounded = await _candidateRepository.GetByIdAsync(input.Id);

            if (candidateFounded == null)
                return false;

            var map = input.Map();

            await _candidateRepository.UpdateAsync(map);

            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var contract = new CandidateRemoveContract(id.ToString());

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var candidate = await _candidateRepository.GetByIdAsync(id);

            if (candidate == null)
                return false;

            await _candidateRepository.RemoveAsync(id);

            return true;
        }
    }
}
