using AutoMapper;
using GestaoPatrimonial.Application.CqrsAddress.Commands;
using GestaoPatrimonial.Application.CqrsBranchOffice.Commands;
using GestaoPatrimonial.Application.CqrsCategory.Commands;
using GestaoPatrimonial.Application.CqrsCompany.Commands;
using GestaoPatrimonial.Application.CqrsDepartment.Commands;
using GestaoPatrimonial.Application.CqrsPatrimonialAsset.Commands;
using GestaoPatrimonial.Application.CqrsSubcategory.Commands;
using GestaoPatrimonial.Application.Dtos;

namespace GestaoPatrimonial.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            CreateMap<AddressDto, AddressCreateCommand>();
            CreateMap<AddressDto, AddressUpdateCommand>();

            CreateMap<BranchOfficeDto, BranchOfficeCreateCommand>();
            CreateMap<BranchOfficeDto, BranchOfficeUpdateCommand>();

            CreateMap<CategoryDto, CategoryCreateCommand>();
            CreateMap<CategoryDto, CategoryUpdateCommand>();

            CreateMap<CompanyDto, CompanyCreateCommand>();
            CreateMap<CompanyDto, CompanyUpdateCommand>();

            CreateMap<DepartmentDto, DepartmentCreateCommand>();
            CreateMap<DepartmentDto, DepartmentUpdateCommand>();

            CreateMap<PatrimonialAssetDto, PatrimonialAssetCreateCommand>();
            CreateMap<PatrimonialAssetDto, PatrimonialAssetUpdateCommand>();

            CreateMap<SubcategoryDto, SubcategoryCreateCommand>();
            CreateMap<SubcategoryDto, SubcategoryUpdateCommand>();
        }
    }
}
