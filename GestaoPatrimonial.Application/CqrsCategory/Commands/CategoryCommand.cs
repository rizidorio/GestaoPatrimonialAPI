using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsCategory.Commands
{
    public abstract class CategoryCommand : IRequest<Category>
    {
        public string Name { get; set; }
    }
}
