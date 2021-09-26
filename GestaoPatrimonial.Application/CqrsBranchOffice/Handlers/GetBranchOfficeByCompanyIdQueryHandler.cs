using GestaoPatrimonial.Application.CqrsBranchOffice.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Handlers
{
    public class GetBranchOfficeByCompanyIdQueryHandler : IRequestHandler<GetBranchOfficeByCompanyQuery, IEnumerable<BranchOffice>>
    {
        private readonly IBrachOfficeRepository _repository;

        public GetBranchOfficeByCompanyIdQueryHandler(IBrachOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BranchOffice>> Handle(GetBranchOfficeByCompanyQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListByCompanyAsync(request.CompanyId);
        }
    }
}
