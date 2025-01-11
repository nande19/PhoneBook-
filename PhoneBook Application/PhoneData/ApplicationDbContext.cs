using Microsoft.EntityFrameworkCore;
using PhoneBook_Application.Models.Entities;

namespace PhoneBook_Application.PhoneData
{

    //--------------------------------------------------------------------------------------------------------//

    /// <summary>
    /// manages the database interactions using Entity Framework Core.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        //People table named People
    public DbSet<People> Peoples { get; set; }
    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
