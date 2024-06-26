﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.ATS.Service.Input;
using Totvs.ATS.Shared;

namespace Totvs.ATS.Service.Contract
{
    public class CandidateAddContract : BaseContract<CandidateAddInput>
    {
        public CandidateAddContract(CandidateAddInput input)
        {
            Validate(input);
        }

        protected override void Validate(CandidateAddInput entity)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(entity.Name, "Name", "Name is required")
                .IsNotNullOrWhiteSpace(entity.Email, "Email", "Email is required")
                .IsEmail(entity.Email, "Email", "Email is invalid")
                .IsNotNullOrWhiteSpace(entity.Password, "Password", "Password is required")
                .IsNotNullOrWhiteSpace(entity.Phone, "Phone", "Phone is required")
                //.IsNotNull(entity.Curriculum, "Curriculum", "Curriculum is required")
                );
        }
    }
}
