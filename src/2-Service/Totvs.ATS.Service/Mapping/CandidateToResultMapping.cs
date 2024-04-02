using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Mapping
{
    public static class CandidateToResultMapping
    {
        public static CandidateResult Map(this Candidate candidate)
        {
            return new CandidateResult
            {
                Id = candidate.Id,
                Name = candidate.Name,
                Email = candidate.Email,
                Phone = candidate.Phone,
                Linkedin = candidate.Linkedin,
                Curriculum = new CurriculumResult
                {
                    Experiencies = candidate.Curriculum.Experiencies,
                    Educations = candidate.Curriculum.Educations,
                    Habilities = candidate.Curriculum.Habilities
                },
                VacancyIds = candidate.VacancyId
            };
        }
    }
}
