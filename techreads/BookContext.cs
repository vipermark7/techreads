using Microsoft.EntityFrameworkCore;
using techreads.Models;

namespace techreads
{
    public class BookContext : DbContext
    {
        private readonly string 
            USERNAME,
            PASSWORD,
            DB,
            PORT,
            HOST; 
        private IConfiguration Configuration;
        public DbSet<Book> Books { get; set; } = default!;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BookContext()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, IConfiguration config)
        {
            Configuration = config;
            optionsBuilder.UseNpgsql(
                $"Host={config["Host"]};" +
                $"User={config["UserName"]}" +
                $";Password={config("Password")};" +
                $"Database={config["Database"]};" +
                $"PORT={config["Port"]}"
            );
        }
    }
}
