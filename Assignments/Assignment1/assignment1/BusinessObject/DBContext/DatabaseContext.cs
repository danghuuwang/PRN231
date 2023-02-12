using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.DBContext;

public class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId });
        });
        
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
    
    public virtual DbSet<Product> Products { get; set; }
    
    public virtual DbSet<Category> Categories { get; set; }
    
    public virtual DbSet<Member> Members { get; set; }
    
    public virtual DbSet<Order> Orders { get; set; }
    
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
}