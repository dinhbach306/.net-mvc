using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("HangHoa")]
public partial class HangHoa
{
    [Key]
    [Column("MaHH")]
    public int MaHh { get; set; }

    [Column("TenHH")]
    [StringLength(50)]
    public string TenHh { get; set; } = null!;

    [StringLength(50)]
    public string? TenAlias { get; set; }

    public int MaLoai { get; set; }

    [StringLength(50)]
    public string? MoTaDonVi { get; set; }

    public double? DonGia { get; set; }

    [StringLength(50)]
    public string? Hinh { get; set; }

    [Column("NgaySX", TypeName = "datetime")]
    public DateTime NgaySx { get; set; }

    public double GiamGia { get; set; }

    public int SoLanXem { get; set; }

    public string? MoTa { get; set; }

    [Column("MaNCC")]
    [StringLength(50)]
    public string MaNcc { get; set; } = null!;

    [InverseProperty("MaHhNavigation")]
    public virtual ICollection<BanBe> BanBes { get; set; } = new List<BanBe>();

    [InverseProperty("MaHhNavigation")]
    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

    [ForeignKey("MaLoai")]
    [InverseProperty("HangHoas")]
    public virtual Loai MaLoaiNavigation { get; set; } = null!;

    [ForeignKey("MaNcc")]
    [InverseProperty("HangHoas")]
    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

    [InverseProperty("MaHhNavigation")]
    public virtual ICollection<YeuThich> YeuThiches { get; set; } = new List<YeuThich>();
}
