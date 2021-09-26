using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsCategory.Queries
{
    public class GetCategoryQuery : IRequest<IEnumerable<Category>>
    {
    }
}
