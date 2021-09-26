using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Commands
{
    public class SubcategoryCommand : IRequest<Subcategory>
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
