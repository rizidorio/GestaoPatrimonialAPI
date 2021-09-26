using AutoMapper;
using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands;
using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries;
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
    public class PatrimonialAssetService : IPatrimonialAssetService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PatrimonialAssetService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(PatrimonialAssetDto patrimonialAssetDto)
        {
            PatrimonialAssetCreateCommand patrimonialAssetCreateCommand = _mapper.Map<PatrimonialAssetCreateCommand>(patrimonialAssetDto);
            await _mediator.Send(patrimonialAssetCreateCommand);
        }

        public async Task Update(PatrimonialAssetDto patrimonialAssetDto)
        {
            PatrimonialAssetUpdateCommand patrimonialAssetUpdateCommand = _mapper.Map<PatrimonialAssetUpdateCommand>(patrimonialAssetDto);
            await _mediator.Send(patrimonialAssetUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            PatrimonialAssetRemoveCommand patrimonialAssetRemoveCommand = new PatrimonialAssetRemoveCommand(id.Value);

            if (patrimonialAssetRemoveCommand == null)
                throw new Exception("Erro ao buscar patrimônio");

            await _mediator.Send(patrimonialAssetRemoveCommand);

        }

        public async Task<IEnumerable<PatrimonialAssetDto>> GetAll()
        {
            GetPatrimonialAssetQuery getPatrimonialAssetQuery = new GetPatrimonialAssetQuery();

            if (getPatrimonialAssetQuery == null)
                throw new Exception("Erro ao listar patrimônios");

            IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetQuery);

            return _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result);
        }

        public async Task<PatrimonialAssetDto> GetById(int id)
        {
            GetPatrimonialAssetByIdQuery getPatrimonialAssetByIdQuery = new GetPatrimonialAssetByIdQuery(id);

            if (getPatrimonialAssetByIdQuery == null)
                throw new Exception("Erro ao buscar patrimônio");

            PatrimonialAsset result = await _mediator.Send(getPatrimonialAssetByIdQuery);

            return _mapper.Map<PatrimonialAssetDto>(result);

        }

        public async Task<IEnumerable<PatrimonialAssetDto>> ListByBranchOfficeAsync(int branchOfficeId)
        {
            GetPatrimonialAssetByBranchOfficeQuery getPatrimonialAssetByBranchOfficeQuery = new GetPatrimonialAssetByBranchOfficeQuery(branchOfficeId);

            if (getPatrimonialAssetByBranchOfficeQuery == null)
                throw new Exception("Erro ao listar patrimônios");

            IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetByBranchOfficeQuery);

            return _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result);
        }

        public async Task<IEnumerable<PatrimonialAssetDto>> ListByCategoryAsync(int categoryId)
        {
            GetPatrimonialAssetByCategoryQuery getPatrimonialAssetByCategoryQuery = new GetPatrimonialAssetByCategoryQuery(categoryId);

            if (getPatrimonialAssetByCategoryQuery == null)
                throw new Exception("Erro ao listar patrimônios");

            IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetByCategoryQuery);

            return _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result);
        }

        public async Task<IEnumerable<PatrimonialAssetDto>> ListByDepartmentAsync(int departmentId)
        {
            GetPatrimonialAssetByDepartmentQuery getPatrimonialAssetByDepartmentQuery = new GetPatrimonialAssetByDepartmentQuery(departmentId);

            if (getPatrimonialAssetByDepartmentQuery == null)
                throw new Exception("Erro ao listar patrimônios");

            IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetByDepartmentQuery);

            return _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result);
        }

        public async Task<IEnumerable<PatrimonialAssetDto>> ListBySubcategoryAsync(int subcategoryId)
        {
            GetPatrimonialAssetBySubcategoryQuery getPatrimonialAssetBySubcategoryQuery = new GetPatrimonialAssetBySubcategoryQuery(subcategoryId);

            if (getPatrimonialAssetBySubcategoryQuery == null)
                throw new Exception("Erro ao listar patrimônios");

            IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetBySubcategoryQuery);

            return _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result);
        }
    }
}
