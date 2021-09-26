using GestaoPatrimonial.Domain.Entities;
using MediatR;

namespace GestaoPatrimonial.Application.CqrsCompany.Commands
{
    public abstract class CompanyCommand : IRequest<Company>
    {
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public int CompanyType { get; set; }
        public string CnpjCpf { get; set; }
        public string IeRg { get; set; }
        public string ResponsibleName { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
    }
}
