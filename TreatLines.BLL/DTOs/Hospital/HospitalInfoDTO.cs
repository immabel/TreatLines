using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreatLines.BLL.DTOs.Hospital
{
    public class HospitalInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string RegisterDate { get; set; }
        public string CreationDate { get; set; }
    }
}
