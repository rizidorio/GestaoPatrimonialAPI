using AutoMapper;
using GestaoPatrimonial.Application.CqrsCompany.Commands;
using GestaoPatrimonial.Application.CqrsCompany.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task Add(CompanyDto companyDto)
        {
            CompanyCreateCommand companyCreateCommand = _mapper.Map<CompanyCreateCommand>(companyDto);
            await _mediator.Send(companyCreateCommand);
        }

        public async Task Update(CompanyDto companyDto)
        {
            CompanyUpdateCommand companyUpdateCommand = _mapper.Map<CompanyUpdateCommand>(companyDto);
            await _mediator.Send(companyUpdateCommand);
        }

        public async Task Delete(int id)
        {
            CompanyRemoveCommand companyRemoveCommand = new CompanyRemoveCommand(id);

            if (companyRemoveCommand == null)
                throw new ArgumentException("Erro ao buscar empresa");

            await _mediator.Send(companyRemoveCommand);
        }

        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            GetCompanyQuery getCompanyQuery = new GetCompanyQuery();

            if (getCompanyQuery == null)
                throw new ArgumentException("Erro ao listar empresas");

            IEnumerable<Company> result = await _mediator.Send(getCompanyQuery);

            return _mapper.Map<IEnumerable<CompanyDto>>(result);
        }

        public async Task<CompanyDto> GetById(int id)
        {
            GetCompanyByIdQuery getCompanyByIdQuery = new GetCompanyByIdQuery(id);

            if (getCompanyByIdQuery == null)
                throw new ArgumentException("Erro ao buscar empresa");

            Company result = await _mediator.Send(getCompanyByIdQuery);

            return _mapper.Map<CompanyDto>(result);
        }
    }
}
