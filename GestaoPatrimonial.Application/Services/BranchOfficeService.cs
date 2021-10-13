using AutoMapper;
using GestaoPatrimonial.Application.CqrsBranchOffice.Commands;
using GestaoPatrimonial.Application.CqrsBranchOffice.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Utils.Models;
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

        public async Task<ResponseModel> GetAll()
        {
            try
            {
                GetBranchOfficeQuery getBranchOfficeQuery = new GetBranchOfficeQuery();

                if (getBranchOfficeQuery == null)
                    return new ResponseModel(500, "Erro ao listar filiais");

                IEnumerable<BranchOffice> result = await _mediator.Send(getBranchOfficeQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<BranchOfficeDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar filiais - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetById(int? id)
        {
            try
            {
                GetBranchOfficeByIdQuery getBranchOfficeByIdQuery = new GetBranchOfficeByIdQuery(id.Value);

                if (getBranchOfficeByIdQuery == null)
                    return new ResponseModel(500, "Erro ao buscar filial");

                BranchOffice result = await _mediator.Send(getBranchOfficeByIdQuery);

                if (result == null)
                    return new ResponseModel(404, "Filial não encontrada");

                return new ResponseModel(200, _mapper.Map<BranchOfficeDto>(result));

            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar filial - {ex.Message}");
            }
        }

        public async Task<ResponseModel> ListByCompanyAsync(int companyId)
        {
            try
            {
                GetBranchOfficeByCompanyQuery getBranchOfficeByCompanyQuery = new GetBranchOfficeByCompanyQuery(companyId);

                if (getBranchOfficeByCompanyQuery == null)
                    throw new ArgumentException("Erro ao listar filiais");

                IEnumerable<BranchOffice> result = await _mediator.Send(getBranchOfficeByCompanyQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<BranchOfficeDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar filiais - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Add(BranchOfficeDto branchOfficeDto)
        {
            try
            {
                BranchOfficeCreateCommand branchOfficeCreateCommand = _mapper.Map<BranchOfficeCreateCommand>(branchOfficeDto);
                return new ResponseModel(201, await _mediator.Send(branchOfficeCreateCommand), "Filial criada com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao criar filial - {ex.Message}");
            }
            
        }

        public async Task<ResponseModel> Update(BranchOfficeDto branchOfficeDto)
        {

            try
            {
                BranchOfficeUpdateCommand branchOfficeUpdateCommand = _mapper.Map<BranchOfficeUpdateCommand>(branchOfficeDto);
                return new ResponseModel(200, await _mediator.Send(branchOfficeUpdateCommand), "Filial atualizada com sucesso");

            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao atualizar filial - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int? id)
        {
            try
            {
                BranchOfficeRemoveCommand branchOfficeRemoveCommand = new BranchOfficeRemoveCommand(id.Value);

                if (branchOfficeRemoveCommand == null)
                    return new ResponseModel(500, "Erro ao remover filial");

                return new ResponseModel(200, await _mediator.Send(branchOfficeRemoveCommand), "Filial removida com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao remover filial - {ex.Message}");
            }

        }
    }
}
