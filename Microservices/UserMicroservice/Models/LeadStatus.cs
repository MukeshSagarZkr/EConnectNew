using System;
using System.Collections.Generic;

namespace UserMicroservice.Models;

public partial class LeadStatus
{
    public int LeadStatusId { get; set; }

    public string? LeadStatus1 { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsProcessed { get; set; }
}
