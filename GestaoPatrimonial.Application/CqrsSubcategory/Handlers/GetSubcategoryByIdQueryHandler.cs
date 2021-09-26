using GestaoPatrimonial.Application.CqrsSubcategory.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Handlers
{
    public class GetSubcategoryByIdQueryHandler : IRequestHandler<GetSubcategoryByIdQuery, Subcategory>
    {
        private readonly ISubcategoryRepository _repository;

        public GetSubcategoryByIdQueryHandler(ISubcategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Subcategory> Handle(GetSubcategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.Id);
        }
    }
}
