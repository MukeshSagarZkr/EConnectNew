﻿using System;
using System.Collections.Generic;

namespace UserMicroservice.Models;

public partial class ContactPreference
{
    public int ContactPreferenceId { get; set; }

    public string? ContactPrference { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsProcessed { get; set; }
}
