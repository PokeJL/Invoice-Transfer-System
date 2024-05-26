using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData.Models;

[PrimaryKey("InvoiceId", "InvoiceSequence")]
public partial class InvoiceLineItem
{
    [Key]
    [Column("InvoiceID")]
    public int InvoiceId { get; set; }

    [Key]
    public short InvoiceSequence { get; set; }

    public int AccountNo { get; set; }

    [Column(TypeName = "money")]
    public decimal InvoiceLineItemAmount { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string InvoiceLineItemDescription { get; set; } = null!;

    [ForeignKey("AccountNo")]
    [InverseProperty("InvoiceLineItems")]
    public virtual Glaccount AccountNoNavigation { get; set; } = null!;

    [ForeignKey("InvoiceId")]
    [InverseProperty("InvoiceLineItems")]
    public virtual Invoice Invoice { get; set; } = null!;
}
