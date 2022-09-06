using Microsoft.EntityFrameworkCore;
using WebApiEntregas.Models;

namespace WebApiEntregas.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Delivery> Deliveries { get; set; }
        public object Delivery { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}
