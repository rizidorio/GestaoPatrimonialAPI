using GestaoPatrimonial.Application.CqrsDepartment.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsDepartment.Handlers
{
    public class DepartmentRemoveCommandHandler : IRequestHandler<DepartmentRemoveCommand, Department>
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentRemoveCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Department> Handle(DepartmentRemoveCommand request, CancellationToken cancellationToken)
        {
            Department findDepartment = await _repository.GetAsync(request.Id);

            if (findDepartment != null)
                return await _repository.DeleteAsync(findDepartment);

            throw new ArgumentException("Setor não encontrado");
        }
    }
}
