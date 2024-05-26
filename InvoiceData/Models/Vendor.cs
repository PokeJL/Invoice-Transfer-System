using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData.Models;

public partial class Vendor
{
    [Key]
    [Column("VendorID")]
    public int VendorId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string VendorName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? VendorAddress1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VendorAddress2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string VendorCity { get; set; } = null!;

    [StringLength(2)]
    [Unicode(false)]
    public string VendorState { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string VendorZipCode { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string? VendorPhone { get; set; }

    [Column("VendorContactLName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VendorContactLname { get; set; }

    [Column("VendorContactFName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VendorContactFname { get; set; }

    [Column("DefaultTermsID")]
    public int DefaultTermsId { get; set; }

    public int DefaultAccountNo { get; set; }

    [ForeignKey("DefaultAccountNo")]
    [InverseProperty("Vendors")]
    public virtual Glaccount DefaultAccountNoNavigation { get; set; } = null!;

    [ForeignKey("DefaultTermsId")]
    [InverseProperty("Vendors")]
    public virtual Term DefaultTerms { get; set; } = null!;

    [InverseProperty("Vendor")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
