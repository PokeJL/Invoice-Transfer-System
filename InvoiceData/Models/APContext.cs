using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace InvoiceData.Models;

public partial class APContext : DbContext
{
    public APContext()
    {
    }

    public APContext(DbContextOptions<APContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactUpdate> ContactUpdates { get; set; }

    public virtual DbSet<Glaccount> Glaccounts { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceArchive> InvoiceArchives { get; set; }

    public virtual DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AP"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactUpdate>(entity =>
        {
            entity.Property(e => e.VendorId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Glaccount>(entity =>
        {
            entity.Property(e => e.AccountNo).ValueGeneratedNever();
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasOne(d => d.Terms).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Terms");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Invoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Vendors");
        });

        modelBuilder.Entity<InvoiceLineItem>(entity =>
        {
            entity.HasOne(d => d.AccountNoNavigation).WithMany(p => p.InvoiceLineItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InvoiceLineItems_GLAccounts");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceLineItems).HasConstraintName("FK_InvoiceLineItems_Invoices");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.Property(e => e.DefaultAccountNo).HasDefaultValue(570);
            entity.Property(e => e.DefaultTermsId).HasDefaultValue(3);
            entity.Property(e => e.VendorState).IsFixedLength();

            entity.HasOne(d => d.DefaultAccountNoNavigation).WithMany(p => p.Vendors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vendors_GLAccounts");

            entity.HasOne(d => d.DefaultTerms).WithMany(p => p.Vendors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vendors_Terms");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
