using System;
using System.Collections.Generic;

namespace ContactMicroservice.Models;

public partial class LeadAddress
{
    public int LeadAddressId { get; set; }

    public string? LeadAddress1 { get; set; }

    public int? LeadId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsProcessed { get; set; }

    public virtual LeadMaster? Lead { get; set; }
}
