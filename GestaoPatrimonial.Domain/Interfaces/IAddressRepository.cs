using GestaoPatrimonial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoPatrimonial.Domain.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> ListByStateAsync(string state);
        Task<IEnumerable<Address>> ListByCityAsync(string city);
        Task<Address> GetByPostalCodeAsync(string postalCode);
    }
}
