

using ContactWebApi.DataModal;
using Microsoft.EntityFrameworkCore;

namespace ContactWebApi.DatabaseContext
{
    public class ContactDatabaseContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ContactDb");
                       
        }

        public DbSet<ContactDataModal> Contacts { get; set; }
    }
}
