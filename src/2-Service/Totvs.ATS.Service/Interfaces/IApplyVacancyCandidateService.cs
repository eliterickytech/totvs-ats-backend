using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;

namespace Totvs.ATS.Service.Interfaces
{
    public interface IApplyVacancyCandidateService
    {
        Task<bool> AddAsync(ApplyVacancyCadidateInput input);
        Task<bool> RemoveAsync(Guid candidateId, Guid vacancyId);
    }
}
