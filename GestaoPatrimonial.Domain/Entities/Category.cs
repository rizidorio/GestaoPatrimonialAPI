using System;
using System.Collections.Generic;

namespace GestaoPatrimonial.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public ICollection<Subcategory> Subcategories { get; set; }

        private Category()
        {

        }

        public Category(string name)
        {
            ValidationName(name);
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void Update(string name)
        {
            ValidationName(name);
            UpdateAt = DateTime.Now;
        }
    }
}
