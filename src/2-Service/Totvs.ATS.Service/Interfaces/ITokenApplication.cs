using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Interfaces
{
    public interface ITokenApplication
    {
        string GenerateToken(CandidateResult candidate);
    }
}
