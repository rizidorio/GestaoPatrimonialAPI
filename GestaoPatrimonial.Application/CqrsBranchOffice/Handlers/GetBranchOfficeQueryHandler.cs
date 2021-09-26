using GestaoPatrimonial.Application.CqrsBranchOffice.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Handlers
{
    public class GetBranchOfficeQueryHandler : IRequestHandler<GetBranchOfficeQuery, IEnumerable<BranchOffice>>
    {
        private readonly IBrachOfficeRepository _repository;

        public GetBranchOfficeQueryHandler(IBrachOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BranchOffice>> Handle(GetBranchOfficeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
