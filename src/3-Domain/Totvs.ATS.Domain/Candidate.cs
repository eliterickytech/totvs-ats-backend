using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.ATS.Domain
{

    public class Candidate()
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; } = nameof(PermissionType.Candidate);
        public string Linkedin { get; set; }
        public Curriculum Curriculum { get; set; }

        public List<Guid> VacancyId { get; set; } = new List<Guid>();

        public void AddVacancyCandidate(Guid vacancyId)
        {
            this.VacancyId.Add(vacancyId);
        }

        public void RemoveVacancyCandidate(Guid vacancyId)
        {
            this.VacancyId.Remove(vacancyId);
        }

    }
    public enum PermissionType
    {
        Admin = 1,
        Candidate = 2
    }
}
