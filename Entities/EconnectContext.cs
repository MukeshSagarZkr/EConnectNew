using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public partial class EconnectContext : DbContext
{
    public EconnectContext()
    {
    }

    public EconnectContext(DbContextOptions<EconnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyType> CompanyTypes { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactPreference> ContactPreferences { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<FormField> FormFields { get; set; }

    public virtual DbSet<LeadAddress> LeadAddresses { get; set; }

    public virtual DbSet<LeadMaster> LeadMasters { get; set; }

    public virtual DbSet<LeadStatus> LeadStatuses { get; set; }

    public virtual DbSet<LeadType> LeadTypes { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<QuoteDetail> QuoteDetails { get; set; }

    public virtual DbSet<QuoteProduct> QuoteProducts { get; set; }

    public virtual DbSet<ReferalSource> ReferalSources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NGSKJ08;persist security info=True; Integrated Security=SSPI; Initial Catalog=EConnect;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("pk_Company_CompanyID");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyFullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyShortName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsProcessed)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<CompanyType>(entity =>
        {
            entity.HasKey(e => e.CompanyTypeId).HasName("pk_CompanyType_ID");

            entity.ToTable("CompanyType");

            entity.Property(e => e.CompanyTypeId).HasColumnName("CompanyTypeID");
            entity.Property(e => e.CompanyType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CompanyType");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => new { e.CompanyId, e.ContactId }).HasName("PK_Contact_Pid_CId");

            entity.ToTable("Contact");

            entity.HasIndex(e => new { e.CompanyId, e.ContactId }, "IX_Contact").IsUnique();

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
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CompanyType)
                .HasMaxLength(100)
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

            entity.HasOne(d => d.Company).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_Company");
        });

        modelBuilder.Entity<ContactPreference>(entity =>
        {
            entity.HasKey(e => e.ContactPreferenceId).HasName("pk_ContactPreference_ContactPreferenceID");

            entity.ToTable("ContactPreference");

            entity.Property(e => e.ContactPreferenceId).HasColumnName("ContactPreferenceID");
            entity.Property(e => e.ContactPrference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("pk_EventType_EventTypeID");

            entity.ToTable("EventType");

            entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EventType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EventType");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<FormField>(entity =>
        {
            entity.HasKey(e => e.FieldId).HasName("PK__FormFiel__C8B6FF273B0E3037");

            entity.Property(e => e.FieldId).HasColumnName("FieldID");
            entity.Property(e => e.DefaultValue).HasMaxLength(255);
            entity.Property(e => e.FieldDataType).HasMaxLength(50);
            entity.Property(e => e.FieldName).HasMaxLength(100);
            entity.Property(e => e.FieldType).HasMaxLength(50);
            entity.Property(e => e.ScreenName).HasMaxLength(100);
        });

        modelBuilder.Entity<LeadAddress>(entity =>
        {
            entity.HasKey(e => e.LeadAddressId).HasName("pk_LeadAddress_LeadAddressID");

            entity.ToTable("LeadAddress");

            entity.Property(e => e.LeadAddressId).HasColumnName("LeadAddressID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LeadAddress1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LeadAddress");
            entity.Property(e => e.LeadId).HasColumnName("LeadID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Lead).WithMany(p => p.LeadAddresses)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("fk_LeadAddress_LeadID");
        });

        modelBuilder.Entity<LeadMaster>(entity =>
        {
            entity.HasKey(e => e.LeadId).HasName("pk_LeadMaster");

            entity.ToTable("LeadMaster");

            entity.Property(e => e.LeadId).HasColumnName("LeadID");
            entity.Property(e => e.AssignedLeadId).HasColumnName("AssignedLeadID");
            entity.Property(e => e.BillingContacts)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BusinessPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CellPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.OrganisationName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Others)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WebSite)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LeadStatus>(entity =>
        {
            entity.HasKey(e => e.LeadStatusId).HasName("pk_LeadStatus_LeadStatusID");

            entity.ToTable("LeadStatus");

            entity.Property(e => e.LeadStatusId).HasColumnName("LeadStatusID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LeadStatus1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LeadStatus");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<LeadType>(entity =>
        {
            entity.HasKey(e => e.LeadTypeId).HasName("pk_LeadType_LeadTypeID");

            entity.ToTable("LeadType");

            entity.Property(e => e.LeadTypeId).HasColumnName("LeadTypeID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LeadType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LeadType");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => new { e.LoginId, e.CompanyId }).HasName("PK_Login_LoginID_PropertID");

            entity.ToTable("Login");

            entity.Property(e => e.LoginId).ValueGeneratedOnAdd();
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

            entity.HasOne(d => d.Company).WithMany(p => p.Logins)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Login_Company");
        });

        modelBuilder.Entity<QuoteDetail>(entity =>
        {
            entity.HasKey(e => e.QuoteDetailId).HasName("pk_QuoteDetail_QuoteDetailID");

            entity.ToTable("QuoteDetail");

            entity.Property(e => e.QuoteDetailId).HasColumnName("QuoteDetailID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.LeadId).HasColumnName("LeadID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MonthlyPrice).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.ProductVersion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecurringTotal).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.SetupTotal).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.YearlyPrice).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.Lead).WithMany(p => p.QuoteDetails)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("fk_QuoteDetail_LeadID");
        });

        modelBuilder.Entity<QuoteProduct>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LeadId).HasColumnName("LeadID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            entity.Property(e => e.Product)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.QuoteDetailId).HasColumnName("QuoteDetailID");
            entity.Property(e => e.QuoteProductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("QuoteProductID");

            entity.HasOne(d => d.Lead).WithMany()
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("fk_QuoteProducts_LeadID");

            entity.HasOne(d => d.QuoteDetail).WithMany()
                .HasForeignKey(d => d.QuoteDetailId)
                .HasConstraintName("fk_QuoteProducts_QuoteDetailID");
        });

        modelBuilder.Entity<ReferalSource>(entity =>
        {
            entity.HasKey(e => e.ReferalSourceId).HasName("pk_ReferalSource_ID");

            entity.ToTable("ReferalSource");

            entity.Property(e => e.ReferalSourceId).HasColumnName("ReferalSourceID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferalSource1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ReferalSource");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
