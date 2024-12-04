using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("PhanCong")]
public partial class PhanCong
{
    [Key]
    [Column("MaPC")]
    public int MaPc { get; set; }

    [Column("MaNV")]
    [StringLength(50)]
    public string MaNv { get; set; } = null!;

    [Column("MaPB")]
    [StringLength(7)]
    [Unicode(false)]
    public string MaPb { get; set; } = null!;

    [Column("NgayPC", TypeName = "datetime")]
    public DateTime? NgayPc { get; set; }

    public bool? HieuLuc { get; set; }

    [ForeignKey("MaNv")]
    [InverseProperty("PhanCongs")]
    public virtual NhanVien MaNvNavigation { get; set; } = null!;

    [ForeignKey("MaPb")]
    [InverseProperty("PhanCongs")]
    public virtual PhongBan MaPbNavigation { get; set; } = null!;
}
