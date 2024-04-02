using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Interfaces
{
    public interface ICandidateService
    {
        Task<bool> AddAsync(CandidateAddInput input);
        Task<IEnumerable<CandidateResult>> GetAllAsync();
        Task<CandidateResult> GetByEmailAsync(string email);
        Task<CandidateResult> GetByIdAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(CandidateUpdateInput input);
    }
}
