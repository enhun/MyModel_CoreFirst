using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

namespace MyModel_CoreFirst.Models
{
    public class MyModelContext : DbContext
    {

        public MyModelContext(DbContextOptions<MyModelContext> options)
      : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=IMCSD-27;Initial Catalog=MyModelDB;User ID=abcd;Password=123");
        //}

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<ReBook> ReBooks { get; set; } = null!;
    }
}