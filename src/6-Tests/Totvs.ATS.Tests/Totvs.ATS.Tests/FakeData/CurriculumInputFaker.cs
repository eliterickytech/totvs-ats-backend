using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Tests.FakeData
{
    using Bogus;
    using System;
    using Totvs.ATS.Service.Input;

    public class CurriculumInputFaker : Faker<CurriculumInput>
    {
        public CurriculumInputFaker()
        {
            RuleFor(c => c.Experiencies, f => f.Make(5, () => f.Lorem.Sentence()).ToList());
            RuleFor(c => c.Educations, f => f.Make(3, () => f.Lorem.Sentence()).ToList());
            RuleFor(c => c.Habilities, f => f.Make(5, () => f.Random.Word()).ToList());
        }
    }
}
