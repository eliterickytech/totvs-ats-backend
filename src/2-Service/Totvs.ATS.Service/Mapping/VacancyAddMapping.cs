using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Input;

namespace Totvs.ATS.Service.Mapping
{
    public static class VacancyAddMapping
    {
        public static Vacancy Map(this VacancyAddInput input)
        {
            return new Vacancy(Guid.NewGuid(), input.Title, input.Description, input.Requirement);
        }
    }
}
