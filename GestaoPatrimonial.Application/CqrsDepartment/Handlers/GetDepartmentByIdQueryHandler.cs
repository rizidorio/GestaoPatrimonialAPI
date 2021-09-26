using GestaoPatrimonial.Application.CqrsDepartment.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsDepartment.Handlers
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
