using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
    public class OrderDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=...; initial Catalog=...; integrated Security=...;");
        }

        DbSet<Address> addresses { get; set; }
        DbSet<OrderDetail> orderDetails { get; set; }
        DbSet<Ordering> orderings { get; set; }
    }
}