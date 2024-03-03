using Microsoft.EntityFrameworkCore;

namespace JuiceBarAPI.Models
{
    public class JuiceBarDbContext:DbContext
    {
        public JuiceBarDbContext(DbContextOptions<JuiceBarDbContext> options) : base(options)
        { 
     
        }

        public DbSet<Customer> Cutomers { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }



    }
}
