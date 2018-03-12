namespace AppChambitasV1.Backend.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppChambitasV1.Backend.Models.DataContextLocal>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //Para que te genere esta clase tienes que poner:
            //Enable-Migrations -ContextTypeName DataContextLocal -EnableAutomaticMigrations -Force

            //Se agrega este otro parametro
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "AppChambitasV1.Backend.Models.DataContextLocal";
        }

        protected override void Seed(AppChambitasV1.Backend.Models.DataContextLocal context)
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
        }
    }
}
