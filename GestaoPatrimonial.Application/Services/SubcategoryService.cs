using AutoMapper;
using GestaoPatrimonial.Application.CqrsSubcategory.Commands;
using GestaoPatrimonial.Application.CqrsSubcategory.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
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

        public async Task Add(SubcategoryDto subcategoryDto)
        {
            SubcategoryCreateCommand subcategoryCreateCommand = _mapper.Map<SubcategoryCreateCommand>(subcategoryDto);
            await _mediator.Send(subcategoryCreateCommand);
        }

        public async Task Update(SubcategoryDto subcategoryDto)
        {
            SubcategoryUpdateCommand subcategoryUpdateCommand = _mapper.Map<SubcategoryUpdateCommand>(subcategoryDto);
            await _mediator.Send(subcategoryUpdateCommand);
        }

        public async Task Delete(int id)
        {
            SubcategoryRemoveCommand subcategoryRemoveCommand = new SubcategoryRemoveCommand(id);

            if (subcategoryRemoveCommand == null)
                throw new ArgumentException("Erro ao buscar subcategoria");

            await _mediator.Send(subcategoryRemoveCommand);
        }

        public async Task<IEnumerable<SubcategoryDto>> GetAll()
        {
            GetSubcategoryQuery getSubcategoryQuery = new GetSubcategoryQuery();

            if (getSubcategoryQuery == null)
                throw new ArgumentException("Erro ao listar subcategorias");

            IEnumerable<Subcategory> result = await _mediator.Send(getSubcategoryQuery);

            return _mapper.Map<IEnumerable<SubcategoryDto>>(result);

        }

        public async Task<SubcategoryDto> GetById(int id)
        {
            GetSubcategoryByIdQuery getSubcategoryByIdQuery = new GetSubcategoryByIdQuery(id);

            if (getSubcategoryByIdQuery == null)
                throw new ArgumentException("Erro ao buscar subcategoria");

            Subcategory result = await _mediator.Send(getSubcategoryByIdQuery);

            return _mapper.Map<SubcategoryDto>(result);
        }
    }
}
