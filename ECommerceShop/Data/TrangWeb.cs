using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("TrangWeb")]
public partial class TrangWeb
{
    [Key]
    public int MaTrang { get; set; }

    [StringLength(50)]
    public string TenTrang { get; set; } = null!;

    [Column("URL")]
    [StringLength(250)]
    public string Url { get; set; } = null!;

    [InverseProperty("MaTrangNavigation")]
    public virtual ICollection<PhanQuyen> PhanQuyens { get; set; } = new List<PhanQuyen>();
}
