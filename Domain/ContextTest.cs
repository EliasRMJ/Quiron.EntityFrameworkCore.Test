using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;

namespace Quiron.EntityFrameworkCore.Test.Domain
{
    public class ContextTest(DbContextOptions<ContextTest> options)
        : PersistenceContext(options)
    {
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EmailPerson> EmailPersons { get; set; }
        public DbSet<PhysicsPerson> PhysicsPersons { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Classification>(cla => cla.Property(cla => cla.Active)
                .HasConversion(cla => (int)cla, cla => (ActiveEnum)cla));

            modelBuilder.Entity<Person>(pess => pess.Property(pess => pess.PersonType)
                .HasConversion(pess => (int)pess, pess => (PersonTypeEnum)pess));

            base.OnModelCreating(modelBuilder);
        }
    }
}