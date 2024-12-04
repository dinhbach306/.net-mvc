using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("TrangThai")]
public partial class TrangThai
{
    [Key]
    public int MaTrangThai { get; set; }

    [StringLength(50)]
    public string TenTrangThai { get; set; } = null!;

    [StringLength(500)]
    public string? MoTa { get; set; }

    [InverseProperty("MaTrangThaiNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
