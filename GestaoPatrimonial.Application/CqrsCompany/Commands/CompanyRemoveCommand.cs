using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsCompany.Commands
{
    public class CompanyRemoveCommand : IRequest<Company>
    {
        public int Id { get; set; }

        public CompanyRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
