using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Model
{
    public class CollectionRequestModel
    {
        public int CollectionReqId { get; set; }

        public int RestaurantId { get; set; }

        public int? EmployeeId { get; set; }

        public string Status { get; set; } = null!;

        public string Foods { get; set; } = null!;

        public DateTime RequestDate { get; set; }

        public DateTime FreshTime { get; set; }
    }
}
