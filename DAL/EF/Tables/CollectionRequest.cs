using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class CollectionRequest
{
    public int CollectionReqId { get; set; }

    public int RestaurantId { get; set; }

    public int? EmployeeId { get; set; }

    public string Status { get; set; } = null!;

    public string Foods { get; set; } = null!;

    public DateTime RequestDate { get; set; }

    public DateTime FreshTime { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Restaurant Restaurant { get; set; } = null!;
}
