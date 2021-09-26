using AutoMapper;
using GestaoPatrimonial.Application.CqrsAddress.Commands;
using GestaoPatrimonial.Application.CqrsAddress.Queries;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
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

        public async Task Add(AddressDto addressDto)
        {
            AddressCreateCommand addressCreateCommand = _mapper.Map<AddressCreateCommand>(addressDto);

            await _mediator.Send(addressCreateCommand);
        }

        public async Task Update(AddressDto addressDto)
        {
            AddressUpdateCommand addressUpdateCommand = _mapper.Map<AddressUpdateCommand>(addressDto);

            await _mediator.Send(addressUpdateCommand);
        }

        public async Task Delete(int? id)
        {
            AddressRemoveCommand addressRemoveCommand = new AddressRemoveCommand(id.Value);

            if (addressRemoveCommand != null)
                await _mediator.Send(addressRemoveCommand);

            throw new ArgumentException("Erro ao buscar endereço");
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            GetAddressQuery getAddressQuery = new GetAddressQuery();

            if (getAddressQuery == null)
                throw new ArgumentException("Erro ao listar endereços");

            IEnumerable<Address> result = await _mediator.Send(getAddressQuery);

            return _mapper.Map<IEnumerable<AddressDto>>(result);
        }

        public async Task<AddressDto> GetById(int? id)
        {
            GetAddressByIdQuery getAddressByIdQuery = new GetAddressByIdQuery(id.Value);

            if (getAddressByIdQuery == null)
                throw new ArgumentException("Erro ao buscar endereço");

            Address result = await _mediator.Send(getAddressByIdQuery);

            return _mapper.Map<AddressDto>(result);
        }

        public async Task<AddressDto> GetByPostalCodeAsync(string postalCode)
        {
            GetAddressByPostalCodeQuery getAddressByPostalCodeQuery = new GetAddressByPostalCodeQuery(postalCode);

            if (getAddressByPostalCodeQuery == null)
                throw new ArgumentException("Erro ao buscar endereço");

            Address result = await _mediator.Send(getAddressByPostalCodeQuery);

            return _mapper.Map<AddressDto>(result);
        }

        public async Task<IEnumerable<AddressDto>> ListByCityAsync(string city)
        {
            GetAddressByCityQuery getAddressByCityQuery = new GetAddressByCityQuery(city);

            if (getAddressByCityQuery == null)
                throw new ArgumentException("Erro ao listar endereços");

            IEnumerable<Address> result = await _mediator.Send(getAddressByCityQuery);

            return _mapper.Map<IEnumerable<AddressDto>>(result);
        }

        public async Task<IEnumerable<AddressDto>> ListByStateAsync(string state)
        {
            GetAddressByStateQuery getAddressByStateQuery = new GetAddressByStateQuery(state);

            if (getAddressByStateQuery == null)
                throw new ArgumentException("Erro ao listar endereços");

            IEnumerable<Address> result = await _mediator.Send(getAddressByStateQuery);

            return _mapper.Map<IEnumerable<AddressDto>>(result);
        }
    }
}
