using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("ChiTietHD")]
public partial class ChiTietHd
{
    [Key]
    [Column("MaCT")]
    public int MaCt { get; set; }

    [Column("MaHD")]
    public int MaHd { get; set; }

    [Column("MaHH")]
    public int MaHh { get; set; }

    public double DonGia { get; set; }

    public int SoLuong { get; set; }

    public double GiamGia { get; set; }

    [ForeignKey("MaHh")]
    [InverseProperty("ChiTietHds")]
    public virtual HangHoa MaHhNavigation { get; set; } = null!;
}
