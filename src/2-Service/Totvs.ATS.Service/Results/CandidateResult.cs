using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;

namespace Totvs.ATS.Service.Results
{
    public class CandidateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Linkedin { get; set; }
        public CurriculumResult Curriculum { get; set; }
        public List<Guid> VacancyIds { get; set; } = new List<Guid>();
    }
}
