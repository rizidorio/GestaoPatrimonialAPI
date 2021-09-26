using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsDepartment.Commands
{
    public class DepartmentCommand : IRequest<Department>
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public int? BranchOfficeId { get; set; }
        public int? CompanyId { get; set; }
    }
}
