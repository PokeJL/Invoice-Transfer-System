using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData.Models;

public partial class Term
{
    [Key]
    [Column("TermsID")]
    public int TermsId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TermsDescription { get; set; } = null!;

    public short TermsDueDays { get; set; }

    [InverseProperty("Terms")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    [InverseProperty("DefaultTerms")]
    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
