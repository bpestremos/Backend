using System;

namespace Backend;

public class Extensions
{
    public string? CreatedBy { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? DateUpdated { get; set; }
    public bool? IsDeleted { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DateDeleted { get; set; }
}
