using System;
using System.Collections.Generic;

namespace GestaoPatrimonial.Domain.Entities
{
    public sealed class Subcategory : BaseEntity
    {
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<PatrimonialAsset> PatrimonialAssets { get; set; }

        private Subcategory()
        {

        }

        public Subcategory(string name, int? categoryId)
        {
            ValidationName(name);
            CategoryId = categoryId;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public void Update(string name, int? categoryId)
        {
            ValidationName(name);
            CategoryId = categoryId;

            UpdateAt = DateTime.Now;
        }
    }
}
