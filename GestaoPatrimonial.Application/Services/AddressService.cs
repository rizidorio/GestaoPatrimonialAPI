﻿using AutoMapper;
using GestaoPatrimonial.Application.CqrsAddress.Commands;
using GestaoPatrimonial.Application.CqrsAddress.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Utils.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AddressService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Add(AddressDto addressDto)
        {
            try
            {
                AddressCreateCommand addressCreateCommand = _mapper.Map<AddressCreateCommand>(addressDto);

                return new ResponseModel(201, await _mediator.Send(addressCreateCommand), "Endereço criado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao criar endereço - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Update(AddressDto addressDto)
        {
            try
            {
                AddressUpdateCommand addressUpdateCommand = _mapper.Map<AddressUpdateCommand>(addressDto);

                return new ResponseModel(200, await _mediator.Send(addressUpdateCommand), "Endereço atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao atualizar endereço - {ex.Message}");
            }
        }

        public async Task<ResponseModel> Delete(int? id)
        {
            try
            {
                AddressRemoveCommand addressRemoveCommand = new AddressRemoveCommand(id.Value);

                if (addressRemoveCommand != null)
                    return new ResponseModel(200, await _mediator.Send(addressRemoveCommand), "Endereço removido com sucesso");

                return new ResponseModel(500, "Erro ao remover endereço");
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao remover endereço - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetAll()
        {
            try
            {
                GetAddressQuery getAddressQuery = new GetAddressQuery();

                if (getAddressQuery == null)
                    return new ResponseModel(500, "Erro ao listar endereços");

                IEnumerable<Address> result = await _mediator.Send(getAddressQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<AddressDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar endereços - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetById(int? id)
        {
            try
            {
                GetAddressByIdQuery getAddressByIdQuery = new GetAddressByIdQuery(id.Value);

                if (getAddressByIdQuery == null)
                    return new ResponseModel(500, "Erro ao buscar endereço");

                Address result = await _mediator.Send(getAddressByIdQuery);

                if (result == null)
                    return new ResponseModel(404, "Endereço não encontrado");

                return new ResponseModel(200, _mapper.Map<AddressDto>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar endereço - {ex.Message}");
            }
        }

        public async Task<ResponseModel> GetByPostalCodeAsync(string postalCode)
        {
            try
            {
                Regex postaCodeRegex = new Regex(@"[\d]{2}.[\d]{3}-[\d]{3}");

                if (!postaCodeRegex.IsMatch(postalCode))
                {
                    return new ResponseModel(409, "Cep em formato inválido (Ex. 00.000-000)");
                }

                GetAddressByPostalCodeQuery getAddressByPostalCodeQuery = new GetAddressByPostalCodeQuery(postalCode);

                if (getAddressByPostalCodeQuery == null)
                    return new ResponseModel(500, "Erro ao buscar endereço");

                Address result = await _mediator.Send(getAddressByPostalCodeQuery);

                if (result == null)
                    return new ResponseModel(404, "Endereço não encontrado");

                return new ResponseModel(200, _mapper.Map<AddressDto>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao buscar endereço - {ex.Message}");
            }
        }

        public async Task<ResponseModel> ListByCityAsync(string city)
        {
            try
            {
                GetAddressByCityQuery getAddressByCityQuery = new GetAddressByCityQuery(city);

                if (getAddressByCityQuery == null)
                    return new ResponseModel(500, "Erro ao listar endereços");

                IEnumerable<Address> result = await _mediator.Send(getAddressByCityQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<AddressDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar endereços - {ex.Message}");
            }
        }

        public async Task<ResponseModel> ListByStateAsync(string state)
        {
            try
            {
                GetAddressByStateQuery getAddressByStateQuery = new GetAddressByStateQuery(state);

                if (getAddressByStateQuery == null)
                    return new ResponseModel(500, "Erro ao listar endereços");

                IEnumerable<Address> result = await _mediator.Send(getAddressByStateQuery);

                return new ResponseModel(200, _mapper.Map<IEnumerable<AddressDto>>(result));
            }
            catch (Exception ex)
            {
                return new ResponseModel(500, $"Erro ao listar endereços - {ex.Message}");
            }
        }
    }
}
