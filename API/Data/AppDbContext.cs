using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Cat> Cats { get; set; }

        // configuro o relacionamento um pra muitos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Phones)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>().HasData(
                new User(Guid.NewGuid(), "Mat", "admin", "admin", "123.123.123-45", "01/01/1900")
            );

            modelBuilder.Entity<Cat>().HasData(
                new Cat { id = 1, author = "Ashley", title = "Fifi", date = "2024-03-20 21:16:20", src = "https://i.pinimg.com/564x/e7/54/cc/e754cc4c1e43e85ae059d640ac3a4d81.jpg", peso = "5", idade = "2", acessos = "209293", total_comments = "2" },
                new Cat { id = 2, author = "Mat", title = "Mingau", date = "2024-04-10 21:16:20", src = "https://i.pinimg.com/564x/6c/93/e6/6c93e605661e7d105bd6ad473ccfaa45.jpg", peso = "6", idade = "6", acessos = "123345", total_comments = "1" },
                new Cat { id = 3, author = "João", title = "Bolinho", date = "2024-02-02 21:16:20", src = "https://i.pinimg.com/564x/01/e6/09/01e6097603ceb0a1c3b16af1a8f56f39.jpg", peso = "3", idade = "3", acessos = "13215", total_comments = "1" },
                new Cat { id = 4, author = "Ana", title = "Nico", date = "2024-01-12 21:16:20", src = "https://i.pinimg.com/564x/01/88/b4/0188b44239015be9f8efe7e81aa3d40a.jpg", peso = "2", idade = "8", acessos = "56746", total_comments = "0" },
                new Cat { id = 5, author = "Ricardo", title = "Maggie", date = "2024-03-21 21:16:20", src = "https://i.pinimg.com/564x/ef/10/c2/ef10c2acca595eae0b0f67430580c3a1.jpg", peso = "4", idade = "1", acessos = "76", total_comments = "0" },
                new Cat { id = 6, author = "Mat", title = "Tom", date = "2024-04-14 21:16:20", src = "https://i.pinimg.com/564x/92/73/c6/9273c692dd46fbb5b3d9b5018e09ee61.jpg", peso = "4", idade = "9", acessos = "365753", total_comments = "0" }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=projetct.sqlite;Cache=Shared");
    }
}

