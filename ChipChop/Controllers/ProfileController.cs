using chipchop.Core.Interface;
using chipchop.Core.ViewModels;
using chipchop.Datalayer.Context;
using chipchop.Datalayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chipchop.Controllers
{
    public class ProfileController : Controller
    {
        IShopping _shopping;
        IAdmin _admin;
        public ProfileController(IAdmin admin, IShopping shopping)
        {
            _admin = admin;
            _shopping = shopping;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _admin.GetUser(User.Identity.Name);
            return View(user);
        }

        public async Task<IActionResult> MyOrders(Guid id)
        {
            var orders = await _shopping.GetMyOrders(id);
            return View(orders);
        }
    }
}
