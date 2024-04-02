using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Results;

namespace Totvs.ATS.Service.Mapping
{
    public static class CandidateToManyResultMapping
    {
        public static IList<CandidateResult> Map(this IEnumerable<Candidate> candidate)
        {
            return candidate.Select(c => c.Map()).ToList();
        }
    }
}
