using chipchop.Core.Interface;
using chipchop.Datalayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChipChop.Areas.Admin.Controllers;

[Area("Admin")]
public class ContentsController : Controller
{
    IAdmin _admin;
    public ContentsController(IAdmin admin)
    {
        _admin = admin;
    }

    public async Task<IActionResult> Index()
    {
        var Contents = await _admin.GetContents();
        return View(Contents);
    }

    //GET
    public async Task<IActionResult> Create()
    {
        var groups = await _admin.GetGroups();
        ViewBag.Groups = new SelectList(groups, "Id", "GroupName");
        return View();
    }

    //POST
    [HttpPost]
    public async Task<IActionResult> Create(Content content,IFormFile ImgFile)
    {
        if (ModelState.IsValid && ImgFile != null)
        {
            //add content
            if (await _admin.AddContent(content, ImgFile))
                return RedirectToAction("Index");

            return RedirectToAction(nameof(Index));
        }
        ViewBag.Groups = new SelectList(await _admin.GetGroups(), "Id", "GroupName");
        return View(content);
    }

}
