﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Devon4Net.Infrastructure.MVC.Controller;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Devon4Net.Infrastructure.JWT.MVC.Controller
{
    public class Devon4NetJWTController : Devon4NetController
    {
        public Devon4NetJWTController(ILogger logger) : base(logger)
        {
        }

        public Devon4NetJWTController(ILogger logger, IMapper mapper) : base (logger,mapper)
        {
        }

        protected JwtSecurityToken GetCurrentUser()
        {
            var headerValue = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer", string.Empty).Trim();
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(headerValue);
        }

        protected Claim GetUserClaim(string claimName, JwtSecurityToken jwtUser = null)
        {
            var user = jwtUser ?? GetCurrentUser();
            return user.Claims.FirstOrDefault(c => c.Type == claimName);
        }

        protected IEnumerable<Claim> GetUserClaims(JwtSecurityToken jwtUser = null)
        {
            var user = jwtUser ?? GetCurrentUser();
            return user.Claims;
        }
    }
}
