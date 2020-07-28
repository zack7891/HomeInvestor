namespace HomeInvestor.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Owner : DbContext
    {
        // Your context has been configured to use a 'Owner' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HomeInvestor.Models.Owner' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Owner' 
        // connection string in the application configuration file.
        public Owner()
            : base("name=Owner")
        {
            
        }
        public partial class GetOwner
        {
            public int Id { get; set; }
            public byte EthAddress { get; set; }
        }
          

    }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

    

}