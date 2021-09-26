using GestaoPatrimonial.Application.CqrsDepartment.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsDepartment.Handlers
{
    public class GetDepartmentByInitialsQueryHandler : IRequestHandler<GetDepartmentByInitialsQuery, Department>
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentByInitialsQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Department> Handle(GetDepartmentByInitialsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByInitialsAsync(request.Initials);
        }
    }
}
