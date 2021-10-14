using AutoMapper;
using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands;
using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries;
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
    public class PatrimonialAssetService : IPatrimonialAssetService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PatrimonialAssetService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> GetAll()
        {
            try
            {
                GetPatrimonialAssetQuery getPatrimonialAssetQuery = new GetPatrimonialAssetQuery();

                if (getPatrimonialAssetQuery == null)
                    return new ResponseModel(500, "Erro ao listar patrimônios");

                IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar patrimônios - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetById(int id)
        {
            try
            {
                GetPatrimonialAssetByIdQuery getPatrimonialAssetByIdQuery = new GetPatrimonialAssetByIdQuery(id);

                if (getPatrimonialAssetByIdQuery == null)
                    return new ResponseModel(500, "Erro ao buscar patrimônio");

                PatrimonialAsset result = await _mediator.Send(getPatrimonialAssetByIdQuery);

                if (result == null)
                    return new ResponseModel(404, "Patrimônio não encontrado");

                return new ResponseModel(200, _mapper.Map<PatrimonialAssetDto>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar patrimônio - {ex.Message}");
            }
        }

        public async Task<ResponseModel> ListByBranchOfficeAsync(int branchOfficeId)
        {
            try
            {
                GetPatrimonialAssetByBranchOfficeQuery getPatrimonialAssetByBranchOfficeQuery = new GetPatrimonialAssetByBranchOfficeQuery(branchOfficeId);

                if (getPatrimonialAssetByBranchOfficeQuery == null)
                    return new ResponseModel(500, "Erro ao listar patrimônios");

                IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetByBranchOfficeQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar patrimônios - {ex.Message}");
            }
        }

        public async Task<ResponseModel> ListByCategoryAsync(int categoryId)
        {
            try
            {
                GetPatrimonialAssetByCategoryQuery getPatrimonialAssetByCategoryQuery = new GetPatrimonialAssetByCategoryQuery(categoryId);

                if (getPatrimonialAssetByCategoryQuery == null)
                    return new ResponseModel(500, "Erro ao listar patrimônios");

                IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetByCategoryQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar patrimônios - {ex.Message}");
            }
        }

        public async Task<ResponseModel> ListByDepartmentAsync(int departmentId)
        {
            try
            {
                GetPatrimonialAssetByDepartmentQuery getPatrimonialAssetByDepartmentQuery = new GetPatrimonialAssetByDepartmentQuery(departmentId);

                if (getPatrimonialAssetByDepartmentQuery == null)
                    return new ResponseModel(500, "Erro ao listar patrimônios");

                IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetByDepartmentQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar patrimônios - {ex.Message}");
            }
        }

        public async Task<ResponseModel> ListBySubcategoryAsync(int subcategoryId)
        {
            try
            {
                GetPatrimonialAssetBySubcategoryQuery getPatrimonialAssetBySubcategoryQuery = new GetPatrimonialAssetBySubcategoryQuery(subcategoryId);

                if (getPatrimonialAssetBySubcategoryQuery == null)
                    return new ResponseModel(500, "Erro ao listar patrimônios");

                IEnumerable<PatrimonialAsset> result = await _mediator.Send(getPatrimonialAssetBySubcategoryQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<PatrimonialAssetDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar patrimônios - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Add(PatrimonialAssetDto patrimonialAssetDto)
        {
            try
            {
                PatrimonialAssetCreateCommand patrimonialAssetCreateCommand = _mapper.Map<PatrimonialAssetCreateCommand>(patrimonialAssetDto);
                return new ResponseModel(201, await _mediator.Send(patrimonialAssetCreateCommand), "Patrimônio criado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar patrimônio - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(PatrimonialAssetDto patrimonialAssetDto)
        {
            try
            {
                PatrimonialAssetUpdateCommand patrimonialAssetUpdateCommand = _mapper.Map<PatrimonialAssetUpdateCommand>(patrimonialAssetDto);
                return new ResponseModel(200, await _mediator.Send(patrimonialAssetUpdateCommand), "Patrimônio atualizado com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao atualizar patrimônio - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int? id)
        {
            try
            {
                PatrimonialAssetRemoveCommand patrimonialAssetRemoveCommand = new PatrimonialAssetRemoveCommand(id.Value);

                if (patrimonialAssetRemoveCommand == null)
                    return new ResponseModel(500, "Erro ao buscar patrimônio");

                return new ResponseModel(200, await _mediator.Send(patrimonialAssetRemoveCommand), "Patrimônio removido com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao remover patrimônio - {ex.Message}");
            }
        }
    }
}
