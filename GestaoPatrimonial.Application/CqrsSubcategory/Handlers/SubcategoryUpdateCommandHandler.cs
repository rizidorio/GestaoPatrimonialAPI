using GestaoPatrimonial.Application.CqrsSubcategory.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Handlers
{
    public class SubcategoryUpdateCommandHandler : IRequestHandler<SubcategoryUpdateCommand, Subcategory>
    {
        private readonly ISubcategoryRepository _repository;

        public SubcategoryUpdateCommandHandler(ISubcategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Subcategory> Handle(SubcategoryUpdateCommand request, CancellationToken cancellationToken)
        {
            Subcategory findSubcategory = await _repository.GetAsync(request.Id);

            if (findSubcategory != null)
            {
                findSubcategory.Update(request.Name, request.CategoryId);

                return await _repository.UpdateAsync(findSubcategory);
            }

            throw new ArgumentException("Subcategoria não encontrada");
        }
    }
}
