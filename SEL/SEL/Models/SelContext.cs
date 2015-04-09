using SEL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL.DAL
{
    class SelContext : DbContext
    {
        public SelContext() : base("SelContext")
        {

        }
        //public DbSet<User> users { get; set; }
        //public DbSet<Message> message { get; set; }
        public DbSet<Tag> tags { get; set; }
        public DbSet<OfferTag> offerTag { get; set; }
        //public DbSet<Offer> offer { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<SEL.Models.User> User { get; set; }

        public DbSet<SEL.Models.Message> Message { get; set; }

        public DbSet<SEL.Models.Offer> Offer { get; set; }
    }
}
