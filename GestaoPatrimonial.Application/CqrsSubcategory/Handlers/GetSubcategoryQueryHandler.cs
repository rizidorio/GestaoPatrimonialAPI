using GestaoPatrimonial.Application.CqrsSubcategory.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Handlers
{
    public class GetSubcategoryQueryHandler : IRequestHandler<GetSubcategoryQuery, IEnumerable<Subcategory>>
    {
        private readonly ISubcategoryRepository _repository;

        public GetSubcategoryQueryHandler(ISubcategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Subcategory>> Handle(GetSubcategoryQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
