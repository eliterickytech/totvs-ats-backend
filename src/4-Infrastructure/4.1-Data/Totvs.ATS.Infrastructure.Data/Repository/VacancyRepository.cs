using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Domain.Interfaces.Repository;

namespace Totvs.ATS.Infrastructure.Data.Repository
{
    public class VacancyRepository : BaseRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(IMongoContext context) : base(context)
        {
        }


    }
}
