using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Keyless]
public partial class VChiTietHoaDon
{
    [Column("MaCT")]
    public int MaCt { get; set; }

    [Column("MaHD")]
    public int MaHd { get; set; }

    [Column("MaHH")]
    public int MaHh { get; set; }

    public double DonGia { get; set; }

    public int SoLuong { get; set; }

    public double GiamGia { get; set; }

    [Column("TenHH")]
    [StringLength(50)]
    public string TenHh { get; set; } = null!;
}
