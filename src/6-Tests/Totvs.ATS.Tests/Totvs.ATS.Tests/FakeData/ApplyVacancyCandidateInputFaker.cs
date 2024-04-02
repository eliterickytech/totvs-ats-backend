namespace Totvs.ATS.Tests.FakeData
{
    using Bogus;
    using System;
    using Totvs.ATS.Service.Input;

    public class ApplyVacancyCandidateInputFaker : Faker<ApplyVacancyCadidateInput>
    {
        public ApplyVacancyCandidateInputFaker()
        {
            RuleFor(a => a.CandidateId, f => f.Random.Guid());
            RuleFor(a => a.VacancyId, f => f.Random.Guid());
        }
    }

}
