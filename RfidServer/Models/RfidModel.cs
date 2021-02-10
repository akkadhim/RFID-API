namespace RfidServer.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RfidModel : DbContext
    {
        public RfidModel()
            : base("name=RfidModel")
        {
        }

         public virtual DbSet<Employee> Employees { get; set; }
    }
}