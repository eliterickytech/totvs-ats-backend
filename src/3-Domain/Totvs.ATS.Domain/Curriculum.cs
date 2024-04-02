using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Domain
{
    public class Curriculum
    {
        public IList<string> Experiencies { get; set; }

        public IList<string> Educations { get; set; }

        public IList<string> Habilities { get; set;}
    }
}
