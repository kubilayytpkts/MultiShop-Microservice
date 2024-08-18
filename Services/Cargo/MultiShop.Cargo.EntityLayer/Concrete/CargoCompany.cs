﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntityLayer.Concrete
{
    public class CargoCompany
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

    }
}
