using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Mobile { get; set; }
        public bool? IsActive { get; set; }
    }
}
