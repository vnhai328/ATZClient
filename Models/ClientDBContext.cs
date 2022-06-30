using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ATZClient.Models
{
    public partial class ClientDBContext : DbContext
    {
        public ClientDBContext()
            : base("name=ClientDBContext2")
        {
        }

        public virtual DbSet<tblAccount> tblAccounts { get; set; }
        public virtual DbSet<tblHeader> tblHeaders { get; set; }
        public virtual DbSet<tblMenu> tblMenus { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }
        public virtual DbSet<tblProductImage> tblProductImages { get; set; }
        public virtual DbSet<tblProductPrice> tblProductPrices { get; set; }
        public virtual DbSet<tblSlider> tblSliders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblMenu>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<tblProductPrice>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblProductPrice>()
                .Property(e => e.PriceSale)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tblSlider>()
                .Property(e => e.Description)
                .IsFixedLength();
        }
    }
}
