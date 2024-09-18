using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class QuoteDetail
{
    public int QuoteDetailId { get; set; }

    public string? ProductVersion { get; set; }

    public decimal? MonthlyPrice { get; set; }

    public decimal? YearlyPrice { get; set; }

    public decimal? Tax { get; set; }

    public decimal? Discount { get; set; }

    public decimal? SetupTotal { get; set; }

    public decimal? RecurringTotal { get; set; }

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
