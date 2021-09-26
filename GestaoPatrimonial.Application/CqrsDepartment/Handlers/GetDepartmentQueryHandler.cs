using GestaoPatrimonial.Application.CqrsDepartment.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsDepartment.Handlers
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, IEnumerable<Department>>
    {
        private readonly IDepartmentRepository _repository;

        public GetDepartmentQueryHandler(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
