using BakePopup.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakePopup.Data
{

    public class BakePopupContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;User Id=sa;Password=Localonly123!;TrustServerCertificate=True;");
            }
        }
    }
}