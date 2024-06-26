﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Shared;

namespace Totvs.ATS.Service.Contract
{
    public class VacancyAddContract : BaseContract<VacancyAddInput>
    {
        public VacancyAddContract(VacancyAddInput input)
        {
            Validate(input);
        }

        protected override void Validate(VacancyAddInput entity)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(entity.Title, "Title", "Title is required")
                .IsNotNullOrWhiteSpace(entity.Description, "Description", "Description is required")
                .IsNotNull(entity.Requirement, "Requirement", "Requirement is required")
                );
        }
    }
}
