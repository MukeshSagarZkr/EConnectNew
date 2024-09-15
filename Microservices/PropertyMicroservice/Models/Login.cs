using System;
using System.Collections.Generic;

namespace PropertyMicroservice.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public int PropertyId { get; set; }

    public string? Login1 { get; set; }

    public string? Password { get; set; }

    public string? LoginType { get; set; }

    public string? EmailAddress { get; set; }

    public string? Company { get; set; }

    public string? ShortName { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool? Demo { get; set; }

    public string? NewProcess { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public string? IsProcessed { get; set; }

    public virtual Property Property { get; set; } = null!;
}
