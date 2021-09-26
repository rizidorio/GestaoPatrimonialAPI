using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsCompany.Queries
{
    public class GetCompanyByIdQuery : IRequest<Company>
    {
        public int Id { get; set; }

        public GetCompanyByIdQuery(int id)
        {
            Id = id;
        }
    }
}
