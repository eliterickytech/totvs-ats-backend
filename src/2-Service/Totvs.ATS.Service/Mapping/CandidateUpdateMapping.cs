using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;
using Totvs.ATS.Service.Input;

namespace Totvs.ATS.Service.Mapping
{
    public static class CandidateUpdateMapping
    {
        public static Candidate Map(this CandidateUpdateInput input)
        {
            return new Candidate
            {
                Id = input.Id,
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                Linkedin = input.Linkedin,
                Curriculum = new Curriculum
                {
                    Experiencies = input.Curriculum.Experiencies,
                    Educations = input.Curriculum.Educations,
                    Habilities = input.Curriculum.Habilities
                }
            };
        }
    }
}
