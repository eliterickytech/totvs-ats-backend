using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Shared;

namespace Totvs.ATS.Service.Contract
{
    public class VacancyCandidateAddContract : BaseContract<ApplyVacancyCadidateInput>
    {
        public VacancyCandidateAddContract(ApplyVacancyCadidateInput input)
        {
            Validate(input);
        }

        protected override void Validate(ApplyVacancyCadidateInput entity)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(entity.CandidateId.ToString(), "CandidateId", "CandidateId is required")
                .IsNotNullOrWhiteSpace(entity.VacancyId.ToString(), "VacancyId", "VacancyId is required"));
        }
    }
}
