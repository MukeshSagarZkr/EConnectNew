using System;
using System.Collections.Generic;
using ContactMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using UserMicroservice.Models;

namespace UsertMicroservice.Models;

public partial class EconnectContext : DbContext
{
    public EconnectContext()
    {
        //scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "Data Source=DESKTOP-DDGFN4K\SQL2022;Initial Catalog=EConnect;Uid=sa;Password=sql2022;TrustServerCertificate=true;"  -OutputDir Models
    }

    public EconnectContext(DbContextOptions<EconnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => new { e.PropertyId, e.ContactId }).HasName("PK_Contact_Pid_CId");

            entity.ToTable("Contact");

            entity.HasIndex(e => new { e.PropertyId, e.ContactId }, "IX_Contact").IsUnique();

            entity.Property(e => e.ContactId).ValueGeneratedOnAdd();
            entity.Property(e => e.AdditionalPurchase)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address1).HasMaxLength(200);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.BillingContacts)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BudgetNotes).HasColumnType("text");
            entity.Property(e => e.CallBackDate).HasColumnType("datetime");
            entity.Property(e => e.CallBackTime)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Cellphone)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.City).HasMaxLength(60);
            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContractDt).HasColumnType("datetime");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Customerneeds).HasColumnType("text");
            entity.Property(e => e.DateRequested).HasColumnType("datetime");
            entity.Property(e => e.DemoDt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Discount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Email2).HasMaxLength(100);
            entity.Property(e => e.EventNotes).HasColumnType("text");
            entity.Property(e => e.EwrexpDt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EWRExpDt");
            entity.Property(e => e.Fax).HasMaxLength(30);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.FreetrialDt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsProcessed)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("INC")
                .IsFixedLength();
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MonthlyPrice)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NoRooms).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Objections)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Phone1).HasMaxLength(50);
            entity.Property(e => e.Phone2).HasMaxLength(50);
            entity.Property(e => e.Posid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("POSId");
            entity.Property(e => e.ProductDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductVersion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductVersionId)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ProductVersionID");
            entity.Property(e => e.PropertyName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PropertyType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseDt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReasonDesc).IsUnicode(false);
            entity.Property(e => e.ReasonType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecurringTotal)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReferSource)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ReferSourceOthers)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SalesId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SetupTotal)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(60);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SupportExpDt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupportPlan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tax)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Testimonial).HasColumnType("text");
            entity.Property(e => e.UnlockCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValidatedUser)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ValidationStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WebSite)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.YearlyPrice)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Zip).HasMaxLength(30);

            entity.HasOne(d => d.Property).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_Property");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => new { e.LoginId, e.PropertyId }).HasName("PK_Login_LoginID_PropertID");

            entity.ToTable("Login");

            entity.Property(e => e.LoginId).ValueGeneratedOnAdd();
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.ExpiryDate).HasColumnType("smalldatetime");
            entity.Property(e => e.IsProcessed)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("INC")
                .IsFixedLength();
            entity.Property(e => e.Login1)
                .HasMaxLength(255)
                .HasColumnName("Login");
            entity.Property(e => e.LoginType).HasMaxLength(50);
            entity.Property(e => e.NewProcess).HasMaxLength(500);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.ShortName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Property).WithMany(p => p.Logins)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Login_Property");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("pk_Property_PropertyID");

            entity.ToTable("Property");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsProcessed)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PropertyFullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PropertyShortName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
