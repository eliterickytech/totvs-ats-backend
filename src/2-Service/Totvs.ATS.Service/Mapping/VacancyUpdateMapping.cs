using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Input;

namespace Totvs.ATS.Service.Mapping
{
    public static class VacancyUpdateMapping
    {
        public static Vacancy Map(this VacancyUpdateInput input)
        {
            return new Vacancy(input.Id, input.Title, input.Description, input.Requirement);
        }
    }
}
