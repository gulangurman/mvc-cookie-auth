using Microsoft.EntityFrameworkCore;

namespace mvc_cookie_auth.Models
{
    public class AuthContext : DbContext
    {
        public AuthContext()
        {

        }
        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Account>(e =>
            {
                e.ToTable("account"); //important for MySql
                e.HasKey(e => e.Id);
                e.Property(e => e.Email).IsRequired();
                e.Property(e => e.Password).IsRequired();
            });

            builder.Seed();
        }
    }
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
           {
               entity.HasData(new Account { Id = 1, Username = "admin", Password = "xyz!*!", Email = "example@example.com", Name = "Yönetici", Surname = "" });
           });
        }
    }

}