using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Models.Entity;
using ConfigurationManager = Supermarket.Services.ConnectionManager;

namespace Supermarket.Models.DataAccessLayer;

public class SupermarketDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<Producer> Producer { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Receipt> Receipt { get; set; }
    public DbSet<Offer> Offer { get; set; }
    public DbSet<ProductReceipt> ProductReceipt { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-K3AUFTF;Database=SuperMarket;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
