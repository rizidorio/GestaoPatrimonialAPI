using GestaoPatrimonial.Application.CqrsCompany.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsCompany.Handlers
{
    public class CompanyRemoveCommandHandler : IRequestHandler<CompanyRemoveCommand, Company>
    {
        private readonly ICompanyRepository _repository;

        public CompanyRemoveCommandHandler(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Company> Handle(CompanyRemoveCommand request, CancellationToken cancellationToken)
        {
            Company findCompany = await _repository.GetAsync(request.Id);

            if (findCompany != null)
                return await _repository.DeleteAsync(findCompany);

            throw new ArgumentException("Empresa não encontrada");
        }
    }
}
