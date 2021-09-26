using GestaoPatrimonial.Application.CqrsBranchOffice.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Handlers
{
    public class BranchOfficeCreateCommandHandler : IRequestHandler<BranchOfficeCommand, BranchOffice>
    {
        private readonly IBrachOfficeRepository _repository;

        public BranchOfficeCreateCommandHandler(IBrachOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<BranchOffice> Handle(BranchOfficeCommand request, CancellationToken cancellationToken)
        {
            BranchOffice branchOffice = new BranchOffice(request.Name, request.Email, request.PhoneNumber, request.CellPhoneNumber, request.ResponsibleName,
                                                         request.ResponsiblePhoneNumber, request.ResponsibleCellPhoneNumber, request.ResponsibleEmail, request.CompanyId,
                                                         request.AddressId, request.AddressNumber, request.AddressComplement);

            if (branchOffice != null)
                return await _repository.CreateAsync(branchOffice);

            throw new ArgumentException("Erro ao criar filial");
        }
    }
}
