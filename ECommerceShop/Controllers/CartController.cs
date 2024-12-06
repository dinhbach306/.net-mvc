using ECommerceShop.Context;
using ECommerceShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ECommerceShop.Helpers;

namespace ECommerceShop.Controllers;

public class CartController: Controller
{
    private readonly ECommerceDBContext db;
    public CartController(ECommerceDBContext ctx) => db = ctx;

    private const string CART_KEY = "MYCART";
    
    public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(CART_KEY) 
                                  ?? new List<CartItem>();
    
    public IActionResult Index()
    {
        return View(Cart);
    }
    
    public IActionResult AddToCart(int id, int quantity = 1)
    {
        var gioHang = Cart;
        var item = gioHang.SingleOrDefault(p => p.MaHh == id);
        if (item == null)
        {
            var hangHoa = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
            if (Object.ReferenceEquals(hangHoa, null))
            {
                TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                return Redirect("/404");
            }

            item = new CartItem
            {
                MaHh = hangHoa.MaHh,
                TenHH = hangHoa.TenHh,
                DonGia = hangHoa.DonGia ?? 0,
                Hinh = hangHoa.Hinh ?? string.Empty,
                SoLuong = quantity
            };
            gioHang.Add(item);
        }
        else
        {
            item.SoLuong += quantity;
        }
        HttpContext.Session.Set(CART_KEY, gioHang);
        return RedirectToAction("Index");
    }

    public IActionResult RemoveCart(int id)
    {
        var gioHang = Cart;
        var item = gioHang.SingleOrDefault(p => p.MaHh == id);
        if (item != null)
        {
            gioHang.Remove(item);
            HttpContext.Session.Set(CART_KEY, gioHang);
        }
        return RedirectToAction("Index");
    }
}