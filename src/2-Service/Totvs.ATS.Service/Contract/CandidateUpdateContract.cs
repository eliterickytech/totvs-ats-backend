using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Shared;

namespace Totvs.ATS.Service.Contract
{
    public class CandidateUpdateContract : BaseContract<CandidateUpdateInput>
    {
        public CandidateUpdateContract(CandidateUpdateInput input)
        {
            Validate(input);
        }

        protected override void Validate(CandidateUpdateInput entity)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(entity.Name, "Name", "Name is required")
                .IsNotNullOrWhiteSpace(entity.Email, "Email", "Email is required")
                .IsEmail(entity.Email, "Email", "Email is invalid")
                .IsNotNullOrWhiteSpace(entity.Phone, "Phone", "Phone is required")
                .IsNotNullOrWhiteSpace(entity.Id.ToString(), "Id", "Id is required")
                );
        }
    }
}
