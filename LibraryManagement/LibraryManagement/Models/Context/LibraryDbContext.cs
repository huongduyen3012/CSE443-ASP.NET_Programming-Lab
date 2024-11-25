using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models.Context
{
    public class LibraryDbContext : IdentityDbContext<IdentityUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Loans> Loans { get; set; }

        public DbSet<Books> Books { get; set; }

        public DbSet<Authors> Authors { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Carousel> Carousels { get; set; }
    }
}
