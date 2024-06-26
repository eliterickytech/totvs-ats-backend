﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Domain.Interfaces.Repository
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Task<Candidate> GetByEmail(string email);
    }
}
