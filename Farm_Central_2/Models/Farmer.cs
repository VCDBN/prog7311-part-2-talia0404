using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Farm_Central_2.Models
{
    public partial class Farmer
    {
        public Farmer()
        {
            FarmerProducts = new HashSet<FarmerProducts>();
        }

        public int FarmerId { get; set; }
        public string FarmerUsername { get; set; }
        public string FarmerPassword { get; set; }

        public virtual ICollection<FarmerProducts> FarmerProducts { get; set; }
    }
}
