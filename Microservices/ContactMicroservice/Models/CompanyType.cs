using System;
using System.Collections.Generic;

namespace ContactMicroservice.Models;

public partial class CompanyType
{
    public int CompanyTypeId { get; set; }

    public string? CompanyType1 { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsProcessed { get; set; }
}
