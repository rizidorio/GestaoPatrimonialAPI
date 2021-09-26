using GestaoPatrimonial.Data.Context;
using GestaoPatrimonial.Domain.Entities;
using GestaoPatrimonial.Domain.Interfaces;

namespace GestaoPatrimonial.Data.Repository
{
    public class SubcategoryRepository : BaseRepository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
