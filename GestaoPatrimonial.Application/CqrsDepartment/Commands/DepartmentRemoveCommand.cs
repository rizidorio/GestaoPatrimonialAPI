using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsDepartment.Commands
{
    public class DepartmentRemoveCommand : IRequest<Department>
    {
        public int Id { get; set; }

        public DepartmentRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
