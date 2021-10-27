﻿using System;
using System.Threading.Tasks;
using async_inn.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace async_inn.Services.Identity
{
    public class IdentityUserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> Register(RegisterData data)
        {
            var user = new ApplicationUser
            {
                Email = data.Username,
                UserName = data.Username,
            };

            var result = await userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                return user;
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";
                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }
    }
}
