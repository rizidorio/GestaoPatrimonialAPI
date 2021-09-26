using GestaoPatrimonial.Data.Context;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Data.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Address> GetByPostalCodeAsync(string postalCode)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.PostalCode.Equals(postalCode));
        }

        public async Task<IEnumerable<Address>> ListByCityAsync(string city)
        {
            return await _context.Addresses.Where(x => x.City.Equals(city)).ToListAsync();
        }

        public async Task<IEnumerable<Address>> ListByStateAsync(string state)
        {
            return await _context.Addresses.Where(x => x.State.Equals(state)).ToListAsync();
        }
    }
}
