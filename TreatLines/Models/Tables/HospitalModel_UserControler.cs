﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatLines.Models.Tables
{
    public class HospitalModel_UserControler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string RegisterDateTime { get; set; }
    }
}
