using System;
using System.Collections.Generic;

namespace HousesForSale.Models
{
    public partial class Houses
    {
        public int HouseId { get; set; }
        public int Price { get; set; }
        public string Mlsnumber { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public int RegionId { get; set; }
        public int BuildingTypeId { get; set; }
        public int Bedrooms { get; set; }
        public decimal Bathrooms { get; set; }
        public int Storeys { get; set; }
        public int ParkingTypeId { get; set; }

        public BuildingTypes BuildingType { get; set; }
        public ParkingTypes ParkingType { get; set; }
        public Regions Region { get; set; }
    }
}
