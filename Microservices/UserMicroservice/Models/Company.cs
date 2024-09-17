using System;
using System.Collections.Generic;

namespace UserMicroservice.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? CompanyShortName { get; set; }

    public string? CompanyFullName { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? IsProcessed { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
