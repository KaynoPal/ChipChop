using chipchop.Core.Interface;
using chipchop.Core.ViewModels;
using chipchop.Datalayer.Context;
using chipchop.Datalayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChipChop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [UserRole("admin")]
    public class OwnerController : Controller
    {
        IAdmin _admin;
        public OwnerController(IAdmin admin)
        {
            _admin = admin;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _admin.GetUser(User.Identity.Name);
            return View(user);
        }
    }
}
