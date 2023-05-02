using gestion_de_stock.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_de_stock.Data
{
    public class AppDbContext : DbContext
    {
        
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                 modelBuilder.Entity<Client>().ToTable("Clients");
                modelBuilder.Entity<Admin>().ToTable("Admin");
                base.OnModelCreating(modelBuilder);
                 modelBuilder.Entity<Commande>()
                .HasKey(o => o.Id);

                modelBuilder.Entity<Commande>()
                    .HasOne<Client>(o => o.client)
                    .WithMany(c => c.commandes)
                    .HasForeignKey(o => o.idClient);

                modelBuilder.Entity<Commande>()
                    .HasOne<Produit>(o => o.Produit)
                    .WithMany(p => p.commandes)
                    .HasForeignKey(o => o.idProduit);
            }
              public DbSet<Client> Customers { get; set; }
             public DbSet<Produit> Products { get; set; }
              public DbSet<Commande> Commandes { get; set; }
            public DbSet<Admin> Admins { get; set; }

        }
    }
