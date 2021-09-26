using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsDepartment.Queries
{
    public class GetDepartmentQuery : IRequest<IEnumerable<Department>>
    {
    }
}
