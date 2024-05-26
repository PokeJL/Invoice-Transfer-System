using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData.Models;

[Table("GLAccounts")]
public partial class Glaccount
{
    [Key]
    public int AccountNo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string AccountDescription { get; set; } = null!;

    [InverseProperty("AccountNoNavigation")]
    public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = new List<InvoiceLineItem>();

    [InverseProperty("DefaultAccountNoNavigation")]
    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
