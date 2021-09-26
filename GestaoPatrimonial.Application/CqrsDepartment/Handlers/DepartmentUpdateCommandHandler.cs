using GestaoPatrimonial.Application.CqrsDepartment.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsDepartment.Handlers
{
    public class DepartmentUpdateCommandHandler : IRequestHandler<DepartmentUpdateCommand, Department>
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentUpdateCommandHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Department> Handle(DepartmentUpdateCommand request, CancellationToken cancellationToken)
        {
            Department findDepartment = await _repository.GetAsync(request.Id);

            if (findDepartment != null)
            {
                findDepartment.Update(request.Name, request.Initials, request.BranchOfficeId, request.CompanyId);

                return await _repository.UpdateAsync(findDepartment);
            }

            throw new ArgumentException("Setor não encontrado.");
        }
    }
}
