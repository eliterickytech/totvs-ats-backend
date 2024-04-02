using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Domain.Interfaces.Repository;

namespace Totvs.ATS.Infrastructure.Data.Repository
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(IMongoContext context) : base(context)
        {
        }

        public async Task<Candidate> GetByEmail(string email)
        {
            var data = await DbSet.FindAsync(Builders<Candidate>.Filter.Eq("Email", email));

            return data.SingleOrDefault();
        }
    }
}
