using chipchop.Core.Interface;
using chipchop.Core.ViewModels;
using chipchop.Datalayer.Context;
using chipchop.Datalayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chipchop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        IAdmin _admin;
        IShopping _shop;
        DatabaseContext _Context;
        public OrderController(IShopping shop,DatabaseContext Context,IAdmin admin)
        {
            _Context = Context;
            _shop = shop;
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _shop.GetOrders();
            return View(orders);
        }

        public async Task<IActionResult> PostTheOrder(int id)
        {
            var factor = await _Context.Factors.Include(f=>f.Details).FirstOrDefaultAsync(f => f.Id == id);
            var factorD = await _Context.FactorDetails.Include(f=>f.Content).FirstOrDefaultAsync(f => f.FactorId ==id);
            var user = await _admin.GetUser(User.Identity.Name);
            if (factor == null || factor.Status == "ارسال شده" || factor.Status == "بسته شده") return Redirect("~/admin/order/index");
            factor.Status = new FactorStatusVM().StatusArray[2];
            await _Context.SaveChangesAsync();
            var Order = (factor, factorD,user);
            return View(Order);
        }

        public async Task<IActionResult> SendOrder(int id)
        {
            var factor = await _Context.Factors.FindAsync(id);
            factor.Status = new FactorStatusVM().StatusArray[3];
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CloseOrder(int id)
        {
            var factor = await _Context.Factors.FindAsync(id);
            factor.Status = new FactorStatusVM().StatusArray[4];
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
