﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.Models
{
    public class login
    {


        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}