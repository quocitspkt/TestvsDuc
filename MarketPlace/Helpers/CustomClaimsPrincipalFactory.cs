﻿using MarketPlace.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MarketPlace.Helpers
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<CusUser, CusUserRole>
    {
        UserManager<CusUser> _userManger;

        public CustomClaimsPrincipalFactory(UserManager<CusUser> userManager,
            RoleManager<CusUserRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
            _userManger = userManager;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(CusUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManger.GetRolesAsync(user);
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim("Email",user.Email),
                new Claim("FullName",user.FullName),
                //new Claim("Avatar",user.Avatar??string.Empty),
                new Claim("Roles",string.Join(";",roles)),
                new Claim("UserId",user.Id.ToString())
            });
            return principal;
        }
    }
}
