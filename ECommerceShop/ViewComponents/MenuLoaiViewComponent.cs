using ECommerceShop.Context;
using ECommerceShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShop.ViewComponents;

public class MenuLoaiViewComponent : ViewComponent
{
    private readonly ECommerceDBContext db;
    
    public MenuLoaiViewComponent(ECommerceDBContext ctx) => db = ctx;

    public IViewComponentResult Invoke()
    {
        var data = db.Loais.Select(lo => new MenuLoaiViewModel
        {
            MaLoai = lo.MaLoai,
            TenLoai = lo.TenLoai,
            Soluong = lo.HangHoas.Count
        }).OrderBy(item => item.TenLoai);

        // return View(data);  Default cs.html file
        return View("Default", data); // Custom cs.html file
    }
}