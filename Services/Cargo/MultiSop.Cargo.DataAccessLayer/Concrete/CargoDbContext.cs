using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSop.Cargo.DataAccessLayer.Concrete
{
    public class CargoDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441; initial Catalog=MultiShopCargoDb; User=sa; password=Onurtopaktas.123;");
        }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoCustomer> cargoCustomers { get; set; }
        public DbSet<CargoDetail> cargoDetails { get; set; }
        public DbSet<CargoOperations> cargoOperations { get; set; }

    }
}
