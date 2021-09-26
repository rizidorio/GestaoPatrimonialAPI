using GestaoPatrimonial.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace GestaoPatrimonial.Data.Identity
{
    public class SeedUserRolerInitial : ISeedUserRolerInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManage;

        public SeedUserRolerInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManage = roleManager;
        }

        public void SeedRoles()
        {
            string userName = "usuarioteste@localhost";
            if (_userManager.FindByEmailAsync(userName).Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = userName,
                    Email = userName,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                };

                IdentityResult result = _userManager.CreateAsync(user, "teste123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            string adminName = "adminteste@localhost";
            if (_userManager.FindByEmailAsync(userName).Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = adminName,
                    Email = adminName,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                };

                IdentityResult result = _userManager.CreateAsync(user, "teste123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedUsers()
        {
            if (!_roleManage.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "User",
                };

                IdentityResult result = _roleManage.CreateAsync(role).Result;
            }

            if (!_roleManage.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin",
                };

                IdentityResult result = _roleManage.CreateAsync(role).Result;
            }
        }
    }
}
