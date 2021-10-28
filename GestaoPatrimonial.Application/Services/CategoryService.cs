using AutoMapper;
using GestaoPatrimonial.Application.CqrsCategory.Commands;
using GestaoPatrimonial.Application.CqrsCategory.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.FilterModels.Category;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoPatrimonial.Application.FilterModels.Paginated;

namespace GestaoPatrimonial.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> GetAll(CategoryFilterModel filter)
        {
            try
            {
                GetCategoryQuery getCategoryQuery = new GetCategoryQuery();

                if (getCategoryQuery == null)
                    return new ResponseModel(500, "Erro ao buscar categoria");

                IEnumerable<Category> mediatorResult = await _mediator.Send(getCategoryQuery);

                mediatorResult = filter.Name != string.Empty ? mediatorResult.Where(x => x.Name.Contains(filter.Name, StringComparison.InvariantCultureIgnoreCase)) : mediatorResult;

                IEnumerable<CategoryDto> filterResult = _mapper.Map<IEnumerable<CategoryDto>>(mediatorResult);
                return new ResponseModel(200, filterResult.Paginate(filter.PageSize, filter.Page));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar categorias - {ex.Message}");
            } 
        }

        public async Task<ResponseModel> GetById(int id)
        {
            try
            {
                GetCategoryByIdQuery getCategoryByIdQuery = new GetCategoryByIdQuery(id);

                if (getCategoryByIdQuery == null)
                    return new ResponseModel(500, "Erro ao buscar categoria");

                Category result = await _mediator.Send(getCategoryByIdQuery);
                
                if (result == null)
                    return new ResponseModel(404, "Categoria não encontrada");

                return new ResponseModel(200, _mapper.Map<CategoryDto>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar categoria - {ex.Message}");
            }
        }
        public async Task<ResponseModel> Create(CategoryDto categoryDto)
        {
            try
            {
                CategoryCreateCommand categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
                return new ResponseModel(201, await _mediator.Send(categoryCreateCommand), "Categoria criada com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar categoria - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(CategoryDto categoryDto)
        {
            try
            {
                CategoryUpdateCommand categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDto);
                return new ResponseModel(200, await _mediator.Send(categoryUpdateCommand), "Categoria atualizada com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao atualizar categoria - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                CategoryRemoveCommand categoryRemoveCommand = new CategoryRemoveCommand(id);

                if (categoryRemoveCommand == null)
                    return new ResponseModel(500, "Erro ao buscar categoria");

                return new ResponseModel(200, await _mediator.Send(categoryRemoveCommand), "Categoria removida com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao remover categoria - {ex.Message}");
            } 
        }
    }
}
