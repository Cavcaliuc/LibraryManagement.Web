namespace LibraryManagement.Web.Migrations
{
    using LibraryManagement.Web.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryManagement.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibraryManagement.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var actionType1 = new ActionType { Id = 1, Name = "Sell" };
            var actionType2 = new ActionType { Id = 2, Name = "Borrow" };
            var actionType3 = new ActionType { Id = 3, Name = "Donate" };

            context.ActionTypes.AddOrUpdate(actionType1);
            context.ActionTypes.AddOrUpdate(actionType2);
            context.ActionTypes.AddOrUpdate(actionType3);


            var country1 = new Country { Id = 1, Name = "Moldova" };
            context.Contries.AddOrUpdate(country1);

            //cities
            var municipiulChișinău = new Location { Id = 2, Country = country1, Name = "Chișinău" };
            context.Locations.AddOrUpdate(municipiulChișinău);

            var municipiulBălți = new Location { Id = 3, Country = country1, Name = "Bălți" };
            context.Locations.AddOrUpdate(municipiulBălți);

            var municipiulBenderTighina = new Location { Id = 4, Country = country1, Name = "Bender" };
            context.Locations.AddOrUpdate(municipiulBenderTighina);

            var AneniiNoi = new Location { Id = 5, Country = country1, Name = "Anenii Noi" };
            context.Locations.AddOrUpdate(AneniiNoi);

            var Basarabeasca = new Location { Id = 6, Country = country1, Name = "Basarabeasca" };
            context.Locations.AddOrUpdate(Basarabeasca);

            var Briceni = new Location { Id = 7, Country = country1, Name = "Briceni" };
            context.Locations.AddOrUpdate(Briceni);

            var Cahul = new Location { Id = 8, Country = country1, Name = "Cahul" };
            context.Locations.AddOrUpdate(Cahul);

            var Camenca = new Location { Id = 9, Country = country1, Name = "Camenca" };
            context.Locations.AddOrUpdate(Camenca);

            var Călărași = new Location { Id = 10, Country = country1, Name = "Călărași" };
            context.Locations.AddOrUpdate(Călărași);

            //villages
            var municipiulChișină = new Location { Id = 11, Country = country1, Name = "Bacioi", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(municipiulChișină);



        }
    }
}
