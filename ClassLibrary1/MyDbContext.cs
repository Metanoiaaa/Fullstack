using Microsoft.EntityFrameworkCore;


namespace DataLaag
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Ingredient> Ingredients { get; set; }
    }

}
