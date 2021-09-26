using GestaoPatrimonial.Application.CqrsSubcategory.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Handlers
{
    public class SubcategoryRemoveCommandHandler : IRequestHandler<SubcategoryRemoveCommand, Subcategory>
    {
        private readonly ISubcategoryRepository _repository;

        public SubcategoryRemoveCommandHandler(ISubcategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Subcategory> Handle(SubcategoryRemoveCommand request, CancellationToken cancellationToken)
        {
            Subcategory findSubcategory = await _repository.GetAsync(request.Id);

            if (findSubcategory != null)
                return await _repository.DeleteAsync(findSubcategory);

            throw new ArgumentException("Subcategoria não encontrada");
        }
    }
}
