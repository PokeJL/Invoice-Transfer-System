using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData.Models;

public partial class Invoice
{
    [Key]
    [Column("InvoiceID")]
    public int InvoiceId { get; set; }

    [Column("VendorID")]
    public int VendorId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string InvoiceNumber { get; set; } = null!;

    public DateOnly InvoiceDate { get; set; }

    [Column(TypeName = "money")]
    public decimal InvoiceTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal PaymentTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal CreditTotal { get; set; }

    [Column("TermsID")]
    public int TermsId { get; set; }

    public DateOnly InvoiceDueDate { get; set; }

    public DateOnly? PaymentDate { get; set; }

    [InverseProperty("Invoice")]
    public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = new List<InvoiceLineItem>();

    [ForeignKey("TermsId")]
    [InverseProperty("Invoices")]
    public virtual Term Terms { get; set; } = null!;

    [ForeignKey("VendorId")]
    [InverseProperty("Invoices")]
    public virtual Vendor Vendor { get; set; } = null!;
}
