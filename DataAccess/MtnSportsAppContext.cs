using DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MtnSportsAppContext : DbContext
    {
        public MtnSportsAppContext(DbContextOptions<MtnSportsAppContext> options) : base(options) { }

        public DbSet<Item>? Items{ get; set; }
        public DbSet<ItemOrder>? ItemOrders { get; set; }
        public DbSet<Order>? Orders{ get; set; }
        public DbSet<User>? Users { get; set; }
    }
}