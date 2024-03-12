using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data
{
    public class AppDbcontext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
           
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
