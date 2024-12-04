using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("PhongBan")]
public partial class PhongBan
{
    [Key]
    [Column("MaPB")]
    [StringLength(7)]
    [Unicode(false)]
    public string MaPb { get; set; } = null!;

    [Column("TenPB")]
    [StringLength(50)]
    public string TenPb { get; set; } = null!;

    public string? ThongTin { get; set; }

    [InverseProperty("MaPbNavigation")]
    public virtual ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();

    [InverseProperty("MaPbNavigation")]
    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
