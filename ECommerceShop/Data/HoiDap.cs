using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("HoiDap")]
public partial class HoiDap
{
    [Key]
    [Column("MaHD")]
    public int MaHd { get; set; }

    [StringLength(50)]
    public string CauHoi { get; set; } = null!;

    [StringLength(50)]
    public string TraLoi { get; set; } = null!;

    public DateOnly NgayDua { get; set; }

    [Column("MaNV")]
    [StringLength(50)]
    public string MaNv { get; set; } = null!;

    [ForeignKey("MaNv")]
    [InverseProperty("HoiDaps")]
    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
