using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineShop.Domain.Entities.Enums;
using System.Security.Claims;
using System.Text.Json;

namespace OnlineShop.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]

    public class IdentityFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permissionId;
        public IdentityFilterAttribute(Permissions permissions)
        {
            _permissionId = (int)permissions;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;
            string PermissionJson = identity.FindFirst("permissions")!.Value;
            bool result = JsonSerializer.Deserialize<IEnumerable<int>>(PermissionJson)!.Any(x => x == _permissionId);

            if (!result) 
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
