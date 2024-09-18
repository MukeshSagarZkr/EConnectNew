using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class EventType
{
    public int EventTypeId { get; set; }

    public string? EventType1 { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsProcessed { get; set; }
}
