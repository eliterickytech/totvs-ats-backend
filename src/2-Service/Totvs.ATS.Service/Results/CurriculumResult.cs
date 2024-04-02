using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Service.Results
{
    public class CurriculumResult
    {
        public IList<string> Experiencies { get; set; }

        public IList<string> Educations { get; set; }

        public IList<string> Habilities { get; set; }
    }
}
