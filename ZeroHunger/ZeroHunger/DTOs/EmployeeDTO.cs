using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHunger.DTOs
{
    public class EmployeeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
    }
}