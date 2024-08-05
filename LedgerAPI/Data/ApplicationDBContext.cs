using LedgerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LedgerAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
