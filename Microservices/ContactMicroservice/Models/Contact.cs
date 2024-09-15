using System;
using System.Collections.Generic;

namespace ContactMicroservice.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public int PropertyId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PropertyName { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Country { get; set; }

    public string? Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public byte? ContactPref { get; set; }

    public string? ReferSource { get; set; }

    public string? ReferSourceOthers { get; set; }

    public string? ProductVersionId { get; set; }

    public string? Comments { get; set; }

    public bool? MailingList { get; set; }

    public bool? ContactType { get; set; }

    public DateTime? CreatedDt { get; set; }

    public string? SupportPlan { get; set; }

    public string? SupportExpDt { get; set; }

    public string? EwrexpDt { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDesc { get; set; }

    public string? UnlockCode { get; set; }

    public string? Status { get; set; }

    public string? ReasonType { get; set; }

    public string? ReasonDesc { get; set; }

    public DateTime? CallBackDate { get; set; }

    public string? CallBackTime { get; set; }

    public string? WebSite { get; set; }

    public string? PropertyType { get; set; }

    public decimal? NoRooms { get; set; }

    public string? PurchaseDt { get; set; }

    public string? Testimonial { get; set; }

    public bool? DisplayTestimonial { get; set; }

    public string? Objections { get; set; }

    public string? Province { get; set; }

    public string? Role1 { get; set; }

    public string? Role2 { get; set; }

    public DateTime? DateRequested { get; set; }

    public string? Cellphone { get; set; }

    public byte? TypeofLead { get; set; }

    public string? BudgetNotes { get; set; }

    public string? EventNotes { get; set; }

    public string? Customerneeds { get; set; }

    public DateTime? ContractDt { get; set; }

    public string? Posid { get; set; }

    public DateOnly? LeadConversionDate { get; set; }

    public int GuestId { get; set; }

    public string? ProductVersion { get; set; }

    public string? MonthlyPrice { get; set; }

    public string? YearlyPrice { get; set; }

    public string? Discount { get; set; }

    public string? Tax { get; set; }

    public string? AdditionalPurchase { get; set; }

    public string? SetupTotal { get; set; }

    public string? RecurringTotal { get; set; }

    public string? CompanyName { get; set; }

    public string? BillingContacts { get; set; }

    public string? Email2 { get; set; }

    public string? SalesId { get; set; }

    public string? DemoDt { get; set; }

    public string? FreetrialDt { get; set; }

    public string ValidationStatus { get; set; } = null!;

    public string ValidatedUser { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public int? DonationId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? IsProcessed { get; set; }

    public virtual Property Property { get; set; } = null!;
}
