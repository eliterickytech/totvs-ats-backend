using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Domain
{
    public record Vacancy(Guid id, string title, string description, List<string> requirement );
}
