using Solyanka.Domain.Persistance;

namespace Solyanka.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Solyanka.Domain.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Solyanka.Domain.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(
                p => p.Name,
                new User() { Id = Guid.NewGuid(), Name = "User1", Email = "User1@mail.com", Password = "123", EmailConfirmed = false, ConfirmString = Guid.NewGuid().ToString() },
                new User() { Id = Guid.NewGuid(), Name = "User2", Email = "User2@mail.com", Password = "123", EmailConfirmed = false, ConfirmString = Guid.NewGuid().ToString() },
                new User() { Id = Guid.NewGuid(), Name = "User3", Email = "User3@mail.com", Password = "123", EmailConfirmed = false, ConfirmString = Guid.NewGuid().ToString() }
            );
        }
    }
}
