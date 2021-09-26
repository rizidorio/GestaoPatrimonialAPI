using GestaoPatrimonial.Application.CqrsCategory.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsCategory.Handlers

{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryCreateCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category(request.Name);

            if (category == null)
                throw new ArgumentException("Erro ao criar categoria");

            return await _repository.CreateAsync(category);
        }
    }
}
