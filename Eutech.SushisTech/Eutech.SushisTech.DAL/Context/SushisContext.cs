using Eutech.SushisTech.DAL.Orders;
using Eutech.SushisTech.DAL.Products;
using Eutech.SushisTech.DAL.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eutech.SushisTech.DAL.Context {

    public class SushisContext : DbContext {

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<MenuProduct> MenuProducts { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
