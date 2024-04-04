
using Bogus;
using System.Collections.Generic;
using Totvs.ATS.Service.Input;

namespace Totvs.ATS.Tests.FakeData
{
    public class VacancyAddInputFaker : Faker<VacancyAddInput>
    {
        public VacancyAddInputFaker()
        {
            RuleFor(v => v.Title, f => f.Lorem.Sentence());
            RuleFor(v => v.Description, f => f.Lorem.Paragraph());
            RuleFor(v => v.Requirement, f => f.Make(5, () => f.Lorem.Word()).ToList());
        }
    }
}
