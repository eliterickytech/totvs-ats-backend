using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Interfaces
{
    public interface IVacancyService
    {
        Task<bool> AddAsync(VacancyAddInput input);
        Task<IEnumerable<VacancyResult>> GetAllAsync();
        Task<VacancyResult> GetByIdAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(VacancyUpdateInput input);
    }
}
