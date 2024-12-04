using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("YeuThich")]
public partial class YeuThich
{
    [Key]
    [Column("MaYT")]
    public int MaYt { get; set; }

    [Column("MaHH")]
    public int? MaHh { get; set; }

    [Column("MaKH")]
    [StringLength(20)]
    public string? MaKh { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NgayChon { get; set; }

    [StringLength(255)]
    public string? MoTa { get; set; }

    [ForeignKey("MaHh")]
    [InverseProperty("YeuThiches")]
    public virtual HangHoa? MaHhNavigation { get; set; }

    [ForeignKey("MaKh")]
    [InverseProperty("YeuThiches")]
    public virtual KhachHang? MaKhNavigation { get; set; }
}
