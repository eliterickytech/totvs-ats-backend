using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Domain;

namespace Totvs.ATS.Service.Input
{
    public class CandidateUpdateInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Linkedin { get; set; }

        public IList<string> Experiencies { get; set; }

        public IList<string> Educations { get; set; }

        public IList<string> Habilities { get; set; }

    }
}
