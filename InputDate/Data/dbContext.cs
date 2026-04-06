using InputDate.Pages;
using Microsoft.EntityFrameworkCore;

namespace InputDate.Data
{
    public class dbContext : DbContext
    {
        public DbSet<Human> Humans { get; set; }
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }
    }
}