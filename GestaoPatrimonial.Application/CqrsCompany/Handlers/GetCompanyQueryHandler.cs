using GestaoPatrimonial.Application.CqrsCompany.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsCompany.Handlers
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, IEnumerable<Company>>
    {
        private readonly ICompanyRepository _repository;

        public GetCompanyQueryHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Company>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
