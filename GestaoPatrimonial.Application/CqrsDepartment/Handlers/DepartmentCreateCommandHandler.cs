using GestaoPatrimonial.Application.CqrsDepartment.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsDepartment.Handlers
{
    public class DepartmentCreateCommandHandler : IRequestHandler<DepartmentCreateCommand, Department>
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentCreateCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Department> Handle(DepartmentCreateCommand request, CancellationToken cancellationToken)
        {
            Department department = new Department(request.Name, request.Initials, request.BranchOfficeId, request.CompanyId);

            if (department != null)
                return await _repository.CreateAsync(department);

            throw new ArgumentException("Erro ao criar setor");
        }
    }
}
