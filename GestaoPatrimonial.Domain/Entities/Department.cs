using GestaoPatrimonial.Domain.Validation;
using System;
using System.Collections.Generic;

namespace GestaoPatrimonial.Domain.Entities
{
    public sealed class Department : BaseEntity
    {
        public string Initials { get; private set; }
        public int? BranchOfficeId { get; set; }
        public BranchOffice BranchOffice { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<PatrimonialAsset> PatrimonialAssets { get; set; }

        private Department()
        {

        }

        public Department(string name, string initials, int? branchOfficeId, int? companyId)
        {
            ValidationName(name);
            ValidationDepartment(initials);
            BranchOfficeId = branchOfficeId;
            CompanyId = companyId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void Update(string name, string initials, int? branchOfficeId, int? companyId)
        {
            ValidationName(name);
            ValidationDepartment(initials);
            BranchOfficeId = branchOfficeId;
            CompanyId = companyId;
            UpdateAt = DateTime.Now;
        }

        private void ValidationDepartment(string initials)
        {
            DomainExceptionValidation.Validate(initials?.Length > 10, "Sigla do departamento deve ter menos de 10 caracteres");
            Initials = initials;
        }
    }
}
