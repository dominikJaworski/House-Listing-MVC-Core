using System;
using System.Collections.Generic;

namespace HousesForSale.Models
{
    public partial class Regions
    {
        public Regions()
        {
            Houses = new HashSet<Houses>();
        }

        public int Id { get; set; }
        public string RegionName { get; set; }

        public ICollection<Houses> Houses { get; set; }
    }
}
