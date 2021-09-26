using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Commands
{
    public class SubcategoryRemoveCommand : IRequest<Subcategory>
    {
        public int Id { get; set; }

        public SubcategoryRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
