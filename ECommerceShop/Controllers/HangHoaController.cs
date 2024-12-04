using ECommerceShop.Context;
using ECommerceShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceShop.Controllers;

public class HangHoaController : Controller
{
    private readonly ECommerceDBContext _dbContext;
    public HangHoaController(ECommerceDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // GET
    public IActionResult Index(int? loai)
    {
        var hangHoas = _dbContext.HangHoas.AsQueryable();

        if (loai.HasValue)
        {
            hangHoas = hangHoas.Where(hh => hh.MaLoai == loai.Value);
        }

        var result = hangHoas.Select(hH => new HangHoaViewModel
        {
            MaHangHoa = hH.MaHh,
            TenHangHoa = hH.TenHh,
            DonGia = hH.DonGia ?? 0,
            Hinh = hH.Hinh ?? "",
            TenLoai = hH.MaLoaiNavigation.TenLoai,
            MoTa = hH.MoTa,
        });
        return View(result);
    }

    public IActionResult Search(string? query)
    {
        var hangHoas = _dbContext.HangHoas.AsQueryable();

        if (!Object.ReferenceEquals(query, null))
        {
            hangHoas = hangHoas.Where(p => p.TenHh.Contains(query));
        }
        
        var result = hangHoas.Select(hH => new HangHoaViewModel
        {
            MaHangHoa = hH.MaHh,
            TenHangHoa = hH.TenHh,
            DonGia = hH.DonGia ?? 0,
            Hinh = hH.Hinh ?? "",
            TenLoai = hH.MaLoaiNavigation.TenLoai,
            MoTa = hH.MoTa,
        });
        return View(result);
    }
}