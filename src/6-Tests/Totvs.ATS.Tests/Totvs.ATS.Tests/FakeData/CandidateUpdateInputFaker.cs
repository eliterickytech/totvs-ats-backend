

namespace Totvs.ATS.Tests.FakeData
{
    using Bogus;
    using System;
    using Totvs.ATS.Service.Input;

    public class CandidateUpdateInputFaker : Faker<CandidateUpdateInput>
    {
        public CandidateUpdateInputFaker()
        {
            RuleFor(c => c.Id, f => f.Random.Guid());
            RuleFor(c => c.Name, f => f.Name.FullName());
            RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Name));
            RuleFor(c => c.Password, f => f.Internet.Password());
            RuleFor(c => c.Phone, f => f.Phone.PhoneNumber());
            RuleFor(c => c.Linkedin, f => $"https://www.linkedin.com/in/{f.Internet.UserName()}");
            RuleFor(c => c.Curriculum, f => new CurriculumInputFaker().Generate());
        }
    }


}
