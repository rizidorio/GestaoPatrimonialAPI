using GestaoPatrimonial.Application.CqrsCompany.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsCompany.Handlers
{
    public class CompanyCreateCommandHandler : IRequestHandler<CompanyCreateCommand, Company>
    {
        private readonly ICompanyRepository _repository;

        public CompanyCreateCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
        {
            Company company = new Company(request.Name, request.CorporateName, request.CompanyType, request.CnpjCpf, request.IeRg, request.ResponsibleName, request.PhoneNumber,
                                          request.CellPhoneNumber, request.Email, request.AddressId, request.AddressNumber, request.AddressComplement);

            if (company != null)
                return await _repository.CreateAsync(company);

            throw new ArgumentException("Erro ao criar empresa");
        }
    }
}
