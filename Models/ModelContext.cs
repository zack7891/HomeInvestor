using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeInvestor.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("OktaConnectionString")
        {

        }
        public static ModelContext Create() => new ModelContext();
        public virtual DbSet<HouseModel> Houses { get; set; }

    }
}