using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("BanBe")]
public partial class BanBe
{
    [Key]
    [Column("MaBB")]
    public int MaBb { get; set; }

    [Column("MaKH")]
    [StringLength(20)]
    public string? MaKh { get; set; }

    [Column("MaHH")]
    public int MaHh { get; set; }

    [StringLength(50)]
    public string? HoTen { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime NgayGui { get; set; }

    public string? GhiChu { get; set; }

    [ForeignKey("MaHh")]
    [InverseProperty("BanBes")]
    public virtual HangHoa MaHhNavigation { get; set; } = null!;

    [ForeignKey("MaKh")]
    [InverseProperty("BanBes")]
    public virtual KhachHang? MaKhNavigation { get; set; }
}
