namespace HomeInvestor.ViewModels
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AssetVM
    {
        public int HouseId { get; set; }

        public long EthAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public int HomeValue { get; set; }
    }
}