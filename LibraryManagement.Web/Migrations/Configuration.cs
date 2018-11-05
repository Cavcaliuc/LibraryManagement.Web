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
            #region ActionTypes
            var actionType1 = new ActionType { Id = 1, Name = "Sell" };
            var actionType2 = new ActionType { Id = 2, Name = "Borrow" };
            var actionType3 = new ActionType { Id = 3, Name = "Donate" };

            context.ActionTypes.AddOrUpdate(actionType1);
            context.ActionTypes.AddOrUpdate(actionType2);
            context.ActionTypes.AddOrUpdate(actionType3);
            #endregion ActionTypes

            var moldova = new Country { Id = 1, Name = "Moldova" };
            context.Countries.AddOrUpdate(moldova);

            #region Cities
            //cities
            var municipiulChișinău = new Location { Id = 2, Country = moldova, Name = "Chișinău" };
            context.Locations.AddOrUpdate(municipiulChișinău);

            var municipiulBălți = new Location { Id = 3, Country = moldova, Name = "Bălți" };
            context.Locations.AddOrUpdate(municipiulBălți);

            var municipiulBenderTighina = new Location { Id = 4, Country = moldova, Name = "Bender" };
            context.Locations.AddOrUpdate(municipiulBenderTighina);

            var AneniiNoi = new Location { Id = 5, Country = moldova, Name = "Anenii Noi" };
            context.Locations.AddOrUpdate(AneniiNoi);

            var Basarabeasca = new Location { Id = 6, Country = moldova, Name = "Basarabeasca" };
            context.Locations.AddOrUpdate(Basarabeasca);

            var Briceni = new Location { Id = 7, Country = moldova, Name = "Briceni" };
            context.Locations.AddOrUpdate(Briceni);

            var Cahul = new Location { Id = 8, Country = moldova, Name = "Cahul" };
            context.Locations.AddOrUpdate(Cahul);

            var Camenca = new Location { Id = 9, Country = moldova, Name = "Camenca" };
            context.Locations.AddOrUpdate(Camenca);

            var Călărași = new Location { Id = 10, Country = moldova, Name = "Călărași" };
            context.Locations.AddOrUpdate(Călărași);

            var Cantemir = new Location { Id = 11, Country = moldova, Name = "Cantemir" };
            context.Locations.AddOrUpdate(Cantemir);

            var Căușeni = new Location { Id = 12, Country = moldova, Name = "Căușeni" };
            context.Locations.AddOrUpdate(Căușeni);

            var Cimișlia = new Location { Id = 13, Country = moldova, Name = "Cimișlia" };
            context.Locations.AddOrUpdate(Cimișlia);

            var Criuleni = new Location { Id = 14, Country = moldova, Name = "Criuleni" };
            context.Locations.AddOrUpdate(Criuleni);

            var Dondușeni = new Location { Id = 15, Country = moldova, Name = "Dondușeni" };
            context.Locations.AddOrUpdate(Dondușeni);

            var Drochia = new Location { Id = 16, Country = moldova, Name = "Drochia" };
            context.Locations.AddOrUpdate(Drochia);

            var Dubăsari = new Location { Id = 17, Country = moldova, Name = "Dubăsari" };
            context.Locations.AddOrUpdate(Dubăsari);

            var Edineț = new Location { Id = 18, Country = moldova, Name = "Edineț" };
            context.Locations.AddOrUpdate(Edineț);

            var Fălești = new Location { Id = 19, Country = moldova, Name = "Fălești" };
            context.Locations.AddOrUpdate(Fălești);

            var Florești = new Location { Id = 20, Country = moldova, Name = "Florești" };
            context.Locations.AddOrUpdate(Florești);

            var Glodeni = new Location { Id = 21, Country = moldova, Name = "Glodeni" };
            context.Locations.AddOrUpdate(Glodeni);

            var Hîncești = new Location { Id = 22, Country = moldova, Name = "Hîncești" };
            context.Locations.AddOrUpdate(Hîncești);

            var Ialoveni = new Location { Id = 23, Country = moldova, Name = "Ialoveni" };
            context.Locations.AddOrUpdate(Ialoveni);

            var Leova = new Location { Id = 24, Country = moldova, Name = "Leova" };
            context.Locations.AddOrUpdate(Leova);

            var Nisporeni = new Location { Id = 25, Country = moldova, Name = "Nisporeni" };
            context.Locations.AddOrUpdate(Nisporeni);

            var Ocnița = new Location { Id = 26, Country = moldova, Name = "Ocnița" };
            context.Locations.AddOrUpdate(Ocnița);

            var Orhei = new Location { Id = 27, Country = moldova, Name = "Orhei" };
            context.Locations.AddOrUpdate(Orhei);

            var Rezina = new Location { Id = 28, Country = moldova, Name = "Rezina" };
            context.Locations.AddOrUpdate(Rezina);

            var Rîșcani = new Location { Id = 29, Country = moldova, Name = "Rîșcani" };
            context.Locations.AddOrUpdate(Rîșcani);

            var Sîngerei = new Location { Id = 30, Country = moldova, Name = "Sîngerei" };
            context.Locations.AddOrUpdate(Sîngerei);

            var Soroca = new Location { Id = 31, Country = moldova, Name = "Soroca" };
            context.Locations.AddOrUpdate(Soroca);

            var Strășeni = new Location { Id = 32, Country = moldova, Name = "Strășeni" };
            context.Locations.AddOrUpdate(Strășeni);

            var Șoldănești = new Location { Id = 33, Country = moldova, Name = "Șoldănești" };
            context.Locations.AddOrUpdate(Șoldănești);

            var ȘtefanVodă = new Location { Id = 34, Country = moldova, Name = "ȘtefanVodă" };
            context.Locations.AddOrUpdate(ȘtefanVodă);

            var Taraclia = new Location { Id = 35, Country = moldova, Name = "Taraclia" };
            context.Locations.AddOrUpdate(Taraclia);

            var Telenești = new Location { Id = 36, Country = moldova, Name = "Telenești" };
            context.Locations.AddOrUpdate(Telenești);

            var Ungheni = new Location { Id = 37, Country = moldova, Name = "Ungheni" };
            context.Locations.AddOrUpdate(Ungheni);

            var UnitateaTeritorialăAutonomăGăgăuzia = new Location { Id = 38, Country = moldova, Name = "UnitateaTeritorialăAutonomăGăgăuzia" };
            context.Locations.AddOrUpdate(UnitateaTeritorialăAutonomăGăgăuzia);

            var UnitățileAdministrativTeritorialedinStîngaNistrului = new Location { Id = 39, Country = moldova, Name = "UnitățileAdministrativTeritorialedinStîngaNistrului" };
            context.Locations.AddOrUpdate(UnitățileAdministrativTeritorialedinStîngaNistrului);

            #endregion Cities

            //villages
            var Bacioi = new Location { Id = 40, Country = moldova, Name = "Bacioi", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Bacioi);


            var Bîc = new Location { Id = 41, Country = moldova, Name = "Bîc", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Bîc);

            var Brăila = new Location { Id = 42, Country = moldova, Name = "Brăila", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Brăila);

            var Bubuieci = new Location { Id = 43, Country = moldova, Name = "Bubuieci", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Bubuieci);

            var Budești = new Location { Id = 44, Country = moldova, Name = "Budești", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Budești);

            var Buneți = new Location { Id = 45, Country = moldova, Name = "Buneți", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Buneți);

            var Ceroborta = new Location { Id = 46, Country = moldova, Name = "Ceroborta", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Ceroborta);

            var Cheltuitori = new Location { Id = 46, Country = moldova, Name = "Cheltuitori", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Cheltuitori);

            var Ciorescu = new Location { Id = 47, Country = moldova, Name = "Ciorescu", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Ciorescu);

            var Codru = new Location { Id = 48, Country = moldova, Name = "Codru", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Codru);

            var Colonița = new Location { Id = 49, Country = moldova, Name = "Colonița", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Colonița);

            var Condrița = new Location { Id = 50, Country = moldova, Name = "Condrița", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Condrița);

            var Cricova = new Location { Id = 51, Country = moldova, Name = "Cricova", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Cricova);

            var Cruzești = new Location { Id = 52, Country = moldova, Name = "Cruzești", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Cruzești);

            var Dobrogea = new Location { Id = 53, Country = moldova, Name = "Dobrogea", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Dobrogea);

            var Dumbrava = new Location { Id = 54, Country = moldova, Name = "Dumbrava", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Dumbrava);

            var Durlești = new Location { Id = 55, Country = moldova, Name = "Durlești", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Durlești);

            var Făurești = new Location { Id = 56, Country = moldova, Name = "Făurești", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Făurești);

            var Frumușica = new Location { Id = 57, Country = moldova, Name = "Frumușica", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Frumușica);

            var Ghidighici = new Location { Id = 58, Country = moldova, Name = "Ghidighici", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Ghidighici);

            var Goian = new Location { Id = 59, Country = moldova, Name = "Goian", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Goian);

            var GoianulNou = new Location { Id = 60, Country = moldova, Name = "GoianulNou", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(GoianulNou);

            var Grătiești = new Location { Id = 61, Country = moldova, Name = "Grătiești", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Grătiești);

            var Hulboaca = new Location { Id = 62, Country = moldova, Name = "Hulboaca", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Hulboaca);

            var Humulești = new Location { Id = 63, Country = moldova, Name = "Humulești", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Humulești);

            var Revaca = new Location { Id = 64, Country = moldova, Name = "Revaca", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Revaca);

            var Stăuceni = new Location { Id = 65, Country = moldova, Name = "Stăuceni", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Stăuceni);

            var Străisteni = new Location { Id = 66, Country = moldova, Name = "Străisteni", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Străisteni);

            var Sîngera = new Location { Id = 67, Country = moldova, Name = "Sîngera", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Sîngera);

            var Tohatin = new Location { Id = 68, Country = moldova, Name = "Tohatin", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Tohatin);

            var Trușeni = new Location { Id = 69, Country = moldova, Name = "Trușeni", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Trușeni);

            var VadulluiVodă = new Location { Id = 70, Country = moldova, Name = "VadulluiVodă", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(VadulluiVodă);

            var Vatra = new Location { Id = 71, Country = moldova, Name = "Vatra", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Vatra);

            var Văduleni = new Location { Id = 72, Country = moldova, Name = "Văduleni", ParentLocation = municipiulChișinău };
            context.Locations.AddOrUpdate(Văduleni);

            var Elizaveta = new Location { Id = 73, Country = moldova, Name = "Elizaveta", ParentLocation = municipiulBălți };
            context.Locations.AddOrUpdate(Elizaveta);

            var Sadovoe = new Location { Id = 74, Country = moldova, Name = "Sadovoe", ParentLocation = municipiulBălți };
            context.Locations.AddOrUpdate(Sadovoe);

            var Proteagailovca = new Location { Id = 75, Country = moldova, Name = "Proteagailovca", ParentLocation = municipiulBenderTighina };
            context.Locations.AddOrUpdate(Proteagailovca);

            var Albinița = new Location { Id = 76, Country = moldova, Name = "Albinița", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Albinița);

            var Balmaz = new Location { Id = 77, Country = moldova, Name = "Balmaz", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Balmaz);

            var Batîc = new Location { Id = 78, Country = moldova, Name = "Batîc", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Batîc);

            var Beriozchi = new Location { Id = 79, Country = moldova, Name = "Beriozchi", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Beriozchi);

            var Botnărești = new Location { Id = 80, Country = moldova, Name = "Botnărești", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Botnărești);

            var BotnăreștiiNoi = new Location { Id = 81, Country = moldova, Name = "BotnăreștiiNoi", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(BotnăreștiiNoi);

            var Bulboaca = new Location { Id = 82, Country = moldova, Name = "Bulboaca", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Bulboaca);

            var Calfa = new Location { Id = 83, Country = moldova, Name = "Calfa", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Calfa);

            var CalfaNouă = new Location { Id = 84, Country = moldova, Name = "CalfaNouă", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(CalfaNouă);

            var Chetrosu = new Location { Id = 85, Country = moldova, Name = "Chetrosu", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Chetrosu);

            var Chirca = new Location { Id = 86, Country = moldova, Name = "Chirca", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Chirca);

            var Ciobanovca = new Location { Id = 87, Country = moldova, Name = "Ciobanovca", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Ciobanovca);

            var CobuscaNouă = new Location { Id = 88, Country = moldova, Name = "CobuscaNouă", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(CobuscaNouă);

            var CobuscaVeche = new Location { Id = 89, Country = moldova, Name = "CobuscaVeche", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(CobuscaVeche);

            var Crețoaia = new Location { Id = 90, Country = moldova, Name = "Crețoaia", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Crețoaia);

            var Delacău = new Location { Id = 90, Country = moldova, Name = "Delacău", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Delacău);

            var Floreni = new Location { Id = 91, Country = moldova, Name = "Floreni", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Floreni);

            var Geamăna = new Location { Id = 92, Country = moldova, Name = "Geamăna", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Geamăna);

            var GuraBîcului = new Location { Id = 93, Country = moldova, Name = "GuraBîcului", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(GuraBîcului);

            var Hîrbovăț = new Location { Id = 94, Country = moldova, Name = "Hîrbovăț", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Hîrbovăț);

            var HîrbovățulNou = new Location { Id = 95, Country = moldova, Name = "HîrbovățulNou", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(HîrbovățulNou);

            var Larga = new Location { Id = 96, Country = moldova, Name = "Larga", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Larga);

            var Maximovca = new Location { Id = 97, Country = moldova, Name = "Maximovca", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Maximovca);

            var Mereni = new Location { Id = 98, Country = moldova, Name = "Mereni", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Mereni);

            var MereniiNoi = new Location { Id = 99, Country = moldova, Name = "MereniiNoi", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(MereniiNoi);

            var Mirnoe = new Location { Id = 100, Country = moldova, Name = "Mirnoe", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Mirnoe);

            var Nicolaevca = new Location { Id = 101, Country = moldova, Name = "Nicolaevca", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Nicolaevca);

            var OchiulRoș = new Location { Id = 102, Country = moldova, Name = "OchiulRoș", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(OchiulRoș);

            var Picus = new Location { Id = 103, Country = moldova, Name = "Picus", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Picus);

            var Puhăceni = new Location { Id = 104, Country = moldova, Name = "Puhăceni", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Puhăceni);

            var Roșcani = new Location { Id = 105, Country = moldova, Name = "Roșcani", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Roșcani);

            var Ruseni = new Location { Id = 106, Country = moldova, Name = "Ruseni", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Ruseni);

            var Salcia = new Location { Id = 107, Country = moldova, Name = "Salcia", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Salcia);

            var Socoleni = new Location { Id = 108, Country = moldova, Name = "Socoleni", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Socoleni);

            var Speia = new Location { Id = 109, Country = moldova, Name = "Speia", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Speia);

            var Șerpeni = new Location { Id = 110, Country = moldova, Name = "Șerpeni", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Șerpeni);

            var Telița = new Location { Id = 111, Country = moldova, Name = "Telița", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Telița);

            var TelițaNouă = new Location { Id = 112, Country = moldova, Name = "TelițaNouă", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(TelițaNouă);

            var Todirești = new Location { Id = 113, Country = moldova, Name = "Todirești", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Todirești);

            var TroițaNouă = new Location { Id = 114, Country = moldova, Name = "TroițaNouă", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(TroițaNouă);

            var Țînțăreni = new Location { Id = 115, Country = moldova, Name = "Țînțăreni", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Țînțăreni);

            var Varnița = new Location { Id = 116, Country = moldova, Name = "Varnița", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Varnița);

            var Zolotievca = new Location { Id = 117, Country = moldova, Name = "Zolotievca", ParentLocation = AneniiNoi };
            context.Locations.AddOrUpdate(Zolotievca);

            var Abaclia = new Location { Id = 118, Country = moldova, Name = "Abaclia", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Abaclia);

            var Bașcalia = new Location { Id = 119, Country = moldova, Name = "Bașcalia", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Bașcalia);

            var Bogdanovca = new Location { Id = 120, Country = moldova, Name = "Bogdanovca", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Bogdanovca);

            var Carabetovca = new Location { Id = 121, Country = moldova, Name = "Carabetovca", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Carabetovca);

            var Carabiber = new Location { Id = 122, Country = moldova, Name = "Carabiber", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Carabiber);

            var Iordanovca = new Location { Id = 123, Country = moldova, Name = "Iordanovca", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Iordanovca);

            var Iserlia = new Location { Id = 124, Country = moldova, Name = "Iserlia", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Iserlia);

            var Ivanovca = new Location { Id = 125, Country = moldova, Name = "Ivanovca	", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Ivanovca);

            var Sadaclia = new Location { Id = 126, Country = moldova, Name = "Sadaclia", ParentLocation = Basarabeasca };
            context.Locations.AddOrUpdate(Sadaclia);

            var Balasinești = new Location { Id = 127, Country = moldova, Name = "Balasinești", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Balasinești);

            var Bălcăuți = new Location { Id = 128, Country = moldova, Name = "Bălcăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Bălcăuți);

            var Beleavinți = new Location { Id = 129, Country = moldova, Name = "Beleavinți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Beleavinți);

            var Berlinți = new Location { Id = 130, Country = moldova, Name = "Berlinți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Berlinți);

            var Bezeda = new Location { Id = 131, Country = moldova, Name = "Bezeda", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Bezeda);

            var Bocicăuți = new Location { Id = 132, Country = moldova, Name = "Bocicăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Bocicăuți);

            var Bogdănești = new Location { Id = 133, Country = moldova, Name = "Bogdănești", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Bogdănești);

            var BulboacaB = new Location { Id = 134, Country = moldova, Name = "Bulboaca", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Bulboaca);

            var CaracușeniiVechi = new Location { Id = 135, Country = moldova, Name = "Caracușeni iVechi", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(CaracușeniiVechi);

            var CaracușeniiNoi = new Location { Id = 136, Country = moldova, Name = "Caracușenii Noi", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(CaracușeniiNoi);

            var Chirilovca = new Location { Id = 137, Country = moldova, Name = "Chirilovca", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Chirilovca);

            var Colicăuți = new Location { Id = 138, Country = moldova, Name = "Colicăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Colicăuți);

            var Corjeuți = new Location { Id = 139, Country = moldova, Name = "Corjeuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Corjeuți);

            var Coteala = new Location { Id = 140, Country = moldova, Name = "Coteala", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Coteala);

            var Cotiujeni = new Location { Id = 141, Country = moldova, Name = "Cotiujeni", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Cotiujeni);

            var Criva = new Location { Id = 142, Country = moldova, Name = "Criva", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Criva);

            var Drepcăuți = new Location { Id = 143, Country = moldova, Name = "Drepcăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Drepcăuți);

            var Grimești = new Location { Id = 144, Country = moldova, Name = "Grimești", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Grimești);

            var Grimăncăuți = new Location { Id = 145, Country = moldova, Name = "Grimăncăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Grimăncăuți);

            var Groznița = new Location { Id = 146, Country = moldova, Name = "Groznița", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Groznița);

            var HalahoradeJos = new Location { Id = 147, Country = moldova, Name = "Halahora de Jos", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(HalahoradeJos);

            var HalahoradeSus = new Location { Id = 148, Country = moldova, Name = "Halahora de Sus", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(HalahoradeSus);

            var Hlina = new Location { Id = 149, Country = moldova, Name = "Hlina", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Hlina);

            var LargaB = new Location { Id = 150, Country = moldova, Name = "Larga", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Larga);

            var Lipcani = new Location { Id = 151, Country = moldova, Name = "Lipcani", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Lipcani);

            var Mărcăuți = new Location { Id = 152, Country = moldova, Name = "Mărcăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Mărcăuți);

            var MărcăuțiiNoi = new Location { Id = 153, Country = moldova, Name = "Mărcăuții Noi", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(MărcăuțiiNoi);

            var Medveja = new Location { Id = 154, Country = moldova, Name = "Medveja", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Medveja);

            var Mihăileni = new Location { Id = 155, Country = moldova, Name = "Mihăileni", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Mihăileni);

            var Pavlovca = new Location { Id = 156, Country = moldova, Name = "Pavlovca", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Pavlovca);

            var Pererîta = new Location { Id = 157, Country = moldova, Name = "Pererîta", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Pererîta);

            var SloboziaMedveja = new Location { Id = 158, Country = moldova, Name = "Slobozia-Medveja", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(SloboziaMedveja);

            var SloboziaȘirăuți = new Location { Id = 159, Country = moldova, Name = "Slobozia-Șirăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(SloboziaȘirăuți);

            var Șirăuți = new Location { Id = 160, Country = moldova, Name = "Șirăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Șirăuți);

            var Tabani = new Location { Id = 161, Country = moldova, Name = "Tabani", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Tabani);

            var Tețcani = new Location { Id = 162, Country = moldova, Name = "Tețcani", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Tețcani);

            var Trebisăuți = new Location { Id = 163, Country = moldova, Name = "Trebisăuți", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Trebisăuți);

            var Trestieni = new Location { Id = 164, Country = moldova, Name = "Trestieni", ParentLocation = Briceni };
            context.Locations.AddOrUpdate(Trestieni);

            var AlexandruIoanCuza = new Location { Id = 164, Country = moldova, Name = "Alexandru Ioan Cuza", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(AlexandruIoanCuza);

            var Alexanderfeld = new Location { Id = 165, Country = moldova, Name = "Alexanderfeld", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Alexanderfeld);

            var AndrușuldeJos = new Location { Id = 166, Country = moldova, Name = "Andrușul de Jos", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(AndrușuldeJos);

            var AndrușuldeSus = new Location { Id = 167, Country = moldova, Name = "Andrușul de Sus", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(AndrușuldeSus);

            var BadiculMoldovenesc = new Location { Id = 168, Country = moldova, Name = "Badicul Moldovenesc", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(BadiculMoldovenesc);

            var BaurciMoldoveni = new Location { Id = 169, Country = moldova, Name = "Baurci-Moldoveni", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(BaurciMoldoveni);

            var Borceag = new Location { Id = 170, Country = moldova, Name = "Borceag", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Borceag);

            var Bucuria = new Location { Id = 171, Country = moldova, Name = "Bucuria", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Bucuria);

            var Burlacu = new Location { Id = 172, Country = moldova, Name = "Burlacu", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Burlacu);

            var Burlăceni = new Location { Id = 173, Country = moldova, Name = "Burlăceni", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Burlăceni);

            var Brînza = new Location { Id = 174, Country = moldova, Name = "Brînza", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Brînza);

            var ChioseliaMare = new Location { Id = 175, Country = moldova, Name = "Chioselia Mare	", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(ChioseliaMare);

            var Chircani = new Location { Id = 176, Country = moldova, Name = "Chircani", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Chircani);

            var CîșlițaPrut = new Location { Id = 177, Country = moldova, Name = "Cîșlița-Prut", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(CîșlițaPrut);

            var Colibași = new Location { Id = 178, Country = moldova, Name = "Colibași", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Colibași);

            var Cotihana = new Location { Id = 179, Country = moldova, Name = "Cotihana", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Cotihana);

            var CrihanaVeche = new Location { Id = 180, Country = moldova, Name = "Crihana Veche", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(CrihanaVeche);

            var Cucoara = new Location { Id = 181, Country = moldova, Name = "Cucoara", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Cucoara);

            var Doina = new Location { Id = 182, Country = moldova, Name = "Doina", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Doina);

            var FrumușicaC = new Location { Id = 183, Country = moldova, Name = "Frumușica", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Frumușica);

            var Găvănoasa = new Location { Id = 184, Country = moldova, Name = "Găvănoasa", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Găvănoasa);

            var Giurgiulești = new Location { Id = 185, Country = moldova, Name = "Giurgiulești", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Giurgiulești);

            var Greceni = new Location { Id = 186, Country = moldova, Name = "Greceni", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Greceni);

            var Huluboaia = new Location { Id = 187, Country = moldova, Name = "Huluboaia", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Huluboaia);

            var Hutulu = new Location { Id = 188, Country = moldova, Name = "Hutulu", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Hutulu);

            var IasnaiaPoleana = new Location { Id = 189, Country = moldova, Name = "Iasnaia Poleana", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(IasnaiaPoleana);

            var Iujnoe = new Location { Id = 190, Country = moldova, Name = "Iujnoe", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Iujnoe);

            var LargaNouă = new Location { Id = 191, Country = moldova, Name = "Larga Nouă", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(LargaNouă);

            var LargaVeche = new Location { Id = 192, Country = moldova, Name = "Larga Veche", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(LargaVeche);

            var Lebedenco = new Location { Id = 193, Country = moldova, Name = "Lebedenco", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Lebedenco);

            var Lopățica = new Location { Id = 194, Country = moldova, Name = "Lopățica", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Lopățica);

            var Lucești = new Location { Id = 195, Country = moldova, Name = "Lucești", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Lucești);

            var Manta = new Location { Id = 196, Country = moldova, Name = "Manta", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Manta);

            var Moscovei = new Location { Id = 197, Country = moldova, Name = "Moscovei", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Moscovei);

            var NicolaevcaC = new Location { Id = 198, Country = moldova, Name = "Nicolaevca", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Nicolaevca);

            var Paicu = new Location { Id = 199, Country = moldova, Name = "Paicu", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Paicu);

            var Pașcani = new Location { Id = 200, Country = moldova, Name = "Pașcani", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Pașcani);

            var Pelinei = new Location { Id = 201, Country = moldova, Name = "Pelinei", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Pelinei);

            var Roșu = new Location { Id = 202, Country = moldova, Name = "Roșu", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Roșu);

            var Rumeanțev = new Location { Id = 203, Country = moldova, Name = "Rumeanțev", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Rumeanțev);

            var Sătuc = new Location { Id = 204, Country = moldova, Name = "Sătuc", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Sătuc);

            var SloboziaMare = new Location { Id = 205, Country = moldova, Name = "Slobozia Mare", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(SloboziaMare);

            var Spicoasa = new Location { Id = 206, Country = moldova, Name = "Spicoasa", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Spicoasa);

            var TaracliadeSalcie = new Location { Id = 207, Country = moldova, Name = "Taraclia de Salcie", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(TaracliadeSalcie);

            var TartauldeSalcie = new Location { Id = 208, Country = moldova, Name = "Tartaul de Salcie", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(TartauldeSalcie);

            var Tătărești = new Location { Id = 209, Country = moldova, Name = "Tătărești", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Tătărești);

            var Tretești = new Location { Id = 210, Country = moldova, Name = "Tretești", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Tretești);

            var TrifeștiiNoi = new Location { Id = 211, Country = moldova, Name = "Trifeștii Noi", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(TrifeștiiNoi);

            var Tudorești = new Location { Id = 212, Country = moldova, Name = "Tudorești", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Tudorești);

            var Ursoaia = new Location { Id = 213, Country = moldova, Name = "Ursoaia", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Ursoaia);

            var VadulluiIsac = new Location { Id = 214, Country = moldova, Name = "Vadul lui Isac", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(VadulluiIsac);

            var Văleni = new Location { Id = 215, Country = moldova, Name = "Văleni", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Văleni);

            var Vladimirovca = new Location { Id = 216, Country = moldova, Name = "Vladimirovca", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Vladimirovca);

            var Zîrnești = new Location { Id = 217, Country = moldova, Name = "Zîrnești", ParentLocation = Cahul };
            context.Locations.AddOrUpdate(Zîrnești);

            var Caterinovca = new Location { Id = 218, Country = moldova, Name = "Caterinovca", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Caterinovca);

            var CrasnîiOcteabri = new Location { Id = 219, Country = moldova, Name = "Crasnîi Octeabri", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(CrasnîiOcteabri);

            var Cuzmin = new Location { Id = 220, Country = moldova, Name = "Cuzmin", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Cuzmin);

            var Hristovaia = new Location { Id = 221, Country = moldova, Name = "Hristovaia", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Hristovaia);

            var Hrușca = new Location { Id = 222, Country = moldova, Name = "Hrușca", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Hrușca);

            var Podoima = new Location { Id = 223, Country = moldova, Name = "Podoima", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Podoima);

            var Rașcov = new Location { Id = 224, Country = moldova, Name = "Rașcov", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Rașcov);

            var Rotari = new Location { Id = 225, Country = moldova, Name = "Rotari", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Rotari);

            var Severinovca = new Location { Id = 226, Country = moldova, Name = "Severinovca", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(Severinovca);

            var ValeaAdîncă = new Location { Id = 228, Country = moldova, Name = "Valea Adîncă", ParentLocation = Camenca };
            context.Locations.AddOrUpdate(ValeaAdîncă);

            var Bahmut = new Location { Id = 229, Country = moldova, Name = "Bahmut", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Bahmut);

            var Bahu = new Location { Id = 230, Country = moldova, Name = "Bahu", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Bahu);

            var Bravicea = new Location { Id = 231, Country = moldova, Name = "Bravicea", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Bravicea);

            var Buda = new Location { Id = 232, Country = moldova, Name = "Buda", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Buda);

            var Bularda = new Location { Id = 233, Country = moldova, Name = "Bularda", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Bularda);

            var Căbăiești = new Location { Id = 234, Country = moldova, Name = "Căbăiești", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Căbăiești);

            var Dereneu = new Location { Id = 235, Country = moldova, Name = "Dereneu", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Dereneu);

            var Duma = new Location { Id = 236, Country = moldova, Name = "Duma", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Duma);

            var Frumoasa = new Location { Id = 237, Country = moldova, Name = "Frumoasa", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Frumoasa);

            var Hirova = new Location { Id = 238, Country = moldova, Name = "Hirova", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Hirova);

            var HîrbovățC = new Location { Id = 239, Country = moldova, Name = "Hîrbovăț", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Hîrbovăț);

            var Hîrjauca = new Location { Id = 240, Country = moldova, Name = "Hîrjauca", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Hîrjauca);

            var Hoginești = new Location { Id = 241, Country = moldova, Name = "Hoginești", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Hoginești);

            var Horodiște = new Location { Id = 242, Country = moldova, Name = "Horodiște", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Horodiște);

            var Leordoaia = new Location { Id = 243, Country = moldova, Name = "Leordoaia", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Leordoaia);

            var Meleșeni = new Location { Id = 244, Country = moldova, Name = "Meleșeni", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Meleșeni);

            var Mîndra = new Location { Id = 245, Country = moldova, Name = "Mîndra", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Mîndra);

            var Nișcani = new Location { Id = 246, Country = moldova, Name = "Nișcani", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Nișcani);

            var Novaci = new Location { Id = 247, Country = moldova, Name = "Novaci", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Novaci);

            var Onișcani = new Location { Id = 248, Country = moldova, Name = "Onișcani", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Onișcani);

            var Oricova = new Location { Id = 249, Country = moldova, Name = "Oricova", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Oricova);

            var Palanca = new Location { Id = 250, Country = moldova, Name = "Palanca", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Palanca);

            var Parcani = new Location { Id = 251, Country = moldova, Name = "Parcani", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Parcani);

            var Păulești = new Location { Id = 252, Country = moldova, Name = "Păulești", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Păulești);

            var Peticeni = new Location { Id = 253, Country = moldova, Name = "Peticeni", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Peticeni);

            var Pitușca = new Location { Id = 254, Country = moldova, Name = "Pitușca", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Pitușca);

            var Pîrjolteni = new Location { Id = 255, Country = moldova, Name = "Pîrjolteni", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Pîrjolteni);

            var PodulLung = new Location { Id = 256, Country = moldova, Name = "Podul Lung", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(PodulLung);

            var Răciula = new Location { Id = 257, Country = moldova, Name = "Răciula", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Răciula);

            var Rădeni = new Location { Id = 258, Country = moldova, Name = "Rădeni", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Rădeni);

            var Sadova = new Location { Id = 259, Country = moldova, Name = "Sadova", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Sadova);

            var Săseni = new Location { Id = 260, Country = moldova, Name = "Săseni", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Săseni);

            var Schinoasa = new Location { Id = 261, Country = moldova, Name = "Schinoasa", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Schinoasa);

            var SelișteaNouă = new Location { Id = 262, Country = moldova, Name = "Seliștea Nouă", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(SelișteaNouă);

            var Sipoteni = new Location { Id = 263, Country = moldova, Name = "Sipoteni", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Sipoteni);

            var Sverida = new Location { Id = 264, Country = moldova, Name = "Sverida", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Sverida);

            var Temeleuți = new Location { Id = 265, Country = moldova, Name = "Temeleuți", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Temeleuți);

            var Tuzara = new Location { Id = 266, Country = moldova, Name = "Tuzara", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Tuzara);

            var Țibirica = new Location { Id = 267, Country = moldova, Name = "Țibirica", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Țibirica);

            var Ursari = new Location { Id = 268, Country = moldova, Name = "Ursari", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Ursari);

            var Vălcineț = new Location { Id = 269, Country = moldova, Name = "Vălcineț", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(Vălcineț);

            var VărzăreștiiNoi = new Location { Id = 270, Country = moldova, Name = "Vărzăreștii Noi", ParentLocation = Călărași };
            context.Locations.AddOrUpdate(VărzăreștiiNoi);

            var Acui = new Location { Id = 271, Country = moldova, Name = "Acui", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Acui);

            var Alexandrovca = new Location { Id = 272, Country = moldova, Name = "Alexandrovca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Alexandrovca);

            var Antonești = new Location { Id = 273, Country = moldova, Name = "Antonești", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Antonești);

            var Baimaclia = new Location { Id = 274, Country = moldova, Name = "Baimaclia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Baimaclia);

            var Bobocica = new Location { Id = 275, Country = moldova, Name = "Bobocica", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Bobocica);

            var Cania = new Location { Id = 276, Country = moldova, Name = "Cania", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Cania);

            var Capaclia = new Location { Id = 277, Country = moldova, Name = "Capaclia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Capaclia);

            var Chioselia = new Location { Id = 278, Country = moldova, Name = "Chioselia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Chioselia);

            var Ciobalaccia = new Location { Id = 279, Country = moldova, Name = "Ciobalaccia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Ciobalaccia);

            var Cîietu = new Location { Id = 280, Country = moldova, Name = "Cîietu", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Cîietu);

            var Cîrpești = new Location { Id = 281, Country = moldova, Name = "Cîrpești", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Cîrpești);

            var Cîșla = new Location { Id = 282, Country = moldova, Name = "Cîșla", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Cîșla);

            var Crăciun = new Location { Id = 283, Country = moldova, Name = "Crăciun", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Crăciun);

            var Cociulia = new Location { Id = 284, Country = moldova, Name = "Cociulia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Cociulia);

            var Constantinești = new Location { Id = 285, Country = moldova, Name = "Constantinești", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Constantinești);

            var Coștangalia = new Location { Id = 286, Country = moldova, Name = "Coștangalia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Coștangalia);

            var Dimitrova = new Location { Id = 287, Country = moldova, Name = "Dimitrova", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Dimitrova);

            var Enichioi = new Location { Id = 288, Country = moldova, Name = "Enichioi", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Enichioi);

            var Flocoasa = new Location { Id = 289, Country = moldova, Name = "Flocoasa", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Flocoasa);

            var Floricica = new Location { Id = 290, Country = moldova, Name = "Floricica", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Floricica);

            var Ghioltosu = new Location { Id = 291, Country = moldova, Name = "Ghioltosu", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Ghioltosu);

            var Gotești = new Location { Id = 292, Country = moldova, Name = "Gotești", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Gotești);

            var Haragîș = new Location { Id = 293, Country = moldova, Name = "Haragîș", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Haragîș);

            var Hănăseni = new Location { Id = 294, Country = moldova, Name = "Hănăseni", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Hănăseni);

            var Hîrtop = new Location { Id = 295, Country = moldova, Name = "Hîrtop", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Hîrtop);

            var Iepureni = new Location { Id = 296, Country = moldova, Name = "Iepureni", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Iepureni);

            var Lărguța = new Location { Id = 297, Country = moldova, Name = "Lărguța", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Lărguța);

            var Leca = new Location { Id = 298, Country = moldova, Name = "Leca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Leca);

            var Lingura = new Location { Id = 299, Country = moldova, Name = "Lingura", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Lingura);

            var Pleșeni = new Location { Id = 300, Country = moldova, Name = "Pleșeni", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Pleșeni);

            var Plopi = new Location { Id = 301, Country = moldova, Name = "Plopi", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Plopi);

            var Popovca = new Location { Id = 302, Country = moldova, Name = "Popovca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Popovca);

            var Porumbești = new Location { Id = 303, Country = moldova, Name = "Porumbești", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Porumbești);

            var Sadîc = new Location { Id = 304, Country = moldova, Name = "Sadîc", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Sadîc);

            var Stoianovca = new Location { Id = 305, Country = moldova, Name = "Stoianovca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Stoianovca);

            var Suhat = new Location { Id = 306, Country = moldova, Name = "Suhat", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Suhat);

            var Șamalia = new Location { Id = 307, Country = moldova, Name = "Șamalia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Șamalia);

            var Șofranovca = new Location { Id = 308, Country = moldova, Name = "Șofranovca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Șofranovca);

            var TaracliaP = new Location { Id = 309, Country = moldova, Name = "Taraclia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Taraclia);

            var TaracliaS = new Location { Id = 310, Country = moldova, Name = "Taraclia", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Taraclia);

            var Tartaul = new Location { Id = 311, Country = moldova, Name = "Tartaul", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Tartaul);

            var Tătărășeni = new Location { Id = 312, Country = moldova, Name = "Tătărășeni", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Tătărășeni);

            var Toceni = new Location { Id = 313, Country = moldova, Name = "Toceni", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Toceni);

            var Țărăncuța = new Location { Id = 314, Country = moldova, Name = "Țărăncuța", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Țărăncuța);

            var Țiganca = new Location { Id = 315, Country = moldova, Name = "Țiganca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Țiganca);

            var ȚigancaNouă = new Location { Id = 316, Country = moldova, Name = "Țiganca Nouă", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(ȚigancaNouă);

            var Țolica = new Location { Id = 317, Country = moldova, Name = "Țolica", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Țolica);

            var Victorovca = new Location { Id = 318, Country = moldova, Name = "Victorovca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Victorovca);

            var Vișniovca = new Location { Id = 319, Country = moldova, Name = "Vișniovca", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Vișniovca);

            var Vîlcele = new Location { Id = 320, Country = moldova, Name = "Vîlcele", ParentLocation = Cantemir };
            context.Locations.AddOrUpdate(Vîlcele);

            var Baccealia = new Location { Id = 321, Country = moldova, Name = "Baccealia", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Baccealia);

            var Baurci = new Location { Id = 322, Country = moldova, Name = "Baurci", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Baurci);

            var Căinari = new Location { Id = 323, Country = moldova, Name = "Căinari", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Căinari);

            var Chircăiești = new Location { Id = 324, Country = moldova, Name = "Chircăiești", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Chircăiești);

            var ChircăieștiiNoi = new Location { Id = 325, Country = moldova, Name = "Chircăieștii Noi", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(ChircăieștiiNoi);

            var Chițcani = new Location { Id = 326, Country = moldova, Name = "Chițcani", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Chițcani);

            var Ciuflești = new Location { Id = 327, Country = moldova, Name = "Ciuflești", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Ciuflești);

            var Cîrnățeni = new Location { Id = 328, Country = moldova, Name = "Cîrnățeni", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Cîrnățeni);

            var CîrnățeniiNoi = new Location { Id = 329, Country = moldova, Name = "Cîrnățenii Noi", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(CîrnățeniiNoi);

            var Constantinovca = new Location { Id = 330, Country = moldova, Name = "Constantinovca", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Constantinovca);

            var Copanca = new Location { Id = 331, Country = moldova, Name = "Copanca", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Copanca);

            var Coșcalia = new Location { Id = 332, Country = moldova, Name = "Coșcalia", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Coșcalia);

            var Cremenciug = new Location { Id = 333, Country = moldova, Name = "Cremenciug", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Cremenciug);

            var Fîrlădeni = new Location { Id = 334, Country = moldova, Name = "Fîrlădeni", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Fîrlădeni);

            var FîrlădeniiNoi = new Location { Id = 335, Country = moldova, Name = "Fîrlădenii Noi", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(FîrlădeniiNoi);

            var Florica = new Location { Id = 336, Country = moldova, Name = "Florica", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Florica);

            var Gîsca = new Location { Id = 337, Country = moldova, Name = "Gîsca", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Gîsca);

            var Grădinița = new Location { Id = 338, Country = moldova, Name = "Grădinița", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Grădinița);

            var Grigorievca = new Location { Id = 339, Country = moldova, Name = "Grigorievca", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Grigorievca);

            var Hagimus = new Location { Id = 340, Country = moldova, Name = "Hagimus", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Hagimus);

            var Leuntea = new Location { Id = 341, Country = moldova, Name = "Leuntea", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Leuntea);

            var MariancadeSus = new Location { Id = 342, Country = moldova, Name = "Marianca de Sus", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(MariancadeSus);

            var Merenești = new Location { Id = 343, Country = moldova, Name = "Merenești", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Merenești);

            var Opaci = new Location { Id = 344, Country = moldova, Name = "Opaci", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Opaci);

            var Pervomaisc = new Location { Id = 345, Country = moldova, Name = "Pervomaisc", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Pervomaisc);

            var Plop = new Location { Id = 346, Country = moldova, Name = "Plop", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Plop);

            var PlopȘtiubei = new Location { Id = 347, Country = moldova, Name = "Plop-Știubei", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(PlopȘtiubei);

            var Săiți = new Location { Id = 348, Country = moldova, Name = "Săiți", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Săiți);

            var Sălcuța = new Location { Id = 349, Country = moldova, Name = "Sălcuța", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Sălcuța);

            var SălcuțaNouă = new Location { Id = 350, Country = moldova, Name = "Sălcuța Nouă", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(SălcuțaNouă);

            var Surchiceni = new Location { Id = 351, Country = moldova, Name = "Surchiceni", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Surchiceni);

            var Ștefănești = new Location { Id = 352, Country = moldova, Name = "Ștefănești", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Ștefănești);

            var Tănătari = new Location { Id = 353, Country = moldova, Name = "Tănătari", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Tănătari);

            var TănătariiNoi = new Location { Id = 354, Country = moldova, Name = "Tănătarii Noi", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(TănătariiNoi);

            var Tocuz = new Location { Id = 355, Country = moldova, Name = "Tocuz", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Tocuz);

            var Tricolici = new Location { Id = 356, Country = moldova, Name = "Tricolici", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Tricolici);

            var Ucrainca = new Location { Id = 357, Country = moldova, Name = "Ucrainca", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Ucrainca);

            var UrsoaiaT = new Location { Id = 358, Country = moldova, Name = "Ursoaia", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Ursoaia);

            var UrsoaiaNouă = new Location { Id = 359, Country = moldova, Name = "Ursoaia Nouă", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(UrsoaiaNouă);

            var ValeaVerde = new Location { Id = 360, Country = moldova, Name = "Valea Verde", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(ValeaVerde);

            var Zahorna = new Location { Id = 361, Country = moldova, Name = "Zahorna", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Zahorna);

            var Zaim = new Location { Id = 362, Country = moldova, Name = "Zaim", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Zaim);

            var Zviozdocica = new Location { Id = 363, Country = moldova, Name = "Zviozdocica", ParentLocation = Căușeni };
            context.Locations.AddOrUpdate(Zviozdocica);

            var Albina = new Location { Id = 364, Country = moldova, Name = "Albina", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Albina);

            var Artimonovca = new Location { Id = 365, Country = moldova, Name = "Artimonovca", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Artimonovca);

            var Batîr = new Location { Id = 366, Country = moldova, Name = "Batîr", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Batîr);

            var BogdanovcaNouă = new Location { Id = 367, Country = moldova, Name = "Bogdanovca Nouă", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(BogdanovcaNouă);

            var BogdanovcaVeche = new Location { Id = 368, Country = moldova, Name = "Bogdanovca Veche", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(BogdanovcaVeche);

            var Cenac = new Location { Id = 369, Country = moldova, Name = "Cenac", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Cenac);

            var CiucurMingir = new Location { Id = 370, Country = moldova, Name = "Ciucur-Mingir", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(CiucurMingir);

            var Codreni = new Location { Id = 371, Country = moldova, Name = "Codreni", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Codreni);

            var Dimitrovca = new Location { Id = 372, Country = moldova, Name = "Dimitrovca", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Dimitrovca);

            var Ecaterinovca = new Location { Id = 373, Country = moldova, Name = "Ecaterinovca", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Ecaterinovca);

            var Fetița = new Location { Id = 374, Country = moldova, Name = "Fetița", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Fetița);

            var Gradiște = new Location { Id = 375, Country = moldova, Name = "Gradiște", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Gradiște);

            var GuraGalbenei = new Location { Id = 376, Country = moldova, Name = "Gura Galbenei", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(GuraGalbenei);

            var HîrtopC = new Location { Id = 377, Country = moldova, Name = "Hîrtop", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Hîrtop);

            var Ialpug = new Location { Id = 378, Country = moldova, Name = "Ialpug", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Ialpug);

            var Ialpujeni = new Location { Id = 379, Country = moldova, Name = "Ialpujeni", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Ialpujeni);

            var Iurievca = new Location { Id = 380, Country = moldova, Name = "Iurievca", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Iurievca);

            var IvanovcaNouă = new Location { Id = 381, Country = moldova, Name = "Ivanovca Nouă", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(IvanovcaNouă);

            var Javgur = new Location { Id = 382, Country = moldova, Name = "Javgur", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Javgur);

            var Lipoveni = new Location { Id = 383, Country = moldova, Name = "Lipoveni", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Lipoveni);

            var Marienfeld = new Location { Id = 384, Country = moldova, Name = "Marienfeld", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Marienfeld);

            var Maximeni = new Location { Id = 385, Country = moldova, Name = "Maximeni", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Maximeni);

            var MereniA = new Location { Id = 386, Country = moldova, Name = "Mereni", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Mereni);

            var Mihailovca = new Location { Id = 387, Country = moldova, Name = "Mihailovca", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Mihailovca);

            var Munteni = new Location { Id = 388, Country = moldova, Name = "Munteni", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Munteni);

            var Porumbrei = new Location { Id = 389, Country = moldova, Name = "Porumbrei", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Porumbrei);

            var Prisaca = new Location { Id = 390, Country = moldova, Name = "Prisaca", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Prisaca);

            var Sagaidac = new Location { Id = 391, Country = moldova, Name = "Sagaidac", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Sagaidac);

            var SagaidaculNou = new Location { Id = 392, Country = moldova, Name = "Sagaidacul Nou", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(SagaidaculNou);

            var SatulNou = new Location { Id = 393, Country = moldova, Name = "Satul Nou", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(SatulNou);

            var Schinoșica = new Location { Id = 394, Country = moldova, Name = "Schinoșica", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Schinoșica);

            var Selemet = new Location { Id = 395, Country = moldova, Name = "Selemet", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Selemet);

            var Suric = new Location { Id = 396, Country = moldova, Name = "Suric", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Suric);

            var Topala = new Location { Id = 397, Country = moldova, Name = "Topala", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Topala);

            var Troițcoe = new Location { Id = 398, Country = moldova, Name = "Troițcoe", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Troițcoe);

            var ValeaPerjei = new Location { Id = 399, Country = moldova, Name = "Valea Perjei", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(ValeaPerjei);

            var Zloți = new Location { Id = 400, Country = moldova, Name = "Zloți", ParentLocation = Cimișlia };
            context.Locations.AddOrUpdate(Zloți);

            var Bălăbănești = new Location { Id = 401, Country = moldova, Name = "Bălăbănești", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Bălăbănești);

            var Bălășești = new Location { Id = 402, Country = moldova, Name = "Bălășești", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Bălășești);

            var Bălțata = new Location { Id = 403, Country = moldova, Name = "Bălțata", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Bălțata);

            var BălțatadeSus = new Location { Id = 404, Country = moldova, Name = "Bălțata de Sus", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(BălțatadeSus);

            var Boșcana = new Location { Id = 405, Country = moldova, Name = "Boșcana", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Boșcana);

            var Chetroasa = new Location { Id = 406, Country = moldova, Name = "Chetroasa", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Chetroasa);

            var Cimișeni = new Location { Id = 407, Country = moldova, Name = "Cimișeni", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Cimișeni);

            var Ciopleni = new Location { Id = 408, Country = moldova, Name = "Ciopleni", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Ciopleni);

            var Corjova = new Location { Id = 409, Country = moldova, Name = "Corjova", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Corjova);

            var Coșernița = new Location { Id = 410, Country = moldova, Name = "Coșernița", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Coșernița);

            var Cruglic = new Location { Id = 411, Country = moldova, Name = "Cruglic", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Cruglic);

            var Dolinnoe = new Location { Id = 412, Country = moldova, Name = "Dolinnoe", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Dolinnoe);

            var Drăsliceni = new Location { Id = 413, Country = moldova, Name = "Drăsliceni", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Drăsliceni);

            var DubăsariiVechi = new Location { Id = 414, Country = moldova, Name = "Dubăsarii Vechi", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(DubăsariiVechi);

            var HîrtopulMare = new Location { Id = 415, Country = moldova, Name = "Hîrtopul Mare", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(HîrtopulMare);

            var HîrtopulMic = new Location { Id = 416, Country = moldova, Name = "Hîrtopul Mic", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(HîrtopulMic);

            var Hrușova = new Location { Id = 417, Country = moldova, Name = "Hrușova", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Hrușova);

            var Ișnovăț = new Location { Id = 418, Country = moldova, Name = "Ișnovăț", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Ișnovăț);

            var Izbiște = new Location { Id = 419, Country = moldova, Name = "Izbiște", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Izbiște);

            var Jevreni = new Location { Id = 420, Country = moldova, Name = "Jevreni", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Jevreni);

            var Logănești = new Location { Id = 421, Country = moldova, Name = "Logănești", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Logănești);

            var Mașcăuți = new Location { Id = 422, Country = moldova, Name = "Mașcăuți", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Mașcăuți);

            var Mărdăreuca = new Location { Id = 423, Country = moldova, Name = "Mărdăreuca", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Mărdăreuca);

            var Măgdăcești = new Location { Id = 424, Country = moldova, Name = "Măgdăcești", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Măgdăcești);

            var Mălăiești = new Location { Id = 425, Country = moldova, Name = "Mălăiești", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Mălăiești);

            var MălăieștiiNoi = new Location { Id = 426, Country = moldova, Name = "Mălăieștii Noi", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(MălăieștiiNoi);

            var Miclești = new Location { Id = 427, Country = moldova, Name = "Miclești", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Miclești);

            var Ohrincea = new Location { Id = 428, Country = moldova, Name = "Ohrincea", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Ohrincea);

            var Onițcani = new Location { Id = 429, Country = moldova, Name = "Onițcani", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Onițcani);

            var PașcaniC = new Location { Id = 430, Country = moldova, Name = "Pașcani", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Pașcani);

            var Porumbeni = new Location { Id = 431, Country = moldova, Name = "Porumbeni", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Porumbeni);

            var Ratuș = new Location { Id = 431, Country = moldova, Name = "Ratuș", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Ratuș);

            var Răculești = new Location { Id = 432, Country = moldova, Name = "Răculești", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Răculești);

            var Rîșcova = new Location { Id = 433, Country = moldova, Name = "Rîșcova", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Rîșcova);

            var SagaidacB = new Location { Id = 434, Country = moldova, Name = "Sagaidac", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Sagaidac);

            var SagaidaculdeSus = new Location { Id = 435, Country = moldova, Name = "Sagaidacul de Sus", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(SagaidaculdeSus);

            var SloboziaDușca = new Location { Id = 436, Country = moldova, Name = "Slobozia-Dușca", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(SloboziaDușca);

            var Stețcani = new Location { Id = 437, Country = moldova, Name = "Stețcani", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Stețcani);

            var ValeaColoniței = new Location { Id = 438, Country = moldova, Name = "Valea Coloniței", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(ValeaColoniței);

            var ValeaSatului = new Location { Id = 439, Country = moldova, Name = "Valea Satului", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(ValeaSatului);

            var Zăicana = new Location { Id = 440, Country = moldova, Name = "Zăicana", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Zăicana);

            var Zolonceni = new Location { Id = 441, Country = moldova, Name = "Zolonceni", ParentLocation = Criuleni };
            context.Locations.AddOrUpdate(Zolonceni);

            var Arionești = new Location { Id = 442, Country = moldova, Name = "Arionești", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Arionești);

            var Baraboi = new Location { Id = 443, Country = moldova, Name = "Baraboi", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Baraboi);

            var Boroseni = new Location { Id = 444, Country = moldova, Name = "Boroseni", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Boroseni);

            var Braicău = new Location { Id = 445, Country = moldova, Name = "Braicău", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Braicău);

            var BriceniD = new Location { Id = 446, Country = moldova, Name = "Briceni", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Briceni);

            var Briceva = new Location { Id = 447, Country = moldova, Name = "Briceva", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Briceva);

            var Caraiman = new Location { Id = 448, Country = moldova, Name = "Caraiman", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Caraiman);

            var Cernoleuca = new Location { Id = 449, Country = moldova, Name = "Cernoleuca", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Cernoleuca);

            var Climăuți = new Location { Id = 450, Country = moldova, Name = "Climăuți", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Climăuți);

            var CodreniiNoi = new Location { Id = 451, Country = moldova, Name = "Codrenii Noi", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(CodreniiNoi);

            var Corbu = new Location { Id = 452, Country = moldova, Name = "Corbu", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Corbu);

            var Crișcăuți = new Location { Id = 453, Country = moldova, Name = "Crișcăuți", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Crișcăuți);

            var Elenovca = new Location { Id = 454, Country = moldova, Name = "Elenovca", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Elenovca);

            var Elizavetovca = new Location { Id = 455, Country = moldova, Name = "Elizavetovca", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Elizavetovca);

            var Frasin = new Location { Id = 456, Country = moldova, Name = "Frasin", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Frasin);

            var HorodișteD = new Location { Id = 457, Country = moldova, Name = "Horodiște", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Horodiște);

            var Moșana = new Location { Id = 458, Country = moldova, Name = "Moșana", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Moșana);

            var Octeabriscoe = new Location { Id = 459, Country = moldova, Name = "Octeabriscoe", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Octeabriscoe);

            var Pivniceni = new Location { Id = 460, Country = moldova, Name = "Pivniceni", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Pivniceni);

            var PlopD = new Location { Id = 461, Country = moldova, Name = "Plop", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Plop);

            var Pocrovca = new Location { Id = 462, Country = moldova, Name = "Pocrovca", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Pocrovca);

            var RediulMare = new Location { Id = 463, Country = moldova, Name = "Rediul Mare", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(RediulMare);

            var Scăieni = new Location { Id = 464, Country = moldova, Name = "Scăieni", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Scăieni);

            var Sudarca = new Location { Id = 465, Country = moldova, Name = "Sudarca", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Sudarca);

            var Teleșeuca = new Location { Id = 466, Country = moldova, Name = "Teleșeuca", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Teleșeuca);

            var TeleșeucaNouă = new Location { Id = 467, Country = moldova, Name = "Teleșeuca Nouă", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(TeleșeucaNouă);

            var Tîrnova = new Location { Id = 468, Country = moldova, Name = "Tîrnova", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Tîrnova);

            var Țaul = new Location { Id = 469, Country = moldova, Name = "Țaul", ParentLocation = Dondușeni };
            context.Locations.AddOrUpdate(Țaul);

            var Antoneuca = new Location { Id = 470, Country = moldova, Name = "Antoneuca", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Antoneuca);

            var Baroncea = new Location { Id = 471, Country = moldova, Name = "Baroncea", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Baroncea);

            var BaronceaNouă = new Location { Id = 472, Country = moldova, Name = "Baroncea Nouă", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(BaronceaNouă);

            var Ceapaevca = new Location { Id = 473, Country = moldova, Name = "Ceapaevca", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Ceapaevca);

            var ChetrosuDr = new Location { Id = 474, Country = moldova, Name = "Chetrosu", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Chetrosu);

            var Cotova = new Location { Id = 475, Country = moldova, Name = "Cotova", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Cotova);

            var Dominteni = new Location { Id = 476, Country = moldova, Name = "Dominteni", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Dominteni);

            var Fîntînița = new Location { Id = 477, Country = moldova, Name = "Fîntînița", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Fîntînița);

            var Gribova = new Location { Id = 478, Country = moldova, Name = "Gribova", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Gribova);

            var HăsnășeniiMari = new Location { Id = 479, Country = moldova, Name = "Hăsnășenii Mari", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(HăsnășeniiMari);

            var HăsnășeniiNoi = new Location { Id = 480, Country = moldova, Name = "Hăsnășenii Noi", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(HăsnășeniiNoi);

            var HoloșnițaNouă = new Location { Id = 481, Country = moldova, Name = "Holoșnița Nouă", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(HoloșnițaNouă);

            var Iliciovca = new Location { Id = 482, Country = moldova, Name = "Iliciovca", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Iliciovca);

            var Lazo = new Location { Id = 483, Country = moldova, Name = "Lazo", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Lazo);

            var Maramonovca = new Location { Id = 484, Country = moldova, Name = "Maramonovca", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Maramonovca);

            var Măcăreuca = new Location { Id = 485, Country = moldova, Name = "Măcăreuca", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Măcăreuca);

            var Miciurin = new Location { Id = 486, Country = moldova, Name = "Miciurin", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Miciurin);

            var Mîndîc = new Location { Id = 487, Country = moldova, Name = "Mîndîc", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Mîndîc);

            var MoaradePiatră = new Location { Id = 488, Country = moldova, Name = "Moara de Piatră", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(MoaradePiatră);

            var Nicoreni = new Location { Id = 489, Country = moldova, Name = "Nicoreni", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Nicoreni);

            var OchiulAlb = new Location { Id = 490, Country = moldova, Name = "Ochiul Alb", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(OchiulAlb);

            var PalancaDr = new Location { Id = 491, Country = moldova, Name = "Palanca", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Palanca);

            var Pelinia = new Location { Id = 492, Country = moldova, Name = "Pelinia", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Pelinia);

            var Pervomaiscoe = new Location { Id = 493, Country = moldova, Name = "Pervomaiscoe", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Pervomaiscoe);

            var Petreni = new Location { Id = 494, Country = moldova, Name = "Petreni", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Petreni);

            var PopeștiideJos = new Location { Id = 495, Country = moldova, Name = "Popeștii de Jos", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(PopeștiideJos);

            var PopeștiideSus = new Location { Id = 496, Country = moldova, Name = "Popeștii de Sus", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(PopeștiideSus);

            var PopeștiiNoi = new Location { Id = 497, Country = moldova, Name = "Popeștii Noi", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(PopeștiiNoi);

            var Sergheuca = new Location { Id = 498, Country = moldova, Name = "Sergheuca", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Sergheuca);

            var Sofia = new Location { Id = 499, Country = moldova, Name = "Sofia", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Sofia);

            var ȘalviriiNoi = new Location { Id = 500, Country = moldova, Name = "Șalvirii Noi", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(ȘalviriiNoi);

            var ȘalviriiVechi = new Location { Id = 501, Country = moldova, Name = "Șalvirii Vechi", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(ȘalviriiVechi);

            var Șuri = new Location { Id = 502, Country = moldova, Name = "Șuri", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Șuri);

            var ȘuriiNoi = new Location { Id = 503, Country = moldova, Name = "Șurii Noi", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(ȘuriiNoi);

            var Țarigrad = new Location { Id = 504, Country = moldova, Name = "Țarigrad", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Țarigrad);

            var Zgurița = new Location { Id = 505, Country = moldova, Name = "Zgurița", ParentLocation = Drochia };
            context.Locations.AddOrUpdate(Zgurița);

            var Cocieri = new Location { Id = 506, Country = moldova, Name = "Cocieri", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Cocieri);

            var CorjovaD = new Location { Id = 507, Country = moldova, Name = "Corjova", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Corjova);

            var Coșnița = new Location { Id = 508, Country = moldova, Name = "Coșnița", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Coșnița);

            var Doroțcaia = new Location { Id = 509, Country = moldova, Name = "Doroțcaia", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Doroțcaia);

            var Holercani = new Location { Id = 510, Country = moldova, Name = "Holercani", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Holercani);

            var Mahala = new Location { Id = 511, Country = moldova, Name = "Mahala", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Mahala);

            var MărcăuțiD = new Location { Id = 512, Country = moldova, Name = "Mărcăuți", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Mărcăuți);

            var Molovata = new Location { Id = 513, Country = moldova, Name = "Molovata", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Molovata);

            var MolovataNouă = new Location { Id = 514, Country = moldova, Name = "Molovata Nouă", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(MolovataNouă);

            var Oxentea = new Location { Id = 515, Country = moldova, Name = "Oxentea", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Oxentea);

            var Pîrîta = new Location { Id = 516, Country = moldova, Name = "Pîrîta", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Pîrîta);

            var Pohrebea = new Location { Id = 517, Country = moldova, Name = "Pohrebea", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Pohrebea);

            var Roghi = new Location { Id = 518, Country = moldova, Name = "Roghi", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Roghi);

            var Ustia = new Location { Id = 519, Country = moldova, Name = "Ustia", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Ustia);

            var Vasilievca = new Location { Id = 520, Country = moldova, Name = "Vasilievca", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Vasilievca);

            var ComisarovcaNouă = new Location { Id = 521, Country = moldova, Name = "Comisarovca Nouă", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(ComisarovcaNouă);

            var CrasnîiVinogradari = new Location { Id = 522, Country = moldova, Name = "Crasnîi Vinogradari", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(CrasnîiVinogradari);

            var DoibaniI = new Location { Id = 523, Country = moldova, Name = "Doibani I", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(DoibaniI);

            var Dubău = new Location { Id = 524, Country = moldova, Name = "Dubău", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Dubău);

            var Dzerjinscoe = new Location { Id = 525, Country = moldova, Name = "Dzerjinscoe", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Dzerjinscoe);

            var GoianD = new Location { Id = 526, Country = moldova, Name = "Goian", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Goian);

            var Harmațca = new Location { Id = 527, Country = moldova, Name = "Harmațca", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Harmațca);

            var Lunga = new Location { Id = 528, Country = moldova, Name = "Lunga", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Lunga);

            var Țîbuleuca = new Location { Id = 529, Country = moldova, Name = "Țîbuleuca", ParentLocation = Dubăsari };
            context.Locations.AddOrUpdate(Țîbuleuca);

            var Alexăndreni = new Location { Id = 530, Country = moldova, Name = "Alexăndreni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Alexăndreni);

            var Alexeevca = new Location { Id = 531, Country = moldova, Name = "Alexeevca", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Alexeevca);

            var BădragiiNoi = new Location { Id = 532, Country = moldova, Name = "Bădragii Noi", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(BădragiiNoi);

            var BădragiiVechi = new Location { Id = 533, Country = moldova, Name = "Bădragii Vechi", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(BădragiiVechi);

            var Bleșteni = new Location { Id = 534, Country = moldova, Name = "Bleșteni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Bleșteni);

            var Brătușeni = new Location { Id = 535, Country = moldova, Name = "Brătușeni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Brătușeni);

            var BrătușeniiNoi = new Location { Id = 536, Country = moldova, Name = "Brătușenii Noi", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(BrătușeniiNoi);

            var Brînzeni = new Location { Id = 537, Country = moldova, Name = "Brînzeni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Brînzeni);

            var Burlănești = new Location { Id = 538, Country = moldova, Name = "Burlănești", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Burlănești);

            var Buzdugeni = new Location { Id = 539, Country = moldova, Name = "Buzdugeni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Buzdugeni);

            var Cepeleuți = new Location { Id = 540, Country = moldova, Name = "Cepeleuți", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Cepeleuți);

            var ChetroșicaNouă = new Location { Id = 541, Country = moldova, Name = "Chetroșica Nouă", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(ChetroșicaNouă);

            var ChetroșicaVeche = new Location { Id = 542, Country = moldova, Name = "Chetroșica Veche", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(ChetroșicaVeche);

            var Chiurt = new Location { Id = 543, Country = moldova, Name = "Chiurt", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Chiurt);

            var Clișcăuți = new Location { Id = 544, Country = moldova, Name = "Clișcăuți", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Clișcăuți);

            var ConstantinovcaE = new Location { Id = 545, Country = moldova, Name = "Constantinovca", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Constantinovca);

            var Corpaci = new Location { Id = 546, Country = moldova, Name = "Corpaci", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Corpaci);

            var CuconeștiiNoi = new Location { Id = 547, Country = moldova, Name = "Cuconeștii Noi", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(CuconeștiiNoi);

            var CuconeștiiVechi = new Location { Id = 548, Country = moldova, Name = "Cuconeștii Vechi", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(CuconeștiiVechi);

            var Cupcini = new Location { Id = 549, Country = moldova, Name = "Cupcini", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Cupcini);

            var Fetești = new Location { Id = 550, Country = moldova, Name = "Fetești", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Fetești);

            var FîntînaAlbă = new Location { Id = 551, Country = moldova, Name = "Fîntîna Albă", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(FîntînaAlbă);

            var Gașpar = new Location { Id = 552, Country = moldova, Name = "Gașpar", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Gașpar);

            var Goleni = new Location { Id = 553, Country = moldova, Name = "Goleni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Goleni);

            var Gordinești = new Location { Id = 554, Country = moldova, Name = "Gordinești", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Gordinești);

            var GordineștiiNoi = new Location { Id = 555, Country = moldova, Name = "Gordineștii Noi", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(GordineștiiNoi);

            var Hancăuți = new Location { Id = 556, Country = moldova, Name = "Hancăuți", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Hancăuți);

            var Hincăuți = new Location { Id = 557, Country = moldova, Name = "Hincăuți", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Hincăuți);

            var Hlinaia = new Location { Id = 558, Country = moldova, Name = "Hlinaia", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Hlinaia);

            var HlinaiaMică = new Location { Id = 559, Country = moldova, Name = "Hlinaia Mică", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(HlinaiaMică);

            var Iachimeni = new Location { Id = 560, Country = moldova, Name = "Iachimeni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Iachimeni);

            var Lopatnic = new Location { Id = 561, Country = moldova, Name = "Lopatnic", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Lopatnic);

            var Onești = new Location { Id = 562, Country = moldova, Name = "Onești", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Onești);

            var Parcova = new Location { Id = 563, Country = moldova, Name = "Parcova", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Parcova);

            var Poiana = new Location { Id = 564, Country = moldova, Name = "Poiana", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Poiana);

            var Rîngaci = new Location { Id = 565, Country = moldova, Name = "Rîngaci", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Rîngaci);

            var Rotunda = new Location { Id = 566, Country = moldova, Name = "Rotunda", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Rotunda);

            var RuseniE = new Location { Id = 567, Country = moldova, Name = "Ruseni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Ruseni);

            var Slobodca = new Location { Id = 568, Country = moldova, Name = "Slobodca", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Slobodca);

            var Stolniceni = new Location { Id = 569, Country = moldova, Name = "Stolniceni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Stolniceni);

            var Șofrîncani = new Location { Id = 570, Country = moldova, Name = "Șofrîncani", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Șofrîncani);

            var Terebna = new Location { Id = 571, Country = moldova, Name = "Terebna", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Terebna);

            var TîrnovaE = new Location { Id = 572, Country = moldova, Name = "Tîrnova", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Tîrnova);

            var Trinca = new Location { Id = 573, Country = moldova, Name = "Trinca", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Trinca);

            var Vancicăuți = new Location { Id = 574, Country = moldova, Name = "Vancicăuți", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Vancicăuți);

            var Viișoara = new Location { Id = 575, Country = moldova, Name = "Viișoara", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Viișoara);

            var Volodeni = new Location { Id = 576, Country = moldova, Name = "Volodeni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Volodeni);

            var Zăbriceni = new Location { Id = 577, Country = moldova, Name = "Zăbriceni", ParentLocation = Edineț };
            context.Locations.AddOrUpdate(Zăbriceni);

            var AlbinețulNou = new Location { Id = 578, Country = moldova, Name = "Albinețul Nou", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(AlbinețulNou);

            var AlbinețulVechi = new Location { Id = 579, Country = moldova, Name = "Albinețul Vechi", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(AlbinețulVechi);

            var Beleuți = new Location { Id = 580, Country = moldova, Name = "Beleuți", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Beleuți);

            var Bocani = new Location { Id = 581, Country = moldova, Name = "Bocani", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Bocani);

            var Bocșa = new Location { Id = 581, Country = moldova, Name = "Bocșa", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Bocșa);

            var Burghelea = new Location { Id = 582, Country = moldova, Name = "Burghelea", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Burghelea);

            var Catranîc = new Location { Id = 583, Country = moldova, Name = "Catranîc", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Catranîc);

            var Călinești = new Location { Id = 584, Country = moldova, Name = "Călinești", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Călinești);

            var Călugăr = new Location { Id = 585, Country = moldova, Name = "Călugăr", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Călugăr);

            var Chetriș = new Location { Id = 586, Country = moldova, Name = "Chetriș", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Chetriș);

            var ChetrișulNou = new Location { Id = 587, Country = moldova, Name = "Chetrișul Nou", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(ChetrișulNou);

            var CiolacuNou = new Location { Id = 588, Country = moldova, Name = "Ciolacu Nou", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(CiolacuNou);

            var CiolacuVechi = new Location { Id = 589, Country = moldova, Name = "Ciolacu Vechi", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(CiolacuVechi);

            var Ciuluc = new Location { Id = 590, Country = moldova, Name = "Ciuluc", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Ciuluc);

            var Comarovca = new Location { Id = 591, Country = moldova, Name = "Comarovca", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Comarovca);

            var CuzmeniiVechi = new Location { Id = 592, Country = moldova, Name = "Cuzmenii Vechi", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(CuzmeniiVechi);

            var Doltu = new Location { Id = 593, Country = moldova, Name = "Doltu", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Doltu);

            var Drujineni = new Location { Id = 594, Country = moldova, Name = "Drujineni", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Drujineni);

            var Egorovca = new Location { Id = 595, Country = moldova, Name = "Egorovca", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Egorovca);

            var Făgădău = new Location { Id = 596, Country = moldova, Name = "Făgădău", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Făgădău);

            var FăleștiiNoi = new Location { Id = 597, Country = moldova, Name = "Făleștii Noi", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(FăleștiiNoi);

            var FrumușicaF = new Location { Id = 598, Country = moldova, Name = "Frumușica", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Frumușica);

            var Glinjeni = new Location { Id = 599, Country = moldova, Name = "Glinjeni", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Glinjeni);

            var Hiliuți = new Location { Id = 600, Country = moldova, Name = "Hiliuți", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Hiliuți);

            var Hitrești = new Location { Id = 601, Country = moldova, Name = "Hitrești", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Hitrești);

            var HînceștiF = new Location { Id = 602, Country = moldova, Name = "Hîncești", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Hîncești);

            var HîrtopF = new Location { Id = 603, Country = moldova, Name = "Hîrtop", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Hîrtop);

            var Horești = new Location { Id = 604, Country = moldova, Name = "Horești", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Horești);

            var HrubnaNouă = new Location { Id = 605, Country = moldova, Name = "Hrubna Nouă", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(HrubnaNouă);

            var Ilenuța = new Location { Id = 606, Country = moldova, Name = "Ilenuța", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Ilenuța);

            var Ișcălău = new Location { Id = 607, Country = moldova, Name = "Ișcălău", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Ișcălău);

            var IvanovcaF = new Location { Id = 608, Country = moldova, Name = "Ivanovca", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Ivanovca);

            var Izvoare = new Location { Id = 609, Country = moldova, Name = "Izvoare", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Izvoare);

            var Logofteni = new Location { Id = 610, Country = moldova, Name = "Logofteni", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Logofteni);

            var Lucăceni = new Location { Id = 611, Country = moldova, Name = "Lucăceni", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Lucăceni);

            var Măgura = new Location { Id = 612, Country = moldova, Name = "Măgura", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Măgura);

            var MăguraNouă = new Location { Id = 613, Country = moldova, Name = "Măgura Nouă", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(MăguraNouă);

            var Măgureanca = new Location { Id = 614, Country = moldova, Name = "Măgureanca", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Măgureanca);

            var Mărăndeni = new Location { Id = 615, Country = moldova, Name = "Mărăndeni", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Mărăndeni);

            var Moldoveanca = new Location { Id = 616, Country = moldova, Name = "Moldoveanca", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Moldoveanca);

            var Musteața = new Location { Id = 617, Country = moldova, Name = "Musteața", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Musteața);

            var Natalievca = new Location { Id = 618, Country = moldova, Name = "Natalievca", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Natalievca);

            var Năvîrneț = new Location { Id = 619, Country = moldova, Name = "Năvîrneț", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Năvîrneț);

            var NicolaevcaF = new Location { Id = 620, Country = moldova, Name = "Nicolaevca", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Nicolaevca);

            var ObrejaNouă = new Location { Id = 621, Country = moldova, Name = "Obreja Nouă", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(ObrejaNouă);

            var ObrejaVeche = new Location { Id = 622, Country = moldova, Name = "Obreja Veche", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(ObrejaVeche);

            var PervomaiscF = new Location { Id = 623, Country = moldova, Name = "Pervomaisc", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Pervomaisc);

            var Pietrosu = new Location { Id = 624, Country = moldova, Name = "Pietrosu", ParentLocation = Fălești };
            context.Locations.AddOrUpdate(Pietrosu);








        }
    }
}
