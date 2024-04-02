using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain.Interfaces.Repository;
using Totvs.ATS.Service.Contract;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Interfaces;
using Totvs.ATS.Service.Mapping;
using Totvs.ATS.Service.Results;
using Totvs.ATS.Shared.Interfaces;

namespace Totvs.ATS.Service
{
    public class VacancyService : IVacancyService
    {
        public readonly IVacancyRepository _vacancyRepository;
        public readonly IBaseNotification _baseNotification;
        public VacancyService(IVacancyRepository vacancyRepository, IBaseNotification baseNotification)
        {
            _vacancyRepository = vacancyRepository;
            _baseNotification = baseNotification;
        }

        public async Task<bool> AddAsync(VacancyAddInput input)
        {
            var contract = new VacancyAddContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var vacancy = input.Map();

            await _vacancyRepository.AddAsync(vacancy);

            return true;
        }

        public async Task<bool> UpdateAsync(VacancyUpdateInput input)
        {
            var contract = new VacancyUpdateContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var vacancyFounded = await _vacancyRepository.GetByIdAsync(input.Id);

            if (vacancyFounded == null)
                return false;

            var vacancy = input.Map();

            await _vacancyRepository.UpdateAsync(vacancy);

            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var contract = new VacancyRemoveContract(id.ToString());

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var vacancyFounded = await _vacancyRepository.GetByIdAsync(id);

            if (vacancyFounded == null)
                return false;

            await _vacancyRepository.RemoveAsync(id);

            return true;
        }

        public async Task<VacancyResult> GetByIdAsync(Guid id)
        {
            var contract = new VacancyRemoveContract(id.ToString());

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var result = await _vacancyRepository.GetByIdAsync(id);

            if (result == null)
                return null;

            return result.Map();
        }

        public async Task<IEnumerable<VacancyResult>> GetAllAsync()
        {
            var result = await _vacancyRepository.GetAllAsync();

            return result.Map();
        }
    }
}
