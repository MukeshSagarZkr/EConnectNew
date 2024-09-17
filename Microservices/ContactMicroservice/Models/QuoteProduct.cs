using System;
using System.Collections.Generic;

namespace ContactMicroservice.Models;

public partial class QuoteProduct
{
    public int QuoteProductId { get; set; }

    public string? Product { get; set; }

    public decimal? Price { get; set; }

    public int? QuoteDetailId { get; set; }

    public int? LeadId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsProcessed { get; set; }

    public virtual LeadMaster? Lead { get; set; }

    public virtual QuoteDetail? QuoteDetail { get; set; }
}
