using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("ChuDe")]
public partial class ChuDe
{
    [Key]
    [Column("MaCD")]
    public int MaCd { get; set; }

    [Column("TenCD")]
    [StringLength(50)]
    public string? TenCd { get; set; }

    [Column("MaNV")]
    [StringLength(50)]
    public string? MaNv { get; set; }

    [InverseProperty("MaCdNavigation")]
    public virtual ICollection<GopY> Gopies { get; set; } = new List<GopY>();

    [ForeignKey("MaNv")]
    [InverseProperty("ChuDes")]
    public virtual NhanVien? MaNvNavigation { get; set; }
}
