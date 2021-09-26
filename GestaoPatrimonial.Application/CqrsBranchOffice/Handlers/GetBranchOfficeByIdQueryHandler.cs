using GestaoPatrimonial.Application.CqrsBranchOffice.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Handlers
{
    public class GetBranchOfficeByIdQueryHandler : IRequestHandler<GetBranchOfficeByIdQuery, BranchOffice>
    {
        private readonly IBrachOfficeRepository _repository;

        public GetBranchOfficeByIdQueryHandler(IBrachOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<BranchOffice> Handle(GetBranchOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
