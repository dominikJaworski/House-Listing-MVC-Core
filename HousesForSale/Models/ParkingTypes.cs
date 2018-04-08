using System;
using System.Collections.Generic;

namespace HousesForSale.Models
{
    public partial class ParkingTypes
    {
        public ParkingTypes()
        {
            Houses = new HashSet<Houses>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Houses> Houses { get; set; }
    }
}
