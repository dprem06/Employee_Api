using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public partial class Transport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TripFrom { get; set; }
        public string TripTo { get; set; }
        public bool? IsActive { get; set; }
    }
}
