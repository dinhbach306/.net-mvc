using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommerceShop.Data;

[Table("PhanQuyen")]
public partial class PhanQuyen
{
    [Key]
    [Column("MaPQ")]
    public int MaPq { get; set; }

    [Column("MaPB")]
    [StringLength(7)]
    [Unicode(false)]
    public string? MaPb { get; set; }

    public int? MaTrang { get; set; }

    public bool Them { get; set; }

    public bool Sua { get; set; }

    public bool Xoa { get; set; }

    public bool Xem { get; set; }

    [ForeignKey("MaPb")]
    [InverseProperty("PhanQuyens")]
    public virtual PhongBan? MaPbNavigation { get; set; }

    [ForeignKey("MaTrang")]
    [InverseProperty("PhanQuyens")]
    public virtual TrangWeb? MaTrangNavigation { get; set; }
}
