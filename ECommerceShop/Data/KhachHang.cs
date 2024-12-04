using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("KhachHang")]
public partial class KhachHang
{
    [Key]
    [Column("MaKH")]
    [StringLength(20)]
    public string MaKh { get; set; } = null!;

    [StringLength(50)]
    public string? MatKhau { get; set; }

    [StringLength(50)]
    public string HoTen { get; set; } = null!;

    public bool GioiTinh { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime NgaySinh { get; set; }

    [StringLength(60)]
    public string? DiaChi { get; set; }

    [StringLength(24)]
    public string? DienThoai { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string? Hinh { get; set; }

    public bool HieuLuc { get; set; }

    public int VaiTro { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RandomKey { get; set; }

    [InverseProperty("MaKhNavigation")]
    public virtual ICollection<BanBe> BanBes { get; set; } = new List<BanBe>();

    [InverseProperty("MaKhNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    [InverseProperty("MaKhNavigation")]
    public virtual ICollection<YeuThich> YeuThiches { get; set; } = new List<YeuThich>();
}
