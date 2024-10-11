
using chipchop.Datalayer.Context;
using chipchop.Datalayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChipChop.Areas.Admin.Controllers
{
    internal class UserRoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        private readonly string _roleName;

        public UserRoleAttribute(string roleName)
        {
            _roleName = roleName;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity;
            if (identity.IsAuthenticated)
            {
                var UserMobile = identity.Name;
                var user = _context.Users.FirstOrDefault(u => u.UserName == UserMobile && u.Role.RoleName == _roleName);
                if (user == null)
                {
                    context.Result = new RedirectResult("~/profile/index");
                }
            }
            else
            {
                context.Result = new RedirectResult("~/account/login");
            }
            
        }
    }
}