using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Shared;

namespace Totvs.ATS.Service.Contract
{
    public class VacancyUpdateContract : BaseContract<VacancyUpdateInput>
    {
        public VacancyUpdateContract(VacancyUpdateInput input)
        {
            Validate(input);
        }

        protected override void Validate(VacancyUpdateInput entity)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(entity.Title, "Title", "Title is required")
                .IsNotNullOrWhiteSpace(entity.Description, "Description", "Description is required")
                .IsNotNull(entity.Requirement, "Requirement", "Requirement is required")
                .IsNotNullOrWhiteSpace(entity.Id.ToString(), "Id", "Id is required")
                );
        }
    }
}
