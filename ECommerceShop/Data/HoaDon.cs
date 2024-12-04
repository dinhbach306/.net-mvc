using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("HoaDon")]
public partial class HoaDon
{
    [Key]
    [Column("MaHD")]
    public int MaHd { get; set; }

    [Column("MaKH")]
    [StringLength(20)]
    public string MaKh { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime NgayDat { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayCan { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayGiao { get; set; }

    [StringLength(50)]
    public string? HoTen { get; set; }

    [StringLength(60)]
    public string DiaChi { get; set; } = null!;

    [StringLength(50)]
    public string CachThanhToan { get; set; } = null!;

    [StringLength(50)]
    public string CachVanChuyen { get; set; } = null!;

    public double PhiVanChuyen { get; set; }

    public int MaTrangThai { get; set; }

    [Column("MaNV")]
    [StringLength(50)]
    public string? MaNv { get; set; }

    [StringLength(50)]
    public string? GhiChu { get; set; }

    [ForeignKey("MaKh")]
    [InverseProperty("HoaDons")]
    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    [ForeignKey("MaNv")]
    [InverseProperty("HoaDons")]
    public virtual NhanVien? MaNvNavigation { get; set; }

    [ForeignKey("MaTrangThai")]
    [InverseProperty("HoaDons")]
    public virtual TrangThai MaTrangThaiNavigation { get; set; } = null!;
}
