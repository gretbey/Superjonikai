using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Superjonikai.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superjonikai.UI
{
    public class AuthTokenRequirement : IAuthorizationRequirement
    {

    }
    public class AuthorizationHandler : AuthorizationHandler<AuthTokenRequirement>
    {
        private readonly AuthTokenService authTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationHandler(AuthTokenService authTokenS, IHttpContextAccessor httpContextAccessor)
        {
            authTokenService = authTokenS;
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthTokenRequirement requirement)
        {
            string authHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Token"))
            {
                var userId = authTokenService.Validate(authHeader.Substring("Token ".Length).Trim());
                if (userId < 0)
                    _httpContextAccessor.HttpContext.Response.StatusCode = 401;
                else
                    _httpContextAccessor.HttpContext.Items.Add("currentUserId", userId);
                
            }
            else
            {
                _httpContextAccessor.HttpContext.Response.StatusCode = 401;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }

    }
  
}
