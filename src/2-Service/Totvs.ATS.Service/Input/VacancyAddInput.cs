using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Service.Input
{
    public class VacancyAddInput
    {
        public string Title { get; set; }  
        
        public string Description { get; set; }

        public List<string> Requirement { get; set; }
    }
}
