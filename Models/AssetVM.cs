using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeInvestor.Models
{
    public class AssetVM
    {
        public string PrivateKey { get; set; }
        public string BuyerAddress { get; set; }
        public int Ownership { get; set; }
        public int Duration { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int HomeValue { get; set; }

        public string OwnerUserId { get; set; }

        public Asset ConvertToAsset() 
        {
            return new Asset
            {
                Address = Address,
                City = City,
                State = State,
                ZipCode = ZipCode,
                Bedrooms = Bedrooms,
                Bathrooms = Bathrooms,
                OwnerUserId = OwnerUserId
            };
        }
    }
}