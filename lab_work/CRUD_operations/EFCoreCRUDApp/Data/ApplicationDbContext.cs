using Microsoft.EntityFrameworkCore;
using EFCoreCRUDApp.Models;

namespace EFCoreCRUDApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}