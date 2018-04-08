using System;
using System.Collections.Generic;

namespace HousesForSale.Models
{
    public partial class Images
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public int HouseId { get; set; }
    }
}
