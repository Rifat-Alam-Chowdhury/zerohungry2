using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Restaurant
{
    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<CollectionRequest> CollectionRequests { get; set; } = new List<CollectionRequest>();
}
