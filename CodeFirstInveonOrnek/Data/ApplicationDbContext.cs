using CodeFirstInveonOrnek.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstInveonOrnek.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Kitap> Kitaplar {get; set;}
    }
}
