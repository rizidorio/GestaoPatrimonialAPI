using AutoMapper;
using GestaoPatrimonial.Application.CqrsCompany.Commands;
using GestaoPatrimonial.Application.CqrsCompany.Queries;
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
    public class CompanyService : ICompanyService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CompanyService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> GetAll()
        {
            try
            {
                GetCompanyQuery getCompanyQuery = new GetCompanyQuery();

                if (getCompanyQuery == null)
                    return new ResponseModel(500, "Erro ao listar empresas");

                IEnumerable<Company> result = await _mediator.Send(getCompanyQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<CompanyDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar empresas - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetById(int id)
        {
            try
            {
                GetCompanyByIdQuery getCompanyByIdQuery = new GetCompanyByIdQuery(id);

                if (getCompanyByIdQuery == null)
                    return new ResponseModel(500, "Erro ao buscar empresa");

                Company result = await _mediator.Send(getCompanyByIdQuery);

                if (result == null)
                    return new ResponseModel(404, "Empresa não encontrada");

                return new ResponseModel(200, _mapper.Map<CompanyDto>(result));

            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar empresa - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Add(CompanyDto companyDto)
        {
            try
            {
                CompanyCreateCommand companyCreateCommand = _mapper.Map<CompanyCreateCommand>(companyDto);
                return new ResponseModel(200, await _mediator.Send(companyCreateCommand), "Empresa criada com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar empresa - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(CompanyDto companyDto)
        {
            try
            {
                CompanyUpdateCommand companyUpdateCommand = _mapper.Map<CompanyUpdateCommand>(companyDto);
                return new ResponseModel(200, await _mediator.Send(companyUpdateCommand), "Empresa atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao atualizar empresa - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                CompanyRemoveCommand companyRemoveCommand = new CompanyRemoveCommand(id);

                if (companyRemoveCommand == null)
                    return new ResponseModel(500, "Erro ao buscar empresa");

                return new ResponseModel(200, await _mediator.Send(companyRemoveCommand), "Empresa removida com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao remover empresa - {ex.Message}");
            }
        }
    }
}
