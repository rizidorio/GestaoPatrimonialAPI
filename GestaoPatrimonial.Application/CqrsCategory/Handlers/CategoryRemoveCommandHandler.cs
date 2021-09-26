using GestaoPatrimonial.Application.CqrsCategory.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsCategory.Handlers
{
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryRemoveCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(CategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            Category findCategory = await _repository.GetAsync(request.Id);

            if (findCategory != null)
                return await _repository.DeleteAsync(findCategory);

            throw new ArgumentException("Categoria não encontrada");
        }
    }
}
