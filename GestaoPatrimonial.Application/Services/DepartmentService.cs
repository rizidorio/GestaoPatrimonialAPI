using AutoMapper;
using MediatR;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoPatrimonial.Application.CqrsDepartment.Queries;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Application.CqrsDepartment.Commands;

namespace GestaoPatrimonial.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DepartmentService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> GetAll()
        {
            try
            {
                GetDepartmentQuery getDepartmentQuery = new GetDepartmentQuery();

                if (getDepartmentQuery == null)
                    return new ResponseModel(500, "Erro ao listar setores");

                IEnumerable<Department> result = await _mediator.Send(getDepartmentQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<DepartmentDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar setores - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetById(int? id)
        {
            try
            {
                GetDepartmentByIdQuery getDepartmentByIdQuery = new GetDepartmentByIdQuery(id.Value);

                if (getDepartmentByIdQuery == null)
                    return new ResponseModel(500, "Erro ao buscar setor");

                Department result = await _mediator.Send(getDepartmentByIdQuery);

                if (result == null)
                    return new ResponseModel(404, "Setor não encontrado");

                return new ResponseModel(200, _mapper.Map<DepartmentDto>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar setor - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetByInitials(string initials)
        {
            try
            {
                GetDepartmentByInitialsQuery getDepartmentByInitialsQuery = new GetDepartmentByInitialsQuery(initials);

                if (getDepartmentByInitialsQuery == null)
                    return new ResponseModel(500, "Erro ao buscar setor");

                Department result = await _mediator.Send(getDepartmentByInitialsQuery);

                if (result == null)
                    return new ResponseModel(404, "Setor não encontrado");

                return new ResponseModel(200, _mapper.Map<DepartmentDto>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar setor - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Add(DepartmentDto departmentDto)
        {
            try
            {
                DepartmentCreateCommand departmentCreateCommand = _mapper.Map<DepartmentCreateCommand>(departmentDto);
                return new ResponseModel(201, await _mediator.Send(departmentCreateCommand), "Setor criado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao adicionar setor - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(DepartmentDto departmentDto)
        {
            try
            {
                DepartmentUpdateCommand departmentUpdateCommand = _mapper.Map<DepartmentUpdateCommand>(departmentDto);
                return new ResponseModel(200, await _mediator.Send(departmentUpdateCommand), "Setor atulizado com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao atualizar setor - {ex.Message}");
            }
        }
        public async Task<ResponseModel> Delete(int? id)
        {
            try
            {
                DepartmentRemoveCommand departmentRemoveCommand = new DepartmentRemoveCommand(id.Value);

                if (departmentRemoveCommand == null)
                    return new ResponseModel(500, "Erro ao buscar setor");

                return new ResponseModel(200, await _mediator.Send(departmentRemoveCommand), "Setor removido com sucesso");
            }
            catch (Exception ex)
            {
                if (ex.GetType().Equals(typeof(ArgumentException)))
                    return new ResponseModel(404, ex.Message);

                return new ResponseModel(500, $"Erro ao remover setor - {ex.Message}");
            }
        }
    }
}
