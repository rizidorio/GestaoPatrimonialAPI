using GestaoPatrimonial.Application.CqrsCompany.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsCompany.Handlers
{
    public class CompanyUpdateCommandHandler : IRequestHandler<CompanyUpdateCommand, Company>
    {
        private readonly ICompanyRepository _repository;

        public CompanyUpdateCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(CompanyUpdateCommand request, CancellationToken cancellationToken)
        {
            Company findCompany = await _repository.GetAsync(request.Id);

            if (findCompany != null)
            {
                findCompany.Update(request.Name, request.CorporateName, request.CompanyType, request.CnpjCpf, request.IeRg, request.ResponsibleName, request.PhoneNumber,
                                   request.CellPhoneNumber, request.Email, request.AddressId, request.AddressNumber, request.AddressComplement);

                return await _repository.UpdateAsync(findCompany);
            }

            throw new ArgumentException("Categoria não encontrada");
        }
    }
}
