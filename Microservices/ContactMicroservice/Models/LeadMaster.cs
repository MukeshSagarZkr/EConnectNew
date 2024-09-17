using System;
using System.Collections.Generic;

namespace ContactMicroservice.Models;

public partial class LeadMaster
{
    public int LeadId { get; set; }

    public string? ContactNumber { get; set; }

    public int? AssignedLeadId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Title { get; set; }

    public string? OrganisationName { get; set; }

    public string? Email { get; set; }

    public int? CountryCode { get; set; }

    public string? BusinessPhone { get; set; }

    public string? CellPhone { get; set; }

    public string? HomePhone { get; set; }

    public string? Fax { get; set; }

    public int? CompanyType { get; set; }

    public int? ReferralSources { get; set; }

    public string? Others { get; set; }

    public int? NoOfRooms { get; set; }

    public bool? IsChangeToCustomer { get; set; }

    public bool? IsSendEmail { get; set; }

    public string? BillingContacts { get; set; }

    public string? Email2 { get; set; }

    public string? WebSite { get; set; }

    public string? Comments { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsProcessed { get; set; }

    public virtual ICollection<LeadAddress> LeadAddresses { get; set; } = new List<LeadAddress>();

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();
}
