using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class collection_rqstsDTO
    {
        public int id { get; set; }
        public int restaurant_id { get; set; }
        public System.DateTime expiry_date { get; set; }
        public string status { get; set; }

    }
}