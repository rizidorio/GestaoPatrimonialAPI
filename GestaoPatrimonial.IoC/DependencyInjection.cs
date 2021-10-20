using GestaoPatrimonial.Application.Interfaces;
using GestaoPatrimonial.Application.Mappings;
using GestaoPatrimonial.Application.Services;
using GestaoPatrimonial.Data.Context;
using GestaoPatrimonial.Data.Identity;
using GestaoPatrimonial.Data.Repository;
using GestaoPatrimonial.Domain.Account;
using GestaoPatrimonial.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GestaoPatrimonial.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Azure"),
                                                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.AllowedUserNameCharacters = string.Empty;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
             .AddRoleManager<RoleManager<IdentityRole>>()
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBrachOfficeRepository, BrachOfficeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IPatrimonialAssetRepository, PatrimonialAssetRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBranchOfficeService, BranchOfficeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IPatrimonialAssetService, PatrimonialAssetService>();
            services.AddScoped<ISubcategoryService, SubcategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRolerInitial, SeedUserRolerInitial>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("GestaoPatrimonial.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}
