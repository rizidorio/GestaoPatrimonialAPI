using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Queries
{
    public class GetSubcategoryByIdQuery : IRequest<Subcategory>
    {
        public int Id { get; set; }

        public GetSubcategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
