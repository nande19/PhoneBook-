using Microsoft.EntityFrameworkCore;
using PhoneBook_Application.Models.Entities;

namespace PhoneBook_Application.PhoneData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        //People table named People
    public DbSet<People> Peoples { get; set; }
    }
}
