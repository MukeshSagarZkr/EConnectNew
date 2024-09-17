using System;
using System.Collections.Generic;

namespace ContactMicroservice.Models;

public partial class FormField
{
    public int FieldId { get; set; }

    public string FieldName { get; set; } = null!;

    public string ScreenName { get; set; } = null!;

    public string FieldType { get; set; } = null!;

    public string FieldDataType { get; set; } = null!;

    public string? DefaultValue { get; set; }

    public string? Options { get; set; }
}
