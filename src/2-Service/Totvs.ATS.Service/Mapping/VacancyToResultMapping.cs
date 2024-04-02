using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Mapping
{
    public static class VacancyToResultMapping
    {
        public static VacancyResult Map(this Vacancy vacancy)
        {
            return new VacancyResult
            {
                Id = vacancy.id,
                Title = vacancy.title,
                Description = vacancy.description,
                Requirement = vacancy.requirement.Select(r => r).ToList()
            };
        }
    }
}
