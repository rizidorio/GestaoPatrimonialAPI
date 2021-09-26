using GestaoPatrimonial.Application.CqrsBranchOffice.Commands;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.CqrsBranchOffice.Handlers
{
    public class BranchOfficeRemoveCommandHandler : IRequestHandler<BranchOfficeRemoveCommand, BranchOffice>
    {
        private readonly IBrachOfficeRepository _repository;

        public BranchOfficeRemoveCommandHandler(IBrachOfficeRepository repository)
        {
            _repository = repository;
        }

        public async Task<BranchOffice> Handle(BranchOfficeRemoveCommand request, CancellationToken cancellationToken)
        {
            BranchOffice findBranchOffice = await _repository.GetAsync(request.Id);

            if (findBranchOffice != null)
                return await _repository.DeleteAsync(findBranchOffice);

            throw new ArgumentException("Filial não encontrada");
        }
    }
}
