using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("NhanVien")]
public partial class NhanVien
{
    [Key]
    [Column("MaNV")]
    [StringLength(50)]
    public string MaNv { get; set; } = null!;

    [StringLength(50)]
    public string HoTen { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string? MatKhau { get; set; }

    [InverseProperty("MaNvNavigation")]
    public virtual ICollection<ChuDe> ChuDes { get; set; } = new List<ChuDe>();

    [InverseProperty("MaNvNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    [InverseProperty("MaNvNavigation")]
    public virtual ICollection<HoiDap> HoiDaps { get; set; } = new List<HoiDap>();

    [InverseProperty("MaNvNavigation")]
    public virtual ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();
}
