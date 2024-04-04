using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Crosscuting.Shared;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Input;

namespace Totvs.ATS.Service.Mapping
{
    public static class CandidateAddMapping
    {
        public static Candidate Map(this CandidateAddInput input)
        {
            var candidate = new Candidate
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                Email = input.Email,
                Password = input.Password,
                Phone = input.Phone,
                Linkedin = input.Linkedin,
                Curriculum = new Curriculum
                {
                    Experiencies = input.Experiencies,
                    Educations = input.Educations,
                    Habilities = input.Habilities
                }
            };

            candidate.Password = Utils.EncodePassword(candidate);

            return candidate;
        }
    }
}
