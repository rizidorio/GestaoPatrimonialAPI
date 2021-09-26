using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsSubcategory.Queries
{
    public class GetSubcategoryQuery : IRequest<IEnumerable<Subcategory>>
    {
    }
}
