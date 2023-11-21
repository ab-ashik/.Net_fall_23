using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.EF;

namespace ZeroHunger.DTOs
{
    public class DistributionDTO
    {
        public int id { get; set; }
        public int request_id { get; set; }
        public int emp_id { get; set; }
        public System.DateTime dist_date { get; set; }
        public string status { get; set; }

        //public virtual collection_rqsts collection_rqsts { get; set; }
        //public virtual Employee Employee { get; set; }

    }
}