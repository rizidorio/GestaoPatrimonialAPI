namespace GestaoPatrimonial.Application.FilterModels.Company
{
    public class CompanyFilterModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string CnpjCpf { get; set; }
    }
}
