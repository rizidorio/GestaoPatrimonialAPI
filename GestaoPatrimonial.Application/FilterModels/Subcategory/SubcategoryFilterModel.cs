namespace GestaoPatrimonial.Application.FilterModels.Subcategory
{
    public class SubcategoryFilterModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
    }
}
