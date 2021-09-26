using GestaoPatrimonial.Application.CqrsSubcategory.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Handlers
{
    public class SubcategoryCreateCommandHandler : IRequestHandler<SubcategoryCreateCommand, Subcategory>
    {
        private readonly ISubcategoryRepository _repository;

        public SubcategoryCreateCommandHandler(ISubcategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Subcategory> Handle(SubcategoryCreateCommand request, CancellationToken cancellationToken)
        {
            Subcategory subcategory = new Subcategory(request.Name, request.CategoryId);

            if (subcategory != null)
                return await _repository.CreateAsync(subcategory);

            throw new ArgumentException("Erro ao criar subcategoria");
        }
    }
}
