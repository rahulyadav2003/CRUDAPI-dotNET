using CRUDAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> StudentDb { get; set; }
    }

}
