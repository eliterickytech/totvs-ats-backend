using AutoMapper;
using ServiceStack;
using Totvs.ATS.Domain;
using Totvs.ATS.Domain.Interfaces.Repository;
using Totvs.ATS.Service.Contract;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Service.Mapping;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Service
{
    public class ApplyVacancyCandidateService : IApplyVacancyCandidateService
    {

        private readonly ICandidateRepository _candidateRepository;
        private readonly IBaseNotification _baseNotification;

        public ApplyVacancyCandidateService(ICandidateRepository candidateRepository, IBaseNotification baseNotification)
        {
            _candidateRepository = candidateRepository;
            _baseNotification = baseNotification;
        }

        public async Task<bool> AddAsync(ApplyVacancyCadidateInput input)
        {
            var contract = new VacancyCandidateAddContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var candidateFounded = await _candidateRepository.GetByIdAsync(input.CandidateId);

            if (candidateFounded == null)
                return false;

            candidateFounded.AddVacancyCandidate(input.VacancyId);

            await _candidateRepository.UpdateAsync(candidateFounded);

            return true;
        }

        public async Task<bool> RemoveAsync(Guid candidateId, Guid vacancyId)
        {

            var contractCandidate = new VacancyCandidateContract(candidateId.ToString());

            if (!contractCandidate.IsValid)
            {
                _baseNotification.AddNotifications(contractCandidate.Notifications);
                return default;
            }

            var contractVacancy = new VacancyCandidateContract(vacancyId.ToString());

            if (!contractVacancy.IsValid)
            {
                _baseNotification.AddNotifications(contractVacancy.Notifications);
                return default;
            }

            var candidateFounded = await _candidateRepository.GetByIdAsync(candidateId);

            if (candidateFounded == null)
                return false;

            candidateFounded.RemoveVacancyCandidate(vacancyId);

            await _candidateRepository.UpdateAsync(candidateFounded);

            return true;
        }
    }
}
