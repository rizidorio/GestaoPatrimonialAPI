using AutoMapper;
using GestaoPatrimonial.Application.Dtos;
using GestaoPatrimonial.Domain.Entities;

namespace GestaoPatrimonial.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<BranchOffice, BranchOfficeDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<PatrimonialAsset, PatrimonialAssetDto>().ReverseMap();
            CreateMap<Subcategory, SubcategoryDto>().ReverseMap();
        }
    }
}
