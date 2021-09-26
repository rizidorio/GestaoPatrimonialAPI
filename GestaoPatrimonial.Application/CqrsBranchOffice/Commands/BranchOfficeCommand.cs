using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Commands
{
    public abstract class BranchOfficeCommand : IRequest<BranchOffice>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsiblePhoneNumber { get; set; }
        public string ResponsibleCellPhoneNumber { get; set; }
        public string ResponsibleEmail { get; set; }
        public int? CompanyId { get; set; }
        public int? AddressId { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
    }
}
