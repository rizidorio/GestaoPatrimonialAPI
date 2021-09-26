using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Commands
{
    public class BranchOfficeRemoveCommand : IRequest<BranchOffice>
    {
        public int Id { get; set; }

        public BranchOfficeRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
