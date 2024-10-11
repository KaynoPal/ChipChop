using chipchop.Core.Interface;
using chipchop.Core.ViewModels;
using chipchop.Datalayer.Models;
using ChipChop.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Xml;

namespace chipchop.Controllers;
public class ChipController : Controller
{
    IAdmin _admin;
    IShopping _shopping;

    public ChipController(IAdmin admin, IShopping shopping)
    {
        _admin = admin;
        _shopping = shopping;
    }

    public async Task<IActionResult> Index()
    {
        var groups = await _admin.GetGroups();
        ViewBag.groups = groups.Where(g => !g.Visible);
        var Contents = await _admin.GetContents(visible: false);
        return View(Contents);
    }

    public async Task<IActionResult> ContentPage(int id)
    {
        var Content = await _admin.GetContent(id);
        if(Content == null) return RedirectToAction(nameof(Index));
        ViewBag.related = await _admin.GetContents(groupId: Content.GroupId, ContentId: Content.Id);
        ViewBag.InCart = false;

        var addShopping = new AddShoppingVM();
        if (User.Identity.IsAuthenticated)
        {
            var userId = (await _admin.GetUser(User.Identity.Name)).Id;

            var userFactor = await _shopping.GetFactor(userId);
            if (userFactor is not null)
            {
                ViewBag.InCart = userFactor.Details.Select(f => f.ContentId).Contains(Content.Id);
            }

            addShopping.Userid = userId;
            addShopping.Contentid = Content.Id;
            addShopping.Shoppingcount = 1;
        }

        //two model (c , a) in tuple
        var Contentshop = (Content, addShopping);

        //return View(Content);
        return View(Contentshop);
    }

    public async Task<IActionResult> ContentsOfGroup(int Id)
    {
        var Contents = await _admin.GetContents(Id);
        ViewBag.GN = (await _admin.GetGroup(Id)).GroupName;
        if (Contents == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return View(Contents);
    }

    public async Task<IActionResult> Search(string ContentName)
    {
        ViewBag.search = ContentName;
        if (string.IsNullOrEmpty(ContentName))
            return RedirectToAction(nameof(Index));
        var contents = await _admin.Search(ContentName);
        return View("ContentsOfGroup",contents);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToShoppingCart(AddShoppingVM shopping)
    {
        var factor = await _shopping.AddFactor(shopping);
        if (factor == null) return RedirectToAction(nameof(Index));
        return RedirectToAction(nameof(ShoppingCart), new { userId = factor.UserId });
    }


    public async Task<IActionResult> ShoppingCart(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            var user = User.Identity.IsAuthenticated;
            if (user)
            {
                var id = (await _admin.GetUser(User.Identity.Name)).Id;
                var cart = await _shopping.GetFactor(id);

                return View(cart);
            }
            return RedirectToAction(nameof(Index));
        }

        var shoppingCart = await _shopping.GetFactor(userId);

        return View(shoppingCart);
    }

    public async Task<IActionResult> PreShoppingPay(int factorId)
    {
        var iran = new XmlDocument();
        iran.Load("wwwroot/xml/irancities.xml");

        var cities = iran.SelectNodes("/iran/city");

        var cityList = new List<CitiesVM>();
        foreach (XmlNode item in cities)
        {
            var city = new CitiesVM()
            {
                province = item["province_name"].InnerXml,
                city = item["city_name"].InnerXml
            };
            cityList.Add(city);
        }

        ViewBag.CityList = cityList;
        var user = await _admin.GetUser(User.Identity.Name);

        if (user.UserInfo is not null)
            return View(user.UserInfo);//userDetail

        var tmpUser = new UserInfo()
        {
            UserId = user.Id,
        };
        return View(tmpUser);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> PreShoppingPay(UserInfo userDetail)
    {
        var result = await _admin.SetUserInfo(userDetail);

        if (result)
        {
            //set factor price 
            var factorId = await _shopping.SetFactor(userDetail.UserId);
            if (factorId is 0) return RedirectToAction(nameof(Index));

            //redirect to payment method
            return RedirectToAction("RequestPaymentGate",
                                    "payment",
                                    new { id = factorId });
        }

        return View(userDetail);
    }
}
 