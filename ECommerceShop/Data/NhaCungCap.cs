using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("NhaCungCap")]
public partial class NhaCungCap
{
    [Key]
    [Column("MaNCC")]
    [StringLength(50)]
    public string MaNcc { get; set; } = null!;

    [StringLength(50)]
    public string TenCongTy { get; set; } = null!;

    [StringLength(50)]
    public string Logo { get; set; } = null!;

    [StringLength(50)]
    public string? NguoiLienLac { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string? DienThoai { get; set; }

    [StringLength(50)]
    public string? DiaChi { get; set; }

    public string? MoTa { get; set; }

    [InverseProperty("MaNccNavigation")]
    public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
