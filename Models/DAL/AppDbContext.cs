using Microsoft.EntityFrameworkCore;

namespace Arch_lab.Models.DAL
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            /*pass 03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4
             login ainur*/
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<PublicKey> PublicKey { get; set; }
        public DbSet<PrivateKey> PrivateKey { get; set; }
        public DbSet<Certificate> Certificate { get; set; }
    }
}
