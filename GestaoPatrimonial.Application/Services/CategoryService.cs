using AutoMapper;
using GestaoPatrimonial.Application.CqrsCategory.Commands;
using GestaoPatrimonial.Application.CqrsCategory.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task Add(CategoryDto categoryDto)
        {
            CategoryCreateCommand categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
            await _mediator.Send(categoryCreateCommand);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            CategoryUpdateCommand categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDto);
            await _mediator.Send(categoryUpdateCommand);
        }

        public async Task Delete(int id)
        {
            CategoryRemoveCommand categoryRemoveCommand = new CategoryRemoveCommand(id);

            if (categoryRemoveCommand == null)
                throw new ArgumentException("Erro ao buscar categoria");

            await _mediator.Send(categoryRemoveCommand);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            GetCategoryQuery getCategoryQuery = new GetCategoryQuery();

            if (getCategoryQuery == null)
                throw new ArgumentException("Erro ao buscar categoria");

            IEnumerable<Category> result = await _mediator.Send(getCategoryQuery);

            return _mapper.Map<IEnumerable<CategoryDto>>(result);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            GetCategoryByIdQuery getCategoryByIdQuery = new GetCategoryByIdQuery(id);

            if (getCategoryByIdQuery == null)
                throw new ArgumentException("Erro ao buscar categoria");

            Category result = await _mediator.Send(getCategoryByIdQuery);

            return _mapper.Map<CategoryDto>(result);
        }
    }
}
