using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("Loai")]
public partial class Loai
{
    [Key]
    public int MaLoai { get; set; }

    [StringLength(50)]
    public string TenLoai { get; set; } = null!;

    [StringLength(50)]
    public string? TenLoaiAlias { get; set; }

    public string? MoTa { get; set; }

    [StringLength(50)]
    public string? Hinh { get; set; }

    [InverseProperty("MaLoaiNavigation")]
    public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
