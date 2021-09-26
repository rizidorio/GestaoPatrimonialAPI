using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsDepartment.Queries
{
    public class GetDepartmentByInitialsQuery : IRequest<Department>
    {
        public string Initials { get; set; }

        public GetDepartmentByInitialsQuery(string initials)
        {
            Initials = initials;
        }
    }
}
