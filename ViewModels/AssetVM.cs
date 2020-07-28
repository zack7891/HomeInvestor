using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeInvestor.ViewModels
{
    public class AssetVM
    {
        public int HouseId { get; set; }
        public byte EthAddress { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int HomeValue { get; set; }


    }
}