using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Queries
{
    public class GetBranchOfficeByIdQuery : IRequest<BranchOffice>
    {
        public int Id { get; set; }

        public GetBranchOfficeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
