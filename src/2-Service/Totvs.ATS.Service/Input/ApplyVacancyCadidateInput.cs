﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Service.Input
{
    public class ApplyVacancyCadidateInput
    {
        public Guid CandidateId { get; set; }
        public Guid VacancyId { get; set; }
    }
}