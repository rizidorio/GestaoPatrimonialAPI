using GestaoPatrimonial.Application.CqrsBranchOffice.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Handlers
{
    public class BranchOfficeUpdateCommandHandler : IRequestHandler<BranchOfficeUpdateCommand, BranchOffice>
    {
        private readonly IBrachOfficeRepository _repository;

        public BranchOfficeUpdateCommandHandler(IBrachOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<BranchOffice> Handle(BranchOfficeUpdateCommand request, CancellationToken cancellationToken)
        {
            BranchOffice findBranchOffice = await _repository.GetAsync(request.Id);

            if (findBranchOffice != null)
            {
                findBranchOffice.Update(request.Name, request.Email, request.PhoneNumber, request.CellPhoneNumber, request.ResponsibleName,
                                        request.ResponsiblePhoneNumber, request.ResponsibleCellPhoneNumber, request.ResponsibleEmail, request.CompanyId,
                                        request.AddressId, request.AddressNumber, request.AddressComplement);

                return await _repository.UpdateAsync(findBranchOffice);
            }

            throw new ArgumentException("Filial não encontrada");
        }
    }
}
