using chipchop.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using chipchop.Core.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using chipchop.Datalayer.Models;
using NuGet.Protocol.Plugins;
using chipchop.Core.Classes;

namespace chipchop.Controllers
{
    public class AccountController : Controller
    {
        // ctor -> Tap button
        // تضریق وابستگی
        IAdmin _admin;
        public AccountController(IAdmin admin)
        {
            _admin = admin;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Chip");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = await _admin.GetUser(login);
                if (user == null)
                {
                    ModelState.AddModelError("Password", "کاربری یافت نشد");
                    return View(login);
                }

                //login user
                var claim = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName) //user mobile
                };

                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var principle = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true //remember me
                };
                //sign in 
                await HttpContext.SignInAsync(principle, properties);

                if (user.Role.RoleName == "admin")
                {
                    return Redirect("~/admin/owner");
                }
                return Redirect("~/Profile/index");
            }

            return View(login);
        }
        public async Task<IActionResult> SignOutUser()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Chip");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register,LoginModel login)
        {
            //var ppcc = Security.IsPasswordStrong(register.Password);
            //if (ModelState.IsValid && ppcc)
            if (ModelState.IsValid)
            {
                //check user mobile
                var user = await _admin.GetUser(register.UserName);
                if (user != null)
                {
                    ModelState.AddModelError("RePassword", $"حسابی از پیش با شماره{register.UserName}ساخته شده ");
                    return View(register);
                }
                //register user 
                if (await _admin.AddUser(register))
                {
                    var Luser = await _admin.GetUser(login);
                    var claim = new List<Claim>()
                    {
                            new Claim(ClaimTypes.NameIdentifier,Luser.Id.ToString()),
                            new Claim(ClaimTypes.Name,Luser.UserName) //user mobile
                    };

                    var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(principle, properties);
                    if (Luser.Role.RoleName == "admin")
                    {
                        return Redirect("~/admin/owner");
                    }
                    return Redirect("~/Profile/index");
                }

                ModelState.AddModelError("RePassword", "خطا در ثبت نام کاربر");
                return View(register);
            }
            ModelState.AddModelError("Password", "رمز ضعیف است");
            return View(register);
        }
    }
}
