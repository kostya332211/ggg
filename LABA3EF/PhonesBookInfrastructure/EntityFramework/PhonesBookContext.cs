using System.Data.Entity;
using PhonesBook.Core.Entities;

namespace PhonesBookInfrastructure.EntityFramework
{
    class PhonesBookContext : DbContext
    {
        private const string Connection =
            "Data Source=(local);Initial Catalog=DBPhonesBook;Integrated Security=True";

        public DbSet<Person> Persons { get; set; }

        public PhonesBookContext() : base(Connection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
