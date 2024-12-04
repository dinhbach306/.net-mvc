using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("GopY")]
public partial class GopY
{
    [Key]
    [Column("MaGY")]
    [StringLength(50)]
    public string MaGy { get; set; } = null!;

    [Column("MaCD")]
    public int MaCd { get; set; }

    public string NoiDung { get; set; } = null!;

    [Column("NgayGY")]
    public DateOnly NgayGy { get; set; }

    [StringLength(50)]
    public string? HoTen { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? DienThoai { get; set; }

    public bool CanTraLoi { get; set; }

    [StringLength(50)]
    public string? TraLoi { get; set; }

    [Column("NgayTL")]
    public DateOnly? NgayTl { get; set; }

    [ForeignKey("MaCd")]
    [InverseProperty("Gopies")]
    public virtual ChuDe MaCdNavigation { get; set; } = null!;
}
