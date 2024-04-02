using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Shared;

namespace Totvs.ATS.Service.Contract
{
    public class CandidateRemoveContract : BaseContract<string>
    {
        public CandidateRemoveContract(string input)
        {
            Validate(input);
        }

        protected override void Validate(string entity)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()

                .IsNotNullOrWhiteSpace(entity, "Id", "Id is required"));

        }
    }
}
