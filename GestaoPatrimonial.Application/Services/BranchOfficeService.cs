using AutoMapper;
using GestaoPatrimonial.Application.CqrsBranchOffice.Commands;
using GestaoPatrimonial.Application.CqrsBranchOffice.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Services
{
    public class BranchOfficeService : IBranchOfficeService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BranchOfficeService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(BranchOfficeDto branchOfficeDto)
        {
            BranchOfficeCreateCommand branchOfficeCreateCommand = _mapper.Map<BranchOfficeCreateCommand>(branchOfficeDto);
            await _mediator.Send(branchOfficeCreateCommand);
        }

        public async Task Update(BranchOfficeDto branchOfficeDto)
        {
            BranchOfficeUpdateCommand branchOfficeUpdateCommand = _mapper.Map<BranchOfficeUpdateCommand>(branchOfficeDto);

            await _mediator.Send(branchOfficeUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            BranchOfficeRemoveCommand branchOfficeRemoveCommand = new BranchOfficeRemoveCommand(id.Value);

            if (branchOfficeRemoveCommand == null)
                throw new Exception("Erro ao buscar filial");

            await _mediator.Send(branchOfficeRemoveCommand);
        }

        public async Task<IEnumerable<BranchOfficeDto>> GetAll()
        {
            GetBranchOfficeQuery getBranchOfficeQuery = new GetBranchOfficeQuery();

            if (getBranchOfficeQuery == null)
                throw new ArgumentException("Erro ao listar filiais");

            IEnumerable<BranchOffice> result = await _mediator.Send(getBranchOfficeQuery);

            return _mapper.Map<IEnumerable<BranchOfficeDto>>(result);
        }

        public async Task<BranchOfficeDto> GetById(int? id)
        {
            GetBranchOfficeByIdQuery getBranchOfficeByIdQuery = new GetBranchOfficeByIdQuery(id.Value);

            if (getBranchOfficeByIdQuery == null)
                throw new ArgumentException("Erro ao buscar filial");

            BranchOffice result = await _mediator.Send(getBranchOfficeByIdQuery);

            return _mapper.Map<BranchOfficeDto>(result);

        }

        public async Task<IEnumerable<BranchOfficeDto>> ListByCompanyAsync(int companyId)
        {
            GetBranchOfficeByCompanyQuery getBranchOfficeByCompanyQuery = new GetBranchOfficeByCompanyQuery(companyId);

            if (getBranchOfficeByCompanyQuery == null)
                throw new ArgumentException("Erro ao listar filiais");

            IEnumerable<BranchOffice> result = await _mediator.Send(getBranchOfficeByCompanyQuery);

            return _mapper.Map<IEnumerable<BranchOfficeDto>>(result);
        }

    }
}
