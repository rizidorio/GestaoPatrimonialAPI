using GestaoPatrimonial.Application.CqrsCategory.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsCategory.Handlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommand, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryUpdateCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            Category findCategory = await _repository.GetAsync(request.Id);

            if (findCategory != null)
            {
                findCategory.Update(request.Name);

                return await _repository.UpdateAsync(findCategory);
            }

            throw new ArgumentException("Categoria não encontrada");
        }
    }
}
