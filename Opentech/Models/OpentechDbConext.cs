using System.Data.Entity;

namespace Opentech.Models
{
    public class OpentechDbContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
    }
}