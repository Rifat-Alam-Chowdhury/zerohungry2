using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Employee
{
    public int EmployeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<CollectionRequest> CollectionRequests { get; set; } = new List<CollectionRequest>();
}
