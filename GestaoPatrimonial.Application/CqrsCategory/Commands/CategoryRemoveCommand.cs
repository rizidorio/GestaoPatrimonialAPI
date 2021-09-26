using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsCategory.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public int Id { get; set; }

        public CategoryRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
