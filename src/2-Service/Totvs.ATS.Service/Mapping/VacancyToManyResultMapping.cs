using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Mapping
{
    public static class VacancyToManyResultMapping
    {
        public static IList<VacancyResult> Map(this IEnumerable<Vacancy> vacancies)
        {
            return vacancies.Select(v => new VacancyResult
            {
                Id = v.id,
                Title = v.title,
                Description = v.description,
                Requirement = v.requirement.Select(r => r).ToList()
            }).ToList();
        }
    }
}
