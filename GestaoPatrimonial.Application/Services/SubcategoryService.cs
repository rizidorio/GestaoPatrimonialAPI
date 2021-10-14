using AutoMapper;
using GestaoPatrimonial.Application.CqrsSubcategory.Commands;
using GestaoPatrimonial.Application.CqrsSubcategory.Queries;
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
    public class SubcategoryService : ISubcategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubcategoryService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> GetAll()
        {
            try
            {
                GetSubcategoryQuery getSubcategoryQuery = new GetSubcategoryQuery();

                if (getSubcategoryQuery == null)
                    return new ResponseModel(500, "Erro ao listar subcategorias");

                IEnumerable<Subcategory> result = await _mediator.Send(getSubcategoryQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<SubcategoryDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar subcategorias - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetById(int id)
        {
            try
            {
                GetSubcategoryByIdQuery getSubcategoryByIdQuery = new GetSubcategoryByIdQuery(id);

                if (getSubcategoryByIdQuery == null)
                    return new ResponseModel(500, "Erro ao buscar subcategoria");

                Subcategory result = await _mediator.Send(getSubcategoryByIdQuery);

                if (result == null)
                    return new ResponseModel(404, "Subcategoria não encontrada");

                return new ResponseModel(200, _mapper.Map<SubcategoryDto>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar subcategorias - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Add(SubcategoryDto subcategoryDto)
        {
            try
            {
                SubcategoryCreateCommand subcategoryCreateCommand = _mapper.Map<SubcategoryCreateCommand>(subcategoryDto);
                return new ResponseModel(201, await _mediator.Send(subcategoryCreateCommand), "Subcategoria criada com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar subcategoria - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(SubcategoryDto subcategoryDto)
        {
            try
            {
                SubcategoryUpdateCommand subcategoryUpdateCommand = _mapper.Map<SubcategoryUpdateCommand>(subcategoryDto);
                return new ResponseModel(200, await _mediator.Send(subcategoryUpdateCommand), "Subcategoria atualizada com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao atualizar subcategoria - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                SubcategoryRemoveCommand subcategoryRemoveCommand = new SubcategoryRemoveCommand(id);

                if (subcategoryRemoveCommand == null)
                    return new ResponseModel(500, "Erro ao buscar subcategoria");

                return new ResponseModel(200, await _mediator.Send(subcategoryRemoveCommand), "Subcategoria removida com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao remover subcategoria - {ex.Message}");
            }
        }
    }
}
