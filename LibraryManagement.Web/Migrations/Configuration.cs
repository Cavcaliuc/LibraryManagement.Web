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


            #region Genders
            if (!context.Genders.Any())
            {
                var male = new Gender { Id = 1, Name = "Male" };
                var female = new Gender { Id = 2, Name = "Female" };

                context.Genders.AddOrUpdate(male);
                context.Genders.AddOrUpdate(female);
            }
            #endregion Genders

            #region Conditions
            if (!context.Conditions.Any())
            {
                var excellent = new Condition { Id = 1, Name = "New" };
                var good = new Condition { Id = 2, Name = "Good" };
                var poor = new Condition { Id = 2, Name = "Poor" };

                context.Conditions.AddOrUpdate(excellent);
                context.Conditions.AddOrUpdate(good);
                context.Conditions.AddOrUpdate(poor);
            }
            #endregion Conditions

            if (!context.Categories.Any())
            {
                var carte = new Category { Name = "Book" };
                context.Categories.AddOrUpdate(carte);
                var articol = new Category { Name = "Article" };
                context.Categories.AddOrUpdate(articol);
                var revista = new Category { Name = "Magazine" };
                context.Categories.AddOrUpdate(revista);
                var ziar = new Category { Name = "Newspaper" };
                context.Categories.AddOrUpdate(ziar);
                var ebook = new Category { Name = "E-book" };
                context.Categories.AddOrUpdate(ebook);
                var audiobook = new Category { Name = "Audiobook" };
                context.Categories.AddOrUpdate(audiobook);
                context.SaveChanges();


                #region Author
                if (!context.Authors.Any())
                {
                    var ionCreaga = new Author { FirstName = "Ion", LastName = "Creangă" };
                    context.Authors.AddOrUpdate(ionCreaga);

                    var mirceaEliade = new Author { FirstName = "Mircea", LastName = "Eliade" };
                    context.Authors.AddOrUpdate(mirceaEliade);

                    var nicolaeDabija = new Author { FirstName = "Nicolae", LastName = "Dabija" };
                    context.Authors.AddOrUpdate(nicolaeDabija);

                    var stephenKing = new Author { FirstName = "Stephen", LastName = "King" };
                    context.Authors.AddOrUpdate(stephenKing);

                    var agathaChristie = new Author { FirstName = "Agatha", LastName = "Christie" };
                    context.Authors.AddOrUpdate(agathaChristie);

                    var danBrown = new Author { FirstName = "Dan", LastName = "Brown" };
                    context.Authors.AddOrUpdate(danBrown);

                    var mihaiEminescu = new Author { FirstName = "Mihai", LastName = "Eminescu" };
                    context.Authors.AddOrUpdate(mihaiEminescu);

                    var grigoreVieru = new Author { FirstName = "Grigore", LastName = "Vieru" };
                    context.Authors.AddOrUpdate(grigoreVieru);

                    var jkrowling = new Author { FirstName = "Joanne", LastName = "Rowling" };
                    context.Authors.AddOrUpdate(jkrowling);

                    var esenin = new Author { FirstName = "Serghei", LastName = "Esenin" };
                    context.Authors.AddOrUpdate(esenin);

                    #endregion Author

                    #region Publisher

                    var arc = new Publisher { Name = "ARC" };
                    context.Publishers.AddOrUpdate(arc);

                    var cartier = new Publisher { Name = "Cartier" };
                    context.Publishers.AddOrUpdate(cartier);

                    var humanitas = new Publisher { Name = "Humanitas" };
                    context.Publishers.AddOrUpdate(humanitas);

                    var litera = new Publisher { Name = "Litera" };
                    context.Publishers.AddOrUpdate(litera);

                    var lumina = new Publisher { Name = "Lumina" };
                    context.Publishers.AddOrUpdate(lumina);

                    var polirom = new Publisher { Name = "Polirom" };
                    context.Publishers.AddOrUpdate(polirom);

                    var prInt = new Publisher { Name = "Prut Internațional" };
                    context.Publishers.AddOrUpdate(prInt);

                    var rao = new Publisher { Name = "RAO" };
                    context.Publishers.AddOrUpdate(rao);

                    var teora = new Publisher { Name = "Teora" };
                    context.Publishers.AddOrUpdate(teora);

                    var trei = new Publisher { Name = "Trei" };
                    context.Publishers.AddOrUpdate(trei);

                    #endregion Publisher

                    #region Item

                    var item0 = new Item { Title = "Zece negri mititei", OrdersCount = 1, Category = carte, Publisher = rao, Author = agathaChristie };
                    context.Items.AddOrUpdate(item0);

                    var item1 = new Item { Title = "Simbolul pierdut", OrdersCount = 1, Category = carte, Publisher = rao, Author = danBrown };
                    context.Items.AddOrUpdate(item1);

                    var item2 = new Item { Title = "Amintiri din copilărie", OrdersCount = 1, Category = carte, Publisher = arc, Author = ionCreaga };
                    context.Items.AddOrUpdate(item2);

                    var item3 = new Item { Title = "Poezii", OrdersCount = 1, Category = carte, Publisher = litera, Author = mihaiEminescu };
                    context.Items.AddOrUpdate(item3);

                    var item4 = new Item { Title = "Moarte subită", OrdersCount = 1, Category = carte, Publisher = trei, Author = jkrowling };
                    context.Items.AddOrUpdate(item4);

                    var item5 = new Item { Title = "Anotimpuri diferite", OrdersCount = 1, Category = carte, Publisher = trei, Author = stephenKing };
                    context.Items.AddOrUpdate(item5);

                    var item6 = new Item { Title = "Dicționar al religiilor", OrdersCount = 1, Category = carte, Publisher = polirom, Author = mirceaEliade };
                    context.Items.AddOrUpdate(item6);

                    var item7 = new Item { Title = "Curcubeul", OrdersCount = 1, Category = carte, Publisher = litera, Author = grigoreVieru };
                    context.Items.AddOrUpdate(item7);

                    var item8 = new Item { Title = "Poezii - Poems, editie bilingva", OrdersCount = 1, Category = carte, Publisher = teora, Author = mihaiEminescu };
                    context.Items.AddOrUpdate(item8);

                    var item9 = new Item { Title = "Moarte printre nori", OrdersCount = 1, Category = carte, Publisher = litera, Author = agathaChristie };
                    context.Items.AddOrUpdate(item9);

                    #endregion Item
                }
            }

            var moldova = context.Countries.FirstOrDefault(x => x.Name == "Moldova");
            if (moldova == null)
            {
                moldova = new Country { Id = 1, Name = "Moldova" };
                context.Countries.AddOrUpdate(moldova);
                context.SaveChanges();
            }

            if (!context.Locations.Any())
            {
                #region Cities
                //cities
                var municipiulChisinau = new Location { Id = 1, Country = moldova, Name = "Chișinău" };
                context.Locations.AddOrUpdate(municipiulChisinau);

                var municipiulBalti = new Location { Id = 2, Country = moldova, Name = "Bălți" };
                context.Locations.AddOrUpdate(municipiulBalti);

                var municipiulBenderTighina = new Location { Id = 3, Country = moldova, Name = "Bender" };
                context.Locations.AddOrUpdate(municipiulBenderTighina);

                var aneniiNoi = new Location { Id = 4, Country = moldova, Name = "Anenii Noi" };
                context.Locations.AddOrUpdate(aneniiNoi);

                var basarabeasca = new Location { Id = 5, Country = moldova, Name = "Basarabeasca" };
                context.Locations.AddOrUpdate(basarabeasca);

                var briceni = new Location { Id = 6, Country = moldova, Name = "Briceni" };
                context.Locations.AddOrUpdate(briceni);

                var cahul = new Location { Id = 7, Country = moldova, Name = "Cahul" };
                context.Locations.AddOrUpdate(cahul);

                var camenca = new Location { Id = 8, Country = moldova, Name = "Camenca" };
                context.Locations.AddOrUpdate(camenca);

                var calarasi = new Location { Id = 9, Country = moldova, Name = "Călărași" };
                context.Locations.AddOrUpdate(calarasi);

                var cantemir = new Location { Id = 10, Country = moldova, Name = "Cantemir" };
                context.Locations.AddOrUpdate(cantemir);

                var causeni = new Location { Id = 11, Country = moldova, Name = "Căușeni" };
                context.Locations.AddOrUpdate(causeni);

                var cimislia = new Location { Id = 12, Country = moldova, Name = "Cimișlia" };
                context.Locations.AddOrUpdate(cimislia);

                var criuleni = new Location { Id = 13, Country = moldova, Name = "Criuleni" };
                context.Locations.AddOrUpdate(criuleni);

                var donduseni = new Location { Id = 14, Country = moldova, Name = "Dondușeni" };
                context.Locations.AddOrUpdate(donduseni);

                var drochia = new Location { Id = 15, Country = moldova, Name = "Drochia" };
                context.Locations.AddOrUpdate(drochia);

                var dubasari = new Location { Id = 16, Country = moldova, Name = "Dubăsari" };
                context.Locations.AddOrUpdate(dubasari);

                var edinet = new Location { Id = 17, Country = moldova, Name = "Edineț" };
                context.Locations.AddOrUpdate(edinet);

                var falesti = new Location { Id = 18, Country = moldova, Name = "Fălești" };
                context.Locations.AddOrUpdate(falesti);

                var floresti = new Location { Id = 19, Country = moldova, Name = "Florești" };
                context.Locations.AddOrUpdate(floresti);

                var glodeni = new Location { Id = 20, Country = moldova, Name = "Glodeni" };
                context.Locations.AddOrUpdate(glodeni);

                var hincesti = new Location { Id = 21, Country = moldova, Name = "Hîncești" };
                context.Locations.AddOrUpdate(hincesti);

                var ialoveni = new Location { Id = 22, Country = moldova, Name = "Ialoveni" };
                context.Locations.AddOrUpdate(ialoveni);

                var leova = new Location { Id = 23, Country = moldova, Name = "Leova" };
                context.Locations.AddOrUpdate(leova);

                var nisporeni = new Location { Id = 24, Country = moldova, Name = "Nisporeni" };
                context.Locations.AddOrUpdate(nisporeni);

                var ocnita = new Location { Id = 25, Country = moldova, Name = "Ocnița" };
                context.Locations.AddOrUpdate(ocnita);

                var orhei = new Location { Id = 26, Country = moldova, Name = "Orhei" };
                context.Locations.AddOrUpdate(orhei);

                var rezina = new Location { Id = 27, Country = moldova, Name = "Rezina" };
                context.Locations.AddOrUpdate(rezina);

                var riscani = new Location { Id = 29, Country = moldova, Name = "Rîșcani" };
                context.Locations.AddOrUpdate(riscani);

                var singerei = new Location { Id = 30, Country = moldova, Name = "Sîngerei" };
                context.Locations.AddOrUpdate(singerei);

                var soroca = new Location { Id = 31, Country = moldova, Name = "Soroca" };
                context.Locations.AddOrUpdate(soroca);

                var straseni = new Location { Id = 32, Country = moldova, Name = "Strășeni" };
                context.Locations.AddOrUpdate(straseni);

                var soldanesti = new Location { Id = 33, Country = moldova, Name = "Șoldănești" };
                context.Locations.AddOrUpdate(soldanesti);

                var stefanVoda = new Location { Id = 34, Country = moldova, Name = "Ștefan Vodă" };
                context.Locations.AddOrUpdate(stefanVoda);

                var taraclia = new Location { Id = 35, Country = moldova, Name = "Taraclia" };
                context.Locations.AddOrUpdate(taraclia);

                var telenesti = new Location { Id = 36, Country = moldova, Name = "Telenești" };
                context.Locations.AddOrUpdate(telenesti);

                var ungheni = new Location { Id = 37, Country = moldova, Name = "Ungheni" };
                context.Locations.AddOrUpdate(ungheni);

                var unitateaTeritorialaAutonomaGagauzia = new Location { Id = 38, Country = moldova, Name = "Unitatea Teritorială Autonomă Găgăuzia" };
                context.Locations.AddOrUpdate(unitateaTeritorialaAutonomaGagauzia);

                var unitatileAdministrativTeritorialedinStingaNistrului = new Location { Id = 39, Country = moldova, Name = "Unitățile Administrativ Teritoriale din Stînga Nistrului" };
                context.Locations.AddOrUpdate(unitatileAdministrativTeritorialedinStingaNistrului);

                #endregion Cities


                #region villages
                //villages

                var bacioi = new Location { Id = 40, Country = moldova, Name = "Bacioi", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(bacioi);

                var bic = new Location { Id = 41, Country = moldova, Name = "Bîc", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(bic);

                var braila = new Location { Id = 42, Country = moldova, Name = "Brăila", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(braila);

                var bubuieci = new Location { Id = 43, Country = moldova, Name = "Bubuieci", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(bubuieci);

                var budesti = new Location { Id = 44, Country = moldova, Name = "Budești", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(budesti);

                var buneti = new Location { Id = 45, Country = moldova, Name = "Buneți", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(buneti);

                var ceroborta = new Location { Id = 46, Country = moldova, Name = "Ceroborta", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(ceroborta);

                var cheltuitori = new Location { Id = 46, Country = moldova, Name = "Cheltuitori", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(cheltuitori);

                var ciorescu = new Location { Id = 47, Country = moldova, Name = "Ciorescu", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(ciorescu);

                var codru = new Location { Id = 48, Country = moldova, Name = "Codru", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(codru);

                var colonita = new Location { Id = 49, Country = moldova, Name = "Colonița", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(colonita);

                var condrita = new Location { Id = 50, Country = moldova, Name = "Condrița", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(condrita);

                var cricova = new Location { Id = 51, Country = moldova, Name = "Cricova", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(cricova);

                var cruzesti = new Location { Id = 52, Country = moldova, Name = "Cruzești", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(cruzesti);

                var dobrogea = new Location { Id = 53, Country = moldova, Name = "Dobrogea", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(dobrogea);

                var dumbrava = new Location { Id = 54, Country = moldova, Name = "Dumbrava", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(dumbrava);

                var durlesti = new Location { Id = 55, Country = moldova, Name = "Durlești", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(durlesti);

                var fauresti = new Location { Id = 56, Country = moldova, Name = "Făurești", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(fauresti);

                var frumusica = new Location { Id = 57, Country = moldova, Name = "Frumușica", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(frumusica);

                var ghidighici = new Location { Id = 58, Country = moldova, Name = "Ghidighici", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(ghidighici);

                var goian = new Location { Id = 59, Country = moldova, Name = "Goian", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(goian);

                var goianulNou = new Location { Id = 60, Country = moldova, Name = "Goianul Nou", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(goianulNou);

                var gratiesti = new Location { Id = 61, Country = moldova, Name = "Grătiești", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(gratiesti);

                var hulboaca = new Location { Id = 62, Country = moldova, Name = "Hulboaca", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(hulboaca);

                var humulesti = new Location { Id = 63, Country = moldova, Name = "Humulești", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(humulesti);

                var revaca = new Location { Id = 64, Country = moldova, Name = "Revaca", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(revaca);

                var stauceni = new Location { Id = 65, Country = moldova, Name = "Stăuceni", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(stauceni);

                var straisteni = new Location { Id = 66, Country = moldova, Name = "Străisteni", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(straisteni);

                var singera = new Location { Id = 67, Country = moldova, Name = "Sîngera", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(singera);

                var tohatin = new Location { Id = 68, Country = moldova, Name = "Tohatin", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(tohatin);

                var truseni = new Location { Id = 69, Country = moldova, Name = "Trușeni", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(truseni);

                var vadulluiVoda = new Location { Id = 70, Country = moldova, Name = "Vadul lui Vodă", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(vadulluiVoda);

                var vatra = new Location { Id = 71, Country = moldova, Name = "Vatra", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(vatra);

                var vaduleni = new Location { Id = 72, Country = moldova, Name = "Văduleni", ParentLocation = municipiulChisinau };
                context.Locations.AddOrUpdate(vaduleni);

                var elizaveta = new Location { Id = 73, Country = moldova, Name = "Elizaveta", ParentLocation = municipiulBalti };
                context.Locations.AddOrUpdate(elizaveta);

                var sadovoe = new Location { Id = 74, Country = moldova, Name = "Sadovoe", ParentLocation = municipiulBalti };
                context.Locations.AddOrUpdate(sadovoe);

                var proteagailovca = new Location { Id = 75, Country = moldova, Name = "Proteagailovca", ParentLocation = municipiulBenderTighina };
                context.Locations.AddOrUpdate(proteagailovca);

                var albinita = new Location { Id = 76, Country = moldova, Name = "Albinița", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(albinita);

                var balmaz = new Location { Id = 77, Country = moldova, Name = "Balmaz", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(balmaz);

                var batic = new Location { Id = 78, Country = moldova, Name = "Batîc", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(batic);

                var beriozchi = new Location { Id = 79, Country = moldova, Name = "Beriozchi", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(beriozchi);

                var botnaresti = new Location { Id = 80, Country = moldova, Name = "Botnărești", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(botnaresti);

                var botnarestiiNoi = new Location { Id = 81, Country = moldova, Name = "Botnăreștii Noi", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(botnarestiiNoi);

                var bulboaca = new Location { Id = 82, Country = moldova, Name = "Bulboaca", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(bulboaca);

                var calfa = new Location { Id = 83, Country = moldova, Name = "Calfa", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(calfa);

                var calfaNoua = new Location { Id = 84, Country = moldova, Name = "Calfa Nouă", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(calfaNoua);

                var chetrosu = new Location { Id = 85, Country = moldova, Name = "Chetrosu", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(chetrosu);

                var chirca = new Location { Id = 86, Country = moldova, Name = "Chirca", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(chirca);

                var ciobanovca = new Location { Id = 87, Country = moldova, Name = "Ciobanovca", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(ciobanovca);

                var cobuscaNoua = new Location { Id = 88, Country = moldova, Name = "Cobusca Nouă", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(cobuscaNoua);

                var cobuscaVeche = new Location { Id = 89, Country = moldova, Name = "Cobusca Veche", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(cobuscaVeche);

                var cretoaia = new Location { Id = 90, Country = moldova, Name = "Crețoaia", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(cretoaia);

                var delacau = new Location { Id = 90, Country = moldova, Name = "Delacău", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(delacau);

                var floreni = new Location { Id = 91, Country = moldova, Name = "Floreni", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(floreni);

                var geamana = new Location { Id = 92, Country = moldova, Name = "Geamăna", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(geamana);

                var guraBicului = new Location { Id = 93, Country = moldova, Name = "Gura Bîcului", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(guraBicului);

                var hirbovat = new Location { Id = 94, Country = moldova, Name = "Hîrbovăț", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(hirbovat);

                var hirbovatulNou = new Location { Id = 95, Country = moldova, Name = "Hîrbovățul Nou", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(hirbovatulNou);

                var larga = new Location { Id = 96, Country = moldova, Name = "Larga", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(larga);

                var maximovca = new Location { Id = 97, Country = moldova, Name = "Maximovca", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(maximovca);

                var mereni = new Location { Id = 98, Country = moldova, Name = "Mereni", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(mereni);

                var mereniiNoi = new Location { Id = 99, Country = moldova, Name = "Merenii Noi", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(mereniiNoi);

                var mirnoe = new Location { Id = 100, Country = moldova, Name = "Mirnoe", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(mirnoe);

                var nicolaevca = new Location { Id = 101, Country = moldova, Name = "Nicolaevca", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(nicolaevca);

                var ochiulRos = new Location { Id = 102, Country = moldova, Name = "Ochiul Roș", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(ochiulRos);

                var picus = new Location { Id = 103, Country = moldova, Name = "Picus", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(picus);

                var puhaceni = new Location { Id = 104, Country = moldova, Name = "Puhăceni", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(puhaceni);

                var roscani = new Location { Id = 105, Country = moldova, Name = "Roșcani", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(roscani);

                var ruseni = new Location { Id = 106, Country = moldova, Name = "Ruseni", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(ruseni);

                var salcia = new Location { Id = 107, Country = moldova, Name = "Salcia", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(salcia);

                var socoleni = new Location { Id = 108, Country = moldova, Name = "Socoleni", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(socoleni);

                var speia = new Location { Id = 109, Country = moldova, Name = "Speia", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(speia);

                var serpeni = new Location { Id = 110, Country = moldova, Name = "Șerpeni", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(serpeni);

                var telita = new Location { Id = 111, Country = moldova, Name = "Telița", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(telita);

                var telitaNoua = new Location { Id = 112, Country = moldova, Name = "TelițaNouă", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(telitaNoua);

                var todiresti = new Location { Id = 113, Country = moldova, Name = "Todirești", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(todiresti);

                var troitaNoua = new Location { Id = 114, Country = moldova, Name = "Troița Nouă", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(troitaNoua);

                var tintareni = new Location { Id = 115, Country = moldova, Name = "Țînțăreni", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(tintareni);

                var varnita = new Location { Id = 116, Country = moldova, Name = "Varnița", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(varnita);

                var zolotievca = new Location { Id = 117, Country = moldova, Name = "Zolotievca", ParentLocation = aneniiNoi };
                context.Locations.AddOrUpdate(zolotievca);

                var abaclia = new Location { Id = 118, Country = moldova, Name = "Abaclia", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(abaclia);

                var bascalia = new Location { Id = 119, Country = moldova, Name = "Bașcalia", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(bascalia);

                var bogdanovca = new Location { Id = 120, Country = moldova, Name = "Bogdanovca", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(bogdanovca);

                var carabetovca = new Location { Id = 121, Country = moldova, Name = "Carabetovca", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(carabetovca);

                var carabiber = new Location { Id = 122, Country = moldova, Name = "Carabiber", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(carabiber);

                var iordanovca = new Location { Id = 123, Country = moldova, Name = "Iordanovca", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(iordanovca);

                var iserlia = new Location { Id = 124, Country = moldova, Name = "Iserlia", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(iserlia);

                var ivanovca = new Location { Id = 125, Country = moldova, Name = "Ivanovca	", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(ivanovca);

                var sadaclia = new Location { Id = 126, Country = moldova, Name = "Sadaclia", ParentLocation = basarabeasca };
                context.Locations.AddOrUpdate(sadaclia);

                var balasinesti = new Location { Id = 127, Country = moldova, Name = "Balasinești", ParentLocation = briceni };
                context.Locations.AddOrUpdate(balasinesti);

                var balcauti = new Location { Id = 128, Country = moldova, Name = "Bălcăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(balcauti);

                var beleavinti = new Location { Id = 129, Country = moldova, Name = "Beleavinți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(beleavinti);

                var berlinti = new Location { Id = 130, Country = moldova, Name = "Berlinți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(berlinti);

                var bezeda = new Location { Id = 131, Country = moldova, Name = "Bezeda", ParentLocation = briceni };
                context.Locations.AddOrUpdate(bezeda);

                var bocicauti = new Location { Id = 132, Country = moldova, Name = "Bocicăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(bocicauti);

                var bogdanesti = new Location { Id = 133, Country = moldova, Name = "Bogdănești", ParentLocation = briceni };
                context.Locations.AddOrUpdate(bogdanesti);

                var bulboacaB = new Location { Id = 134, Country = moldova, Name = "Bulboaca", ParentLocation = briceni };
                context.Locations.AddOrUpdate(bulboacaB);

                var caracuseniiVechi = new Location { Id = 135, Country = moldova, Name = "Caracușenii Vechi", ParentLocation = briceni };
                context.Locations.AddOrUpdate(caracuseniiVechi);

                var caracuseniiNoi = new Location { Id = 136, Country = moldova, Name = "Caracușenii Noi", ParentLocation = briceni };
                context.Locations.AddOrUpdate(caracuseniiNoi);

                var chirilovca = new Location { Id = 137, Country = moldova, Name = "Chirilovca", ParentLocation = briceni };
                context.Locations.AddOrUpdate(chirilovca);

                var colicauti = new Location { Id = 138, Country = moldova, Name = "Colicăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(colicauti);

                var corjeuti = new Location { Id = 139, Country = moldova, Name = "Corjeuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(corjeuti);

                var coteala = new Location { Id = 140, Country = moldova, Name = "Coteala", ParentLocation = briceni };
                context.Locations.AddOrUpdate(coteala);

                var cotiujeni = new Location { Id = 141, Country = moldova, Name = "Cotiujeni", ParentLocation = briceni };
                context.Locations.AddOrUpdate(cotiujeni);

                var criva = new Location { Id = 142, Country = moldova, Name = "Criva", ParentLocation = briceni };
                context.Locations.AddOrUpdate(criva);

                var drepcauti = new Location { Id = 143, Country = moldova, Name = "Drepcăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(drepcauti);

                var grimesti = new Location { Id = 144, Country = moldova, Name = "Grimești", ParentLocation = briceni };
                context.Locations.AddOrUpdate(grimesti);

                var grimancauti = new Location { Id = 145, Country = moldova, Name = "Grimăncăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(grimancauti);

                var groznita = new Location { Id = 146, Country = moldova, Name = "Groznița", ParentLocation = briceni };
                context.Locations.AddOrUpdate(groznita);

                var halahoradeJos = new Location { Id = 147, Country = moldova, Name = "Halahora de Jos", ParentLocation = briceni };
                context.Locations.AddOrUpdate(halahoradeJos);

                var halahoradeSus = new Location { Id = 148, Country = moldova, Name = "Halahora de Sus", ParentLocation = briceni };
                context.Locations.AddOrUpdate(halahoradeSus);

                var hlina = new Location { Id = 149, Country = moldova, Name = "Hlina", ParentLocation = briceni };
                context.Locations.AddOrUpdate(hlina);

                var largaB = new Location { Id = 150, Country = moldova, Name = "Larga", ParentLocation = briceni };
                context.Locations.AddOrUpdate(largaB);

                var lipcani = new Location { Id = 151, Country = moldova, Name = "Lipcani", ParentLocation = briceni };
                context.Locations.AddOrUpdate(lipcani);

                var marcauti = new Location { Id = 152, Country = moldova, Name = "Mărcăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(marcauti);

                var marcautiiNoi = new Location { Id = 153, Country = moldova, Name = "Mărcăuții Noi", ParentLocation = briceni };
                context.Locations.AddOrUpdate(marcautiiNoi);

                var medveja = new Location { Id = 154, Country = moldova, Name = "Medveja", ParentLocation = briceni };
                context.Locations.AddOrUpdate(medveja);

                var mihaileni = new Location { Id = 155, Country = moldova, Name = "Mihăileni", ParentLocation = briceni };
                context.Locations.AddOrUpdate(mihaileni);

                var pavlovca = new Location { Id = 156, Country = moldova, Name = "Pavlovca", ParentLocation = briceni };
                context.Locations.AddOrUpdate(pavlovca);

                var pererita = new Location { Id = 157, Country = moldova, Name = "Pererîta", ParentLocation = briceni };
                context.Locations.AddOrUpdate(pererita);

                var sloboziaMedveja = new Location { Id = 158, Country = moldova, Name = "Slobozia-Medveja", ParentLocation = briceni };
                context.Locations.AddOrUpdate(sloboziaMedveja);

                var sloboziaSirauti = new Location { Id = 159, Country = moldova, Name = "Slobozia-Șirăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(sloboziaSirauti);

                var sirauti = new Location { Id = 160, Country = moldova, Name = "Șirăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(sirauti);

                var tabani = new Location { Id = 161, Country = moldova, Name = "Tabani", ParentLocation = briceni };
                context.Locations.AddOrUpdate(tabani);

                var tetcani = new Location { Id = 162, Country = moldova, Name = "Tețcani", ParentLocation = briceni };
                context.Locations.AddOrUpdate(tetcani);

                var trebisauti = new Location { Id = 163, Country = moldova, Name = "Trebisăuți", ParentLocation = briceni };
                context.Locations.AddOrUpdate(trebisauti);

                var trestieni = new Location { Id = 164, Country = moldova, Name = "Trestieni", ParentLocation = briceni };
                context.Locations.AddOrUpdate(trestieni);

                var alexandruIoanCuza = new Location { Id = 164, Country = moldova, Name = "Alexandru Ioan Cuza", ParentLocation = cahul };
                context.Locations.AddOrUpdate(alexandruIoanCuza);

                var alexanderfeld = new Location { Id = 165, Country = moldova, Name = "Alexanderfeld", ParentLocation = cahul };
                context.Locations.AddOrUpdate(alexanderfeld);

                var andrusuldeJos = new Location { Id = 166, Country = moldova, Name = "Andrușul de Jos", ParentLocation = cahul };
                context.Locations.AddOrUpdate(andrusuldeJos);

                var andrusuldeSus = new Location { Id = 167, Country = moldova, Name = "Andrușul de Sus", ParentLocation = cahul };
                context.Locations.AddOrUpdate(andrusuldeSus);

                var badiculMoldovenesc = new Location { Id = 168, Country = moldova, Name = "Badicul Moldovenesc", ParentLocation = cahul };
                context.Locations.AddOrUpdate(badiculMoldovenesc);

                var baurciMoldoveni = new Location { Id = 169, Country = moldova, Name = "Baurci-Moldoveni", ParentLocation = cahul };
                context.Locations.AddOrUpdate(baurciMoldoveni);

                var borceag = new Location { Id = 170, Country = moldova, Name = "Borceag", ParentLocation = cahul };
                context.Locations.AddOrUpdate(borceag);

                var bucuria = new Location { Id = 171, Country = moldova, Name = "Bucuria", ParentLocation = cahul };
                context.Locations.AddOrUpdate(bucuria);

                var burlacu = new Location { Id = 172, Country = moldova, Name = "Burlacu", ParentLocation = cahul };
                context.Locations.AddOrUpdate(burlacu);

                var burlaceni = new Location { Id = 173, Country = moldova, Name = "Burlăceni", ParentLocation = cahul };
                context.Locations.AddOrUpdate(burlaceni);

                var brinza = new Location { Id = 174, Country = moldova, Name = "Brînza", ParentLocation = cahul };
                context.Locations.AddOrUpdate(brinza);

                var chioseliaMare = new Location { Id = 175, Country = moldova, Name = "Chioselia Mare	", ParentLocation = cahul };
                context.Locations.AddOrUpdate(chioseliaMare);

                var chircani = new Location { Id = 176, Country = moldova, Name = "Chircani", ParentLocation = cahul };
                context.Locations.AddOrUpdate(chircani);

                var cislitaPrut = new Location { Id = 177, Country = moldova, Name = "Cîșlița-Prut", ParentLocation = cahul };
                context.Locations.AddOrUpdate(cislitaPrut);

                var colibasi = new Location { Id = 178, Country = moldova, Name = "Colibași", ParentLocation = cahul };
                context.Locations.AddOrUpdate(colibasi);

                var cotihana = new Location { Id = 179, Country = moldova, Name = "Cotihana", ParentLocation = cahul };
                context.Locations.AddOrUpdate(cotihana);

                var crihanaVeche = new Location { Id = 180, Country = moldova, Name = "Crihana Veche", ParentLocation = cahul };
                context.Locations.AddOrUpdate(crihanaVeche);

                var cucoara = new Location { Id = 181, Country = moldova, Name = "Cucoara", ParentLocation = cahul };
                context.Locations.AddOrUpdate(cucoara);

                var doina = new Location { Id = 182, Country = moldova, Name = "Doina", ParentLocation = cahul };
                context.Locations.AddOrUpdate(doina);

                var frumusicaC = new Location { Id = 183, Country = moldova, Name = "Frumușica", ParentLocation = cahul };
                context.Locations.AddOrUpdate(frumusicaC);

                var gavanoasa = new Location { Id = 184, Country = moldova, Name = "Găvănoasa", ParentLocation = cahul };
                context.Locations.AddOrUpdate(gavanoasa);

                var giurgiulesti = new Location { Id = 185, Country = moldova, Name = "Giurgiulești", ParentLocation = cahul };
                context.Locations.AddOrUpdate(giurgiulesti);

                var greceni = new Location { Id = 186, Country = moldova, Name = "Greceni", ParentLocation = cahul };
                context.Locations.AddOrUpdate(greceni);

                var huluboaia = new Location { Id = 187, Country = moldova, Name = "Huluboaia", ParentLocation = cahul };
                context.Locations.AddOrUpdate(huluboaia);

                var hutulu = new Location { Id = 188, Country = moldova, Name = "Hutulu", ParentLocation = cahul };
                context.Locations.AddOrUpdate(hutulu);

                var iasnaiaPoleana = new Location { Id = 189, Country = moldova, Name = "Iasnaia Poleana", ParentLocation = cahul };
                context.Locations.AddOrUpdate(iasnaiaPoleana);

                var iujnoe = new Location { Id = 190, Country = moldova, Name = "Iujnoe", ParentLocation = cahul };
                context.Locations.AddOrUpdate(iujnoe);

                var largaNoua = new Location { Id = 191, Country = moldova, Name = "Larga Nouă", ParentLocation = cahul };
                context.Locations.AddOrUpdate(largaNoua);

                var largaVeche = new Location { Id = 192, Country = moldova, Name = "Larga Veche", ParentLocation = cahul };
                context.Locations.AddOrUpdate(largaVeche);

                var lebedenco = new Location { Id = 193, Country = moldova, Name = "Lebedenco", ParentLocation = cahul };
                context.Locations.AddOrUpdate(lebedenco);

                var lopatica = new Location { Id = 194, Country = moldova, Name = "Lopățica", ParentLocation = cahul };
                context.Locations.AddOrUpdate(lopatica);

                var lucesti = new Location { Id = 195, Country = moldova, Name = "Lucești", ParentLocation = cahul };
                context.Locations.AddOrUpdate(lucesti);

                var manta = new Location { Id = 196, Country = moldova, Name = "Manta", ParentLocation = cahul };
                context.Locations.AddOrUpdate(manta);

                var moscovei = new Location { Id = 197, Country = moldova, Name = "Moscovei", ParentLocation = cahul };
                context.Locations.AddOrUpdate(moscovei);

                var nicolaevcaC = new Location { Id = 198, Country = moldova, Name = "Nicolaevca", ParentLocation = cahul };
                context.Locations.AddOrUpdate(nicolaevcaC);

                var paicu = new Location { Id = 199, Country = moldova, Name = "Paicu", ParentLocation = cahul };
                context.Locations.AddOrUpdate(paicu);

                var pascani = new Location { Id = 200, Country = moldova, Name = "Pașcani", ParentLocation = cahul };
                context.Locations.AddOrUpdate(pascani);

                var pelinei = new Location { Id = 201, Country = moldova, Name = "Pelinei", ParentLocation = cahul };
                context.Locations.AddOrUpdate(pelinei);

                var rosu = new Location { Id = 202, Country = moldova, Name = "Roșu", ParentLocation = cahul };
                context.Locations.AddOrUpdate(rosu);

                var rumeantev = new Location { Id = 203, Country = moldova, Name = "Rumeanțev", ParentLocation = cahul };
                context.Locations.AddOrUpdate(rumeantev);

                var satuc = new Location { Id = 204, Country = moldova, Name = "Sătuc", ParentLocation = cahul };
                context.Locations.AddOrUpdate(satuc);

                var sloboziaMare = new Location { Id = 205, Country = moldova, Name = "Slobozia Mare", ParentLocation = cahul };
                context.Locations.AddOrUpdate(sloboziaMare);

                var spicoasa = new Location { Id = 206, Country = moldova, Name = "Spicoasa", ParentLocation = cahul };
                context.Locations.AddOrUpdate(spicoasa);

                var taracliadeSalcie = new Location { Id = 207, Country = moldova, Name = "Taraclia de Salcie", ParentLocation = cahul };
                context.Locations.AddOrUpdate(taracliadeSalcie);

                var tartauldeSalcie = new Location { Id = 208, Country = moldova, Name = "Tartaul de Salcie", ParentLocation = cahul };
                context.Locations.AddOrUpdate(tartauldeSalcie);

                var tataresti = new Location { Id = 209, Country = moldova, Name = "Tătărești", ParentLocation = cahul };
                context.Locations.AddOrUpdate(tataresti);

                var tretesti = new Location { Id = 210, Country = moldova, Name = "Tretești", ParentLocation = cahul };
                context.Locations.AddOrUpdate(tretesti);

                var trifestiiNoi = new Location { Id = 211, Country = moldova, Name = "Trifeștii Noi", ParentLocation = cahul };
                context.Locations.AddOrUpdate(trifestiiNoi);

                var tudoresti = new Location { Id = 212, Country = moldova, Name = "Tudorești", ParentLocation = cahul };
                context.Locations.AddOrUpdate(tudoresti);

                var ursoaia = new Location { Id = 213, Country = moldova, Name = "Ursoaia", ParentLocation = cahul };
                context.Locations.AddOrUpdate(ursoaia);

                var vadulluiIsac = new Location { Id = 214, Country = moldova, Name = "Vadul lui Isac", ParentLocation = cahul };
                context.Locations.AddOrUpdate(vadulluiIsac);

                var valeni = new Location { Id = 215, Country = moldova, Name = "Văleni", ParentLocation = cahul };
                context.Locations.AddOrUpdate(valeni);

                var vladimirovca = new Location { Id = 216, Country = moldova, Name = "Vladimirovca", ParentLocation = cahul };
                context.Locations.AddOrUpdate(vladimirovca);

                var zirnesti = new Location { Id = 217, Country = moldova, Name = "Zîrnești", ParentLocation = cahul };
                context.Locations.AddOrUpdate(zirnesti);

                var caterinovca = new Location { Id = 218, Country = moldova, Name = "Caterinovca", ParentLocation = camenca };
                context.Locations.AddOrUpdate(caterinovca);

                var crasniiOcteabri = new Location { Id = 219, Country = moldova, Name = "Crasnîi Octeabri", ParentLocation = camenca };
                context.Locations.AddOrUpdate(crasniiOcteabri);

                var cuzmin = new Location { Id = 220, Country = moldova, Name = "Cuzmin", ParentLocation = camenca };
                context.Locations.AddOrUpdate(cuzmin);

                var hristovaia = new Location { Id = 221, Country = moldova, Name = "Hristovaia", ParentLocation = camenca };
                context.Locations.AddOrUpdate(hristovaia);

                var hrusca = new Location { Id = 222, Country = moldova, Name = "Hrușca", ParentLocation = camenca };
                context.Locations.AddOrUpdate(hrusca);

                var podoima = new Location { Id = 223, Country = moldova, Name = "Podoima", ParentLocation = camenca };
                context.Locations.AddOrUpdate(podoima);

                var rascov = new Location { Id = 224, Country = moldova, Name = "Rașcov", ParentLocation = camenca };
                context.Locations.AddOrUpdate(rascov);

                var rotari = new Location { Id = 225, Country = moldova, Name = "Rotari", ParentLocation = camenca };
                context.Locations.AddOrUpdate(rotari);

                var severinovca = new Location { Id = 226, Country = moldova, Name = "Severinovca", ParentLocation = camenca };
                context.Locations.AddOrUpdate(severinovca);

                var valeaAdinca = new Location { Id = 228, Country = moldova, Name = "Valea Adîncă", ParentLocation = camenca };
                context.Locations.AddOrUpdate(valeaAdinca);

                var bahmut = new Location { Id = 229, Country = moldova, Name = "Bahmut", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(bahmut);

                var bahu = new Location { Id = 230, Country = moldova, Name = "Bahu", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(bahu);

                var bravicea = new Location { Id = 231, Country = moldova, Name = "Bravicea", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(bravicea);

                var buda = new Location { Id = 232, Country = moldova, Name = "Buda", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(buda);

                var bularda = new Location { Id = 233, Country = moldova, Name = "Bularda", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(bularda);

                var cabaiesti = new Location { Id = 234, Country = moldova, Name = "Căbăiești", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(cabaiesti);

                var dereneu = new Location { Id = 235, Country = moldova, Name = "Dereneu", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(dereneu);

                var duma = new Location { Id = 236, Country = moldova, Name = "Duma", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(duma);

                var frumoasa = new Location { Id = 237, Country = moldova, Name = "Frumoasa", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(frumoasa);

                var hirova = new Location { Id = 238, Country = moldova, Name = "Hirova", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(hirova);

                var hirbovatC = new Location { Id = 239, Country = moldova, Name = "Hîrbovăț", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(hirbovatC);

                var hirjauca = new Location { Id = 240, Country = moldova, Name = "Hîrjauca", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(hirjauca);

                var hoginesti = new Location { Id = 241, Country = moldova, Name = "Hoginești", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(hoginesti);

                var horodiste = new Location { Id = 242, Country = moldova, Name = "Horodiște", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(horodiste);

                var leordoaia = new Location { Id = 243, Country = moldova, Name = "Leordoaia", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(leordoaia);

                var meleseni = new Location { Id = 244, Country = moldova, Name = "Meleșeni", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(meleseni);

                var mindra = new Location { Id = 245, Country = moldova, Name = "Mîndra", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(mindra);

                var niscani = new Location { Id = 246, Country = moldova, Name = "Nișcani", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(niscani);

                var novaci = new Location { Id = 247, Country = moldova, Name = "Novaci", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(novaci);

                var oniscani = new Location { Id = 248, Country = moldova, Name = "Onișcani", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(oniscani);

                var oricova = new Location { Id = 249, Country = moldova, Name = "Oricova", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(oricova);

                var palanca = new Location { Id = 250, Country = moldova, Name = "Palanca", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(palanca);

                var parcani = new Location { Id = 251, Country = moldova, Name = "Parcani", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(parcani);

                var paulesti = new Location { Id = 252, Country = moldova, Name = "Păulești", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(paulesti);

                var peticeni = new Location { Id = 253, Country = moldova, Name = "Peticeni", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(peticeni);

                var pitusca = new Location { Id = 254, Country = moldova, Name = "Pitușca", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(pitusca);

                var pirjolteni = new Location { Id = 255, Country = moldova, Name = "Pîrjolteni", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(pirjolteni);

                var podulLung = new Location { Id = 256, Country = moldova, Name = "Podul Lung", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(podulLung);

                var raciula = new Location { Id = 257, Country = moldova, Name = "Răciula", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(raciula);

                var radeni = new Location { Id = 258, Country = moldova, Name = "Rădeni", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(radeni);

                var sadova = new Location { Id = 259, Country = moldova, Name = "Sadova", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(sadova);

                var saseni = new Location { Id = 260, Country = moldova, Name = "Săseni", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(saseni);

                var schinoasa = new Location { Id = 261, Country = moldova, Name = "Schinoasa", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(schinoasa);

                var selisteaNoua = new Location { Id = 262, Country = moldova, Name = "Seliștea Nouă", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(selisteaNoua);

                var sipoteni = new Location { Id = 263, Country = moldova, Name = "Sipoteni", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(sipoteni);

                var sverida = new Location { Id = 264, Country = moldova, Name = "Sverida", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(sverida);

                var temeleuti = new Location { Id = 265, Country = moldova, Name = "Temeleuți", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(temeleuti);

                var tuzara = new Location { Id = 266, Country = moldova, Name = "Tuzara", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(tuzara);

                var tibirica = new Location { Id = 267, Country = moldova, Name = "Țibirica", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(tibirica);

                var ursari = new Location { Id = 268, Country = moldova, Name = "Ursari", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(ursari);

                var valcinet = new Location { Id = 269, Country = moldova, Name = "Vălcineț", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(valcinet);

                var varzarestiiNoi = new Location { Id = 270, Country = moldova, Name = "Vărzăreștii Noi", ParentLocation = calarasi };
                context.Locations.AddOrUpdate(varzarestiiNoi);

                var acui = new Location { Id = 271, Country = moldova, Name = "Acui", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(acui);

                var alexandrovca = new Location { Id = 272, Country = moldova, Name = "Alexandrovca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(alexandrovca);

                var antonesti = new Location { Id = 273, Country = moldova, Name = "Antonești", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(antonesti);

                var baimaclia = new Location { Id = 274, Country = moldova, Name = "Baimaclia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(baimaclia);

                var bobocica = new Location { Id = 275, Country = moldova, Name = "Bobocica", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(bobocica);

                var cania = new Location { Id = 276, Country = moldova, Name = "Cania", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(cania);

                var capaclia = new Location { Id = 277, Country = moldova, Name = "Capaclia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(capaclia);

                var chioselia = new Location { Id = 278, Country = moldova, Name = "Chioselia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(chioselia);

                var ciobalaccia = new Location { Id = 279, Country = moldova, Name = "Ciobalaccia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(ciobalaccia);

                var ciietu = new Location { Id = 280, Country = moldova, Name = "Cîietu", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(ciietu);

                var cirpesti = new Location { Id = 281, Country = moldova, Name = "Cîrpești", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(cirpesti);

                var cisla = new Location { Id = 282, Country = moldova, Name = "Cîșla", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(cisla);

                var craciun = new Location { Id = 283, Country = moldova, Name = "Crăciun", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(craciun);

                var cociulia = new Location { Id = 284, Country = moldova, Name = "Cociulia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(cociulia);

                var constantinesti = new Location { Id = 285, Country = moldova, Name = "Constantinești", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(constantinesti);

                var costangalia = new Location { Id = 286, Country = moldova, Name = "Coștangalia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(costangalia);

                var dimitrova = new Location { Id = 287, Country = moldova, Name = "Dimitrova", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(dimitrova);

                var enichioi = new Location { Id = 288, Country = moldova, Name = "Enichioi", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(enichioi);

                var flocoasa = new Location { Id = 289, Country = moldova, Name = "Flocoasa", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(flocoasa);

                var floricica = new Location { Id = 290, Country = moldova, Name = "Floricica", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(floricica);

                var ghioltosu = new Location { Id = 291, Country = moldova, Name = "Ghioltosu", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(ghioltosu);

                var gotesti = new Location { Id = 292, Country = moldova, Name = "Gotești", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(gotesti);

                var haragis = new Location { Id = 293, Country = moldova, Name = "Haragîș", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(haragis);

                var hanaseni = new Location { Id = 294, Country = moldova, Name = "Hănăseni", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(hanaseni);

                var hirtop = new Location { Id = 295, Country = moldova, Name = "Hîrtop", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(hirtop);

                var iepureni = new Location { Id = 296, Country = moldova, Name = "Iepureni", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(iepureni);

                var larguta = new Location { Id = 297, Country = moldova, Name = "Lărguța", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(larguta);

                var leca = new Location { Id = 298, Country = moldova, Name = "Leca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(leca);

                var lingura = new Location { Id = 299, Country = moldova, Name = "Lingura", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(lingura);

                var pleseni = new Location { Id = 300, Country = moldova, Name = "Pleșeni", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(pleseni);

                var plopi = new Location { Id = 301, Country = moldova, Name = "Plopi", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(plopi);

                var popovca = new Location { Id = 302, Country = moldova, Name = "Popovca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(popovca);

                var porumbesti = new Location { Id = 303, Country = moldova, Name = "Porumbești", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(porumbesti);

                var sadic = new Location { Id = 304, Country = moldova, Name = "Sadîc", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(sadic);

                var stoianovca = new Location { Id = 305, Country = moldova, Name = "Stoianovca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(stoianovca);

                var suhat = new Location { Id = 306, Country = moldova, Name = "Suhat", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(suhat);

                var samalia = new Location { Id = 307, Country = moldova, Name = "Șamalia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(samalia);

                var sofranovca = new Location { Id = 308, Country = moldova, Name = "Șofranovca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(sofranovca);

                var taracliaP = new Location { Id = 309, Country = moldova, Name = "Taraclia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(taracliaP);

                var taracliaS = new Location { Id = 310, Country = moldova, Name = "Taraclia", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(taracliaS);

                var tartaul = new Location { Id = 311, Country = moldova, Name = "Tartaul", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(tartaul);

                var tataraseni = new Location { Id = 312, Country = moldova, Name = "Tătărășeni", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(tataraseni);

                var toceni = new Location { Id = 313, Country = moldova, Name = "Toceni", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(toceni);

                var tarancuta = new Location { Id = 314, Country = moldova, Name = "Țărăncuța", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(tarancuta);

                var tiganca = new Location { Id = 315, Country = moldova, Name = "Țiganca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(tiganca);

                var tigancaNoua = new Location { Id = 316, Country = moldova, Name = "Țiganca Nouă", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(tigancaNoua);

                var tolica = new Location { Id = 317, Country = moldova, Name = "Țolica", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(tolica);

                var victorovca = new Location { Id = 318, Country = moldova, Name = "Victorovca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(victorovca);

                var visniovca = new Location { Id = 319, Country = moldova, Name = "Vișniovca", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(visniovca);

                var vilcele = new Location { Id = 320, Country = moldova, Name = "Vîlcele", ParentLocation = cantemir };
                context.Locations.AddOrUpdate(vilcele);

                var baccealia = new Location { Id = 321, Country = moldova, Name = "Baccealia", ParentLocation = causeni };
                context.Locations.AddOrUpdate(baccealia);

                var baurci = new Location { Id = 322, Country = moldova, Name = "Baurci", ParentLocation = causeni };
                context.Locations.AddOrUpdate(baurci);

                var cainari = new Location { Id = 323, Country = moldova, Name = "Căinari", ParentLocation = causeni };
                context.Locations.AddOrUpdate(cainari);

                var chircaiesti = new Location { Id = 324, Country = moldova, Name = "Chircăiești", ParentLocation = causeni };
                context.Locations.AddOrUpdate(chircaiesti);

                var chircaiestiiNoi = new Location { Id = 325, Country = moldova, Name = "Chircăieștii Noi", ParentLocation = causeni };
                context.Locations.AddOrUpdate(chircaiestiiNoi);

                var chitcani = new Location { Id = 326, Country = moldova, Name = "Chițcani", ParentLocation = causeni };
                context.Locations.AddOrUpdate(chitcani);

                var ciuflesti = new Location { Id = 327, Country = moldova, Name = "Ciuflești", ParentLocation = causeni };
                context.Locations.AddOrUpdate(ciuflesti);

                var cirnateni = new Location { Id = 328, Country = moldova, Name = "Cîrnățeni", ParentLocation = causeni };
                context.Locations.AddOrUpdate(cirnateni);

                var cirnateniiNoi = new Location { Id = 329, Country = moldova, Name = "Cîrnățenii Noi", ParentLocation = causeni };
                context.Locations.AddOrUpdate(cirnateniiNoi);

                var constantinovca = new Location { Id = 330, Country = moldova, Name = "Constantinovca", ParentLocation = causeni };
                context.Locations.AddOrUpdate(constantinovca);

                var copanca = new Location { Id = 331, Country = moldova, Name = "Copanca", ParentLocation = causeni };
                context.Locations.AddOrUpdate(copanca);

                var coscalia = new Location { Id = 332, Country = moldova, Name = "Coșcalia", ParentLocation = causeni };
                context.Locations.AddOrUpdate(coscalia);

                var cremenciug = new Location { Id = 333, Country = moldova, Name = "Cremenciug", ParentLocation = causeni };
                context.Locations.AddOrUpdate(cremenciug);

                var firladeni = new Location { Id = 334, Country = moldova, Name = "Fîrlădeni", ParentLocation = causeni };
                context.Locations.AddOrUpdate(firladeni);

                var firladeniiNoi = new Location { Id = 335, Country = moldova, Name = "Fîrlădenii Noi", ParentLocation = causeni };
                context.Locations.AddOrUpdate(firladeniiNoi);

                var florica = new Location { Id = 336, Country = moldova, Name = "Florica", ParentLocation = causeni };
                context.Locations.AddOrUpdate(florica);

                var gisca = new Location { Id = 337, Country = moldova, Name = "Gîsca", ParentLocation = causeni };
                context.Locations.AddOrUpdate(gisca);

                var gradinita = new Location { Id = 338, Country = moldova, Name = "Grădinița", ParentLocation = causeni };
                context.Locations.AddOrUpdate(gradinita);

                var grigorievca = new Location { Id = 339, Country = moldova, Name = "Grigorievca", ParentLocation = causeni };
                context.Locations.AddOrUpdate(grigorievca);

                var hagimus = new Location { Id = 340, Country = moldova, Name = "Hagimus", ParentLocation = causeni };
                context.Locations.AddOrUpdate(hagimus);

                var leuntea = new Location { Id = 341, Country = moldova, Name = "Leuntea", ParentLocation = causeni };
                context.Locations.AddOrUpdate(leuntea);

                var mariancadeSus = new Location { Id = 342, Country = moldova, Name = "Marianca de Sus", ParentLocation = causeni };
                context.Locations.AddOrUpdate(mariancadeSus);

                var merenesti = new Location { Id = 343, Country = moldova, Name = "Merenești", ParentLocation = causeni };
                context.Locations.AddOrUpdate(merenesti);

                var opaci = new Location { Id = 344, Country = moldova, Name = "Opaci", ParentLocation = causeni };
                context.Locations.AddOrUpdate(opaci);

                var pervomaisc = new Location { Id = 345, Country = moldova, Name = "Pervomaisc", ParentLocation = causeni };
                context.Locations.AddOrUpdate(pervomaisc);

                var plop = new Location { Id = 346, Country = moldova, Name = "Plop", ParentLocation = causeni };
                context.Locations.AddOrUpdate(plop);

                var plopStiubei = new Location { Id = 347, Country = moldova, Name = "Plop-Știubei", ParentLocation = causeni };
                context.Locations.AddOrUpdate(plopStiubei);

                var saiti = new Location { Id = 348, Country = moldova, Name = "Săiți", ParentLocation = causeni };
                context.Locations.AddOrUpdate(saiti);

                var salcuta = new Location { Id = 349, Country = moldova, Name = "Sălcuța", ParentLocation = causeni };
                context.Locations.AddOrUpdate(salcuta);

                var salcutaNoua = new Location { Id = 350, Country = moldova, Name = "Sălcuța Nouă", ParentLocation = causeni };
                context.Locations.AddOrUpdate(salcutaNoua);

                var surchiceni = new Location { Id = 351, Country = moldova, Name = "Surchiceni", ParentLocation = causeni };
                context.Locations.AddOrUpdate(surchiceni);

                var stefanesti = new Location { Id = 352, Country = moldova, Name = "Ștefănești", ParentLocation = causeni };
                context.Locations.AddOrUpdate(stefanesti);

                var tanatari = new Location { Id = 353, Country = moldova, Name = "Tănătari", ParentLocation = causeni };
                context.Locations.AddOrUpdate(tanatari);

                var tanatariiNoi = new Location { Id = 354, Country = moldova, Name = "Tănătarii Noi", ParentLocation = causeni };
                context.Locations.AddOrUpdate(tanatariiNoi);

                var tocuz = new Location { Id = 355, Country = moldova, Name = "Tocuz", ParentLocation = causeni };
                context.Locations.AddOrUpdate(tocuz);

                var tricolici = new Location { Id = 356, Country = moldova, Name = "Tricolici", ParentLocation = causeni };
                context.Locations.AddOrUpdate(tricolici);

                var ucrainca = new Location { Id = 357, Country = moldova, Name = "Ucrainca", ParentLocation = causeni };
                context.Locations.AddOrUpdate(ucrainca);

                var ursoaiaT = new Location { Id = 358, Country = moldova, Name = "Ursoaia", ParentLocation = causeni };
                context.Locations.AddOrUpdate(ursoaiaT);

                var ursoaiaNoua = new Location { Id = 359, Country = moldova, Name = "Ursoaia Nouă", ParentLocation = causeni };
                context.Locations.AddOrUpdate(ursoaiaNoua);

                var valeaVerde = new Location { Id = 360, Country = moldova, Name = "Valea Verde", ParentLocation = causeni };
                context.Locations.AddOrUpdate(valeaVerde);

                var zahorna = new Location { Id = 361, Country = moldova, Name = "Zahorna", ParentLocation = causeni };
                context.Locations.AddOrUpdate(zahorna);

                var zaim = new Location { Id = 362, Country = moldova, Name = "Zaim", ParentLocation = causeni };
                context.Locations.AddOrUpdate(zaim);

                var zviozdocica = new Location { Id = 363, Country = moldova, Name = "Zviozdocica", ParentLocation = causeni };
                context.Locations.AddOrUpdate(zviozdocica);

                var albina = new Location { Id = 364, Country = moldova, Name = "Albina", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(albina);

                var artimonovca = new Location { Id = 365, Country = moldova, Name = "Artimonovca", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(artimonovca);

                var batir = new Location { Id = 366, Country = moldova, Name = "Batîr", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(batir);

                var bogdanovcaNoua = new Location { Id = 367, Country = moldova, Name = "Bogdanovca Nouă", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(bogdanovcaNoua);

                var bogdanovcaVeche = new Location { Id = 368, Country = moldova, Name = "Bogdanovca Veche", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(bogdanovcaVeche);

                var cenac = new Location { Id = 369, Country = moldova, Name = "Cenac", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(cenac);

                var ciucurMingir = new Location { Id = 370, Country = moldova, Name = "Ciucur-Mingir", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(ciucurMingir);

                var codreni = new Location { Id = 371, Country = moldova, Name = "Codreni", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(codreni);

                var dimitrovca = new Location { Id = 372, Country = moldova, Name = "Dimitrovca", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(dimitrovca);

                var ecaterinovca = new Location { Id = 373, Country = moldova, Name = "Ecaterinovca", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(ecaterinovca);

                var fetita = new Location { Id = 374, Country = moldova, Name = "Fetița", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(fetita);

                var gradiste = new Location { Id = 375, Country = moldova, Name = "Gradiște", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(gradiste);

                var guraGalbenei = new Location { Id = 376, Country = moldova, Name = "Gura Galbenei", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(guraGalbenei);

                var hirtopC = new Location { Id = 377, Country = moldova, Name = "Hîrtop", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(hirtopC);

                var ialpug = new Location { Id = 378, Country = moldova, Name = "Ialpug", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(ialpug);

                var ialpujeni = new Location { Id = 379, Country = moldova, Name = "Ialpujeni", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(ialpujeni);

                var iurievca = new Location { Id = 380, Country = moldova, Name = "Iurievca", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(iurievca);

                var ivanovcaNoua = new Location { Id = 381, Country = moldova, Name = "Ivanovca Nouă", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(ivanovcaNoua);

                var javgur = new Location { Id = 382, Country = moldova, Name = "Javgur", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(javgur);

                var lipoveni = new Location { Id = 383, Country = moldova, Name = "Lipoveni", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(lipoveni);

                var marienfeld = new Location { Id = 384, Country = moldova, Name = "Marienfeld", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(marienfeld);

                var maximeni = new Location { Id = 385, Country = moldova, Name = "Maximeni", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(maximeni);

                var mereniA = new Location { Id = 386, Country = moldova, Name = "Mereni", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(mereniA);

                var mihailovca = new Location { Id = 387, Country = moldova, Name = "Mihailovca", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(mihailovca);

                var munteni = new Location { Id = 388, Country = moldova, Name = "Munteni", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(munteni);

                var porumbrei = new Location { Id = 389, Country = moldova, Name = "Porumbrei", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(porumbrei);

                var prisaca = new Location { Id = 390, Country = moldova, Name = "Prisaca", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(prisaca);

                var sagaidac = new Location { Id = 391, Country = moldova, Name = "Sagaidac", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(sagaidac);

                var sagaidaculNou = new Location { Id = 392, Country = moldova, Name = "Sagaidacul Nou", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(sagaidaculNou);

                var satulNou = new Location { Id = 393, Country = moldova, Name = "Satul Nou", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(satulNou);

                var schinosica = new Location { Id = 394, Country = moldova, Name = "Schinoșica", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(schinosica);

                var selemet = new Location { Id = 395, Country = moldova, Name = "Selemet", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(selemet);

                var suric = new Location { Id = 396, Country = moldova, Name = "Suric", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(suric);

                var topala = new Location { Id = 397, Country = moldova, Name = "Topala", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(topala);

                var troitcoe = new Location { Id = 398, Country = moldova, Name = "Troițcoe", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(troitcoe);

                var valeaPerjei = new Location { Id = 399, Country = moldova, Name = "Valea Perjei", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(valeaPerjei);

                var zloti = new Location { Id = 400, Country = moldova, Name = "Zloți", ParentLocation = cimislia };
                context.Locations.AddOrUpdate(zloti);

                var balabanesti = new Location { Id = 401, Country = moldova, Name = "Bălăbănești", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(balabanesti);

                var balasesti = new Location { Id = 402, Country = moldova, Name = "Bălășești", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(balasesti);

                var baltata = new Location { Id = 403, Country = moldova, Name = "Bălțata", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(baltata);

                var baltatadeSus = new Location { Id = 404, Country = moldova, Name = "Bălțata de Sus", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(baltatadeSus);

                var boscana = new Location { Id = 405, Country = moldova, Name = "Boșcana", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(boscana);

                var chetroasa = new Location { Id = 406, Country = moldova, Name = "Chetroasa", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(chetroasa);

                var cimiseni = new Location { Id = 407, Country = moldova, Name = "Cimișeni", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(cimiseni);

                var ciopleni = new Location { Id = 408, Country = moldova, Name = "Ciopleni", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(ciopleni);

                var corjova = new Location { Id = 409, Country = moldova, Name = "Corjova", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(corjova);

                var cosernita = new Location { Id = 410, Country = moldova, Name = "Coșernița", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(cosernita);

                var cruglic = new Location { Id = 411, Country = moldova, Name = "Cruglic", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(cruglic);

                var dolinnoe = new Location { Id = 412, Country = moldova, Name = "Dolinnoe", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(dolinnoe);

                var drasliceni = new Location { Id = 413, Country = moldova, Name = "Drăsliceni", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(drasliceni);

                var dubasariiVechi = new Location { Id = 414, Country = moldova, Name = "Dubăsarii Vechi", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(dubasariiVechi);

                var hirtopulMare = new Location { Id = 415, Country = moldova, Name = "Hîrtopul Mare", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(hirtopulMare);

                var hirtopulMic = new Location { Id = 416, Country = moldova, Name = "Hîrtopul Mic", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(hirtopulMic);

                var hrusova = new Location { Id = 417, Country = moldova, Name = "Hrușova", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(hrusova);

                var isnovat = new Location { Id = 418, Country = moldova, Name = "Ișnovăț", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(isnovat);

                var izbiste = new Location { Id = 419, Country = moldova, Name = "Izbiște", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(izbiste);

                var jevreni = new Location { Id = 420, Country = moldova, Name = "Jevreni", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(jevreni);

                var loganesti = new Location { Id = 421, Country = moldova, Name = "Logănești", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(loganesti);

                var mascauti = new Location { Id = 422, Country = moldova, Name = "Mașcăuți", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(mascauti);

                var mardareuca = new Location { Id = 423, Country = moldova, Name = "Mărdăreuca", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(mardareuca);

                var magdacesti = new Location { Id = 424, Country = moldova, Name = "Măgdăcești", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(magdacesti);

                var malaiesti = new Location { Id = 425, Country = moldova, Name = "Mălăiești", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(malaiesti);

                var malaiestiiNoi = new Location { Id = 426, Country = moldova, Name = "Mălăieștii Noi", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(malaiestiiNoi);

                var miclesti = new Location { Id = 427, Country = moldova, Name = "Miclești", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(miclesti);

                var ohrincea = new Location { Id = 428, Country = moldova, Name = "Ohrincea", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(ohrincea);

                var onitcani = new Location { Id = 429, Country = moldova, Name = "Onițcani", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(onitcani);

                var pascaniC = new Location { Id = 430, Country = moldova, Name = "Pașcani", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(pascaniC);

                var porumbeni = new Location { Id = 431, Country = moldova, Name = "Porumbeni", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(porumbeni);

                var ratus = new Location { Id = 431, Country = moldova, Name = "Ratuș", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(ratus);

                var raculesti = new Location { Id = 432, Country = moldova, Name = "Răculești", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(raculesti);

                var riscova = new Location { Id = 433, Country = moldova, Name = "Rîșcova", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(riscova);

                var sagaidacB = new Location { Id = 434, Country = moldova, Name = "Sagaidac", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(sagaidacB);

                var sagaidaculdeSus = new Location { Id = 435, Country = moldova, Name = "Sagaidacul de Sus", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(sagaidaculdeSus);

                var sloboziaDusca = new Location { Id = 436, Country = moldova, Name = "Slobozia-Dușca", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(sloboziaDusca);

                var stetcani = new Location { Id = 437, Country = moldova, Name = "Stețcani", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(stetcani);

                var valeaColonitei = new Location { Id = 438, Country = moldova, Name = "Valea Coloniței", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(valeaColonitei);

                var valeaSatului = new Location { Id = 439, Country = moldova, Name = "Valea Satului", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(valeaSatului);

                var zaicana = new Location { Id = 440, Country = moldova, Name = "Zăicana", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(zaicana);

                var zolonceni = new Location { Id = 441, Country = moldova, Name = "Zolonceni", ParentLocation = criuleni };
                context.Locations.AddOrUpdate(zolonceni);

                var arionesti = new Location { Id = 442, Country = moldova, Name = "Arionești", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(arionesti);

                var baraboi = new Location { Id = 443, Country = moldova, Name = "Baraboi", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(baraboi);

                var boroseni = new Location { Id = 444, Country = moldova, Name = "Boroseni", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(boroseni);

                var braicau = new Location { Id = 445, Country = moldova, Name = "Braicău", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(braicau);

                var briceniD = new Location { Id = 446, Country = moldova, Name = "Briceni", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(briceniD);

                var briceva = new Location { Id = 447, Country = moldova, Name = "Briceva", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(briceva);

                var caraiman = new Location { Id = 448, Country = moldova, Name = "Caraiman", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(caraiman);

                var cernoleuca = new Location { Id = 449, Country = moldova, Name = "Cernoleuca", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(cernoleuca);

                var climauti = new Location { Id = 450, Country = moldova, Name = "Climăuți", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(climauti);

                var codreniiNoi = new Location { Id = 451, Country = moldova, Name = "Codrenii Noi", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(codreniiNoi);

                var corbu = new Location { Id = 452, Country = moldova, Name = "Corbu", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(corbu);

                var criscauti = new Location { Id = 453, Country = moldova, Name = "Crișcăuți", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(criscauti);

                var elenovca = new Location { Id = 454, Country = moldova, Name = "Elenovca", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(elenovca);

                var elizavetovca = new Location { Id = 455, Country = moldova, Name = "Elizavetovca", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(elizavetovca);

                var frasin = new Location { Id = 456, Country = moldova, Name = "Frasin", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(frasin);

                var horodisteD = new Location { Id = 457, Country = moldova, Name = "Horodiște", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(horodisteD);

                var mosana = new Location { Id = 458, Country = moldova, Name = "Moșana", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(mosana);

                var octeabriscoe = new Location { Id = 459, Country = moldova, Name = "Octeabriscoe", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(octeabriscoe);

                var pivniceni = new Location { Id = 460, Country = moldova, Name = "Pivniceni", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(pivniceni);

                var plopD = new Location { Id = 461, Country = moldova, Name = "Plop", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(plopD);

                var pocrovca = new Location { Id = 462, Country = moldova, Name = "Pocrovca", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(pocrovca);

                var rediulMare = new Location { Id = 463, Country = moldova, Name = "Rediul Mare", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(rediulMare);

                var scaieni = new Location { Id = 464, Country = moldova, Name = "Scăieni", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(scaieni);

                var sudarca = new Location { Id = 465, Country = moldova, Name = "Sudarca", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(sudarca);

                var teleseuca = new Location { Id = 466, Country = moldova, Name = "Teleșeuca", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(teleseuca);

                var teleseucaNoua = new Location { Id = 467, Country = moldova, Name = "Teleșeuca Nouă", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(teleseucaNoua);

                var tirnova = new Location { Id = 468, Country = moldova, Name = "Tîrnova", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(tirnova);

                var taul = new Location { Id = 469, Country = moldova, Name = "Țaul", ParentLocation = donduseni };
                context.Locations.AddOrUpdate(taul);

                var antoneuca = new Location { Id = 470, Country = moldova, Name = "Antoneuca", ParentLocation = drochia };
                context.Locations.AddOrUpdate(antoneuca);

                var baroncea = new Location { Id = 471, Country = moldova, Name = "Baroncea", ParentLocation = drochia };
                context.Locations.AddOrUpdate(baroncea);

                var baronceaNoua = new Location { Id = 472, Country = moldova, Name = "Baroncea Nouă", ParentLocation = drochia };
                context.Locations.AddOrUpdate(baronceaNoua);

                var ceapaevca = new Location { Id = 473, Country = moldova, Name = "Ceapaevca", ParentLocation = drochia };
                context.Locations.AddOrUpdate(ceapaevca);

                var chetrosuDr = new Location { Id = 474, Country = moldova, Name = "Chetrosu", ParentLocation = drochia };
                context.Locations.AddOrUpdate(chetrosuDr);

                var cotova = new Location { Id = 475, Country = moldova, Name = "Cotova", ParentLocation = drochia };
                context.Locations.AddOrUpdate(cotova);

                var dominteni = new Location { Id = 476, Country = moldova, Name = "Dominteni", ParentLocation = drochia };
                context.Locations.AddOrUpdate(dominteni);

                var fintinita = new Location { Id = 477, Country = moldova, Name = "Fîntînița", ParentLocation = drochia };
                context.Locations.AddOrUpdate(fintinita);

                var gribova = new Location { Id = 478, Country = moldova, Name = "Gribova", ParentLocation = drochia };
                context.Locations.AddOrUpdate(gribova);

                var hasnaseniiMari = new Location { Id = 479, Country = moldova, Name = "Hăsnășenii Mari", ParentLocation = drochia };
                context.Locations.AddOrUpdate(hasnaseniiMari);

                var hasnaseniiNoi = new Location { Id = 480, Country = moldova, Name = "Hăsnășenii Noi", ParentLocation = drochia };
                context.Locations.AddOrUpdate(hasnaseniiNoi);

                var holosnitaNoua = new Location { Id = 481, Country = moldova, Name = "Holoșnița Nouă", ParentLocation = drochia };
                context.Locations.AddOrUpdate(holosnitaNoua);

                var iliciovca = new Location { Id = 482, Country = moldova, Name = "Iliciovca", ParentLocation = drochia };
                context.Locations.AddOrUpdate(iliciovca);

                var lazo = new Location { Id = 483, Country = moldova, Name = "Lazo", ParentLocation = drochia };
                context.Locations.AddOrUpdate(lazo);

                var maramonovca = new Location { Id = 484, Country = moldova, Name = "Maramonovca", ParentLocation = drochia };
                context.Locations.AddOrUpdate(maramonovca);

                var macareuca = new Location { Id = 485, Country = moldova, Name = "Măcăreuca", ParentLocation = drochia };
                context.Locations.AddOrUpdate(macareuca);

                var miciurin = new Location { Id = 486, Country = moldova, Name = "Miciurin", ParentLocation = drochia };
                context.Locations.AddOrUpdate(miciurin);

                var mindic = new Location { Id = 487, Country = moldova, Name = "Mîndîc", ParentLocation = drochia };
                context.Locations.AddOrUpdate(mindic);

                var moaradePiatra = new Location { Id = 488, Country = moldova, Name = "Moara de Piatră", ParentLocation = drochia };
                context.Locations.AddOrUpdate(moaradePiatra);

                var nicoreni = new Location { Id = 489, Country = moldova, Name = "Nicoreni", ParentLocation = drochia };
                context.Locations.AddOrUpdate(nicoreni);

                var ochiulAlb = new Location { Id = 490, Country = moldova, Name = "Ochiul Alb", ParentLocation = drochia };
                context.Locations.AddOrUpdate(ochiulAlb);

                var palancaDr = new Location { Id = 491, Country = moldova, Name = "Palanca", ParentLocation = drochia };
                context.Locations.AddOrUpdate(palancaDr);

                var pelinia = new Location { Id = 492, Country = moldova, Name = "Pelinia", ParentLocation = drochia };
                context.Locations.AddOrUpdate(pelinia);

                var pervomaiscoe = new Location { Id = 493, Country = moldova, Name = "Pervomaiscoe", ParentLocation = drochia };
                context.Locations.AddOrUpdate(pervomaiscoe);

                var petreni = new Location { Id = 494, Country = moldova, Name = "Petreni", ParentLocation = drochia };
                context.Locations.AddOrUpdate(petreni);

                var popestiideJos = new Location { Id = 495, Country = moldova, Name = "Popeștii de Jos", ParentLocation = drochia };
                context.Locations.AddOrUpdate(popestiideJos);

                var popestiideSus = new Location { Id = 496, Country = moldova, Name = "Popeștii de Sus", ParentLocation = drochia };
                context.Locations.AddOrUpdate(popestiideSus);

                var popestiiNoi = new Location { Id = 497, Country = moldova, Name = "Popeștii Noi", ParentLocation = drochia };
                context.Locations.AddOrUpdate(popestiiNoi);

                var sergheuca = new Location { Id = 498, Country = moldova, Name = "Sergheuca", ParentLocation = drochia };
                context.Locations.AddOrUpdate(sergheuca);

                var sofia = new Location { Id = 499, Country = moldova, Name = "Sofia", ParentLocation = drochia };
                context.Locations.AddOrUpdate(sofia);

                var salviriiNoi = new Location { Id = 500, Country = moldova, Name = "Șalvirii Noi", ParentLocation = drochia };
                context.Locations.AddOrUpdate(salviriiNoi);

                var salviriiVechi = new Location { Id = 501, Country = moldova, Name = "Șalvirii Vechi", ParentLocation = drochia };
                context.Locations.AddOrUpdate(salviriiVechi);

                var suri = new Location { Id = 502, Country = moldova, Name = "Șuri", ParentLocation = drochia };
                context.Locations.AddOrUpdate(suri);

                var suriiNoi = new Location { Id = 503, Country = moldova, Name = "Șurii Noi", ParentLocation = drochia };
                context.Locations.AddOrUpdate(suriiNoi);

                var tarigrad = new Location { Id = 504, Country = moldova, Name = "Țarigrad", ParentLocation = drochia };
                context.Locations.AddOrUpdate(tarigrad);

                var zgurita = new Location { Id = 505, Country = moldova, Name = "Zgurița", ParentLocation = drochia };
                context.Locations.AddOrUpdate(zgurita);

                var cocieri = new Location { Id = 506, Country = moldova, Name = "Cocieri", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(cocieri);

                var corjovaD = new Location { Id = 507, Country = moldova, Name = "Corjova", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(corjovaD);

                var cosnita = new Location { Id = 508, Country = moldova, Name = "Coșnița", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(cosnita);

                var dorotcaia = new Location { Id = 509, Country = moldova, Name = "Doroțcaia", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(dorotcaia);

                var holercani = new Location { Id = 510, Country = moldova, Name = "Holercani", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(holercani);

                var mahala = new Location { Id = 511, Country = moldova, Name = "Mahala", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(mahala);

                var marcautiD = new Location { Id = 512, Country = moldova, Name = "Mărcăuți", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(marcautiD);

                var molovata = new Location { Id = 513, Country = moldova, Name = "Molovata", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(molovata);

                var molovataNoua = new Location { Id = 514, Country = moldova, Name = "Molovata Nouă", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(molovataNoua);

                var oxentea = new Location { Id = 515, Country = moldova, Name = "Oxentea", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(oxentea);

                var pirita = new Location { Id = 516, Country = moldova, Name = "Pîrîta", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(pirita);

                var pohrebea = new Location { Id = 517, Country = moldova, Name = "Pohrebea", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(pohrebea);

                var roghi = new Location { Id = 518, Country = moldova, Name = "Roghi", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(roghi);

                var ustia = new Location { Id = 519, Country = moldova, Name = "Ustia", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(ustia);

                var vasilievca = new Location { Id = 520, Country = moldova, Name = "Vasilievca", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(vasilievca);

                var comisarovcaNoua = new Location { Id = 521, Country = moldova, Name = "Comisarovca Nouă", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(comisarovcaNoua);

                var crasniiVinogradari = new Location { Id = 522, Country = moldova, Name = "Crasnîi Vinogradari", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(crasniiVinogradari);

                var doibaniI = new Location { Id = 523, Country = moldova, Name = "Doibani I", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(doibaniI);

                var dubau = new Location { Id = 524, Country = moldova, Name = "Dubău", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(dubau);

                var dzerjinscoe = new Location { Id = 525, Country = moldova, Name = "Dzerjinscoe", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(dzerjinscoe);

                var goianD = new Location { Id = 526, Country = moldova, Name = "Goian", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(goianD);

                var harmatca = new Location { Id = 527, Country = moldova, Name = "Harmațca", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(harmatca);

                var lunga = new Location { Id = 528, Country = moldova, Name = "Lunga", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(lunga);

                var tibuleuca = new Location { Id = 529, Country = moldova, Name = "Țîbuleuca", ParentLocation = dubasari };
                context.Locations.AddOrUpdate(tibuleuca);

                var alexandreni = new Location { Id = 530, Country = moldova, Name = "Alexăndreni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(alexandreni);

                var alexeevca = new Location { Id = 531, Country = moldova, Name = "Alexeevca", ParentLocation = edinet };
                context.Locations.AddOrUpdate(alexeevca);

                var badragiiNoi = new Location { Id = 532, Country = moldova, Name = "Bădragii Noi", ParentLocation = edinet };
                context.Locations.AddOrUpdate(badragiiNoi);

                var badragiiVechi = new Location { Id = 533, Country = moldova, Name = "Bădragii Vechi", ParentLocation = edinet };
                context.Locations.AddOrUpdate(badragiiVechi);

                var blesteni = new Location { Id = 534, Country = moldova, Name = "Bleșteni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(blesteni);

                var bratuseni = new Location { Id = 535, Country = moldova, Name = "Brătușeni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(bratuseni);

                var bratuseniiNoi = new Location { Id = 536, Country = moldova, Name = "Brătușenii Noi", ParentLocation = edinet };
                context.Locations.AddOrUpdate(bratuseniiNoi);

                var brinzeni = new Location { Id = 537, Country = moldova, Name = "Brînzeni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(brinzeni);

                var burlanesti = new Location { Id = 538, Country = moldova, Name = "Burlănești", ParentLocation = edinet };
                context.Locations.AddOrUpdate(burlanesti);

                var buzdugeni = new Location { Id = 539, Country = moldova, Name = "Buzdugeni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(buzdugeni);

                var cepeleuti = new Location { Id = 540, Country = moldova, Name = "Cepeleuți", ParentLocation = edinet };
                context.Locations.AddOrUpdate(cepeleuti);

                var chetrosicaNoua = new Location { Id = 541, Country = moldova, Name = "Chetroșica Nouă", ParentLocation = edinet };
                context.Locations.AddOrUpdate(chetrosicaNoua);

                var chetrosicaVeche = new Location { Id = 542, Country = moldova, Name = "Chetroșica Veche", ParentLocation = edinet };
                context.Locations.AddOrUpdate(chetrosicaVeche);

                var chiurt = new Location { Id = 543, Country = moldova, Name = "Chiurt", ParentLocation = edinet };
                context.Locations.AddOrUpdate(chiurt);

                var cliscauti = new Location { Id = 544, Country = moldova, Name = "Clișcăuți", ParentLocation = edinet };
                context.Locations.AddOrUpdate(cliscauti);

                var constantinovcaE = new Location { Id = 545, Country = moldova, Name = "Constantinovca", ParentLocation = edinet };
                context.Locations.AddOrUpdate(constantinovcaE);

                var corpaci = new Location { Id = 546, Country = moldova, Name = "Corpaci", ParentLocation = edinet };
                context.Locations.AddOrUpdate(corpaci);

                var cuconestiiNoi = new Location { Id = 547, Country = moldova, Name = "Cuconeștii Noi", ParentLocation = edinet };
                context.Locations.AddOrUpdate(cuconestiiNoi);

                var cuconestiiVechi = new Location { Id = 548, Country = moldova, Name = "Cuconeștii Vechi", ParentLocation = edinet };
                context.Locations.AddOrUpdate(cuconestiiVechi);

                var cupcini = new Location { Id = 549, Country = moldova, Name = "Cupcini", ParentLocation = edinet };
                context.Locations.AddOrUpdate(cupcini);

                var fetesti = new Location { Id = 550, Country = moldova, Name = "Fetești", ParentLocation = edinet };
                context.Locations.AddOrUpdate(fetesti);

                var fintinaAlba = new Location { Id = 551, Country = moldova, Name = "Fîntîna Albă", ParentLocation = edinet };
                context.Locations.AddOrUpdate(fintinaAlba);

                var gaspar = new Location { Id = 552, Country = moldova, Name = "Gașpar", ParentLocation = edinet };
                context.Locations.AddOrUpdate(gaspar);

                var goleni = new Location { Id = 553, Country = moldova, Name = "Goleni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(goleni);

                var gordinesti = new Location { Id = 554, Country = moldova, Name = "Gordinești", ParentLocation = edinet };
                context.Locations.AddOrUpdate(gordinesti);

                var gordinestiiNoi = new Location { Id = 555, Country = moldova, Name = "Gordineștii Noi", ParentLocation = edinet };
                context.Locations.AddOrUpdate(gordinestiiNoi);

                var hancauti = new Location { Id = 556, Country = moldova, Name = "Hancăuți", ParentLocation = edinet };
                context.Locations.AddOrUpdate(hancauti);

                var hincauti = new Location { Id = 557, Country = moldova, Name = "Hincăuți", ParentLocation = edinet };
                context.Locations.AddOrUpdate(hincauti);

                var hlinaia = new Location { Id = 558, Country = moldova, Name = "Hlinaia", ParentLocation = edinet };
                context.Locations.AddOrUpdate(hlinaia);

                var hlinaiaMica = new Location { Id = 559, Country = moldova, Name = "Hlinaia Mică", ParentLocation = edinet };
                context.Locations.AddOrUpdate(hlinaiaMica);

                var iachimeni = new Location { Id = 560, Country = moldova, Name = "Iachimeni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(iachimeni);

                var lopatnic = new Location { Id = 561, Country = moldova, Name = "Lopatnic", ParentLocation = edinet };
                context.Locations.AddOrUpdate(lopatnic);

                var onesti = new Location { Id = 562, Country = moldova, Name = "Onești", ParentLocation = edinet };
                context.Locations.AddOrUpdate(onesti);

                var parcova = new Location { Id = 563, Country = moldova, Name = "Parcova", ParentLocation = edinet };
                context.Locations.AddOrUpdate(parcova);

                var poiana = new Location { Id = 564, Country = moldova, Name = "Poiana", ParentLocation = edinet };
                context.Locations.AddOrUpdate(poiana);

                var ringaci = new Location { Id = 565, Country = moldova, Name = "Rîngaci", ParentLocation = edinet };
                context.Locations.AddOrUpdate(ringaci);

                var rotunda = new Location { Id = 566, Country = moldova, Name = "Rotunda", ParentLocation = edinet };
                context.Locations.AddOrUpdate(rotunda);

                var ruseniE = new Location { Id = 567, Country = moldova, Name = "Ruseni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(ruseniE);

                var slobodca = new Location { Id = 568, Country = moldova, Name = "Slobodca", ParentLocation = edinet };
                context.Locations.AddOrUpdate(slobodca);

                var stolniceni = new Location { Id = 569, Country = moldova, Name = "Stolniceni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(stolniceni);

                var sofrincani = new Location { Id = 570, Country = moldova, Name = "Șofrîncani", ParentLocation = edinet };
                context.Locations.AddOrUpdate(sofrincani);

                var terebna = new Location { Id = 571, Country = moldova, Name = "Terebna", ParentLocation = edinet };
                context.Locations.AddOrUpdate(terebna);

                var tirnovaE = new Location { Id = 572, Country = moldova, Name = "Tîrnova", ParentLocation = edinet };
                context.Locations.AddOrUpdate(tirnovaE);

                var trinca = new Location { Id = 573, Country = moldova, Name = "Trinca", ParentLocation = edinet };
                context.Locations.AddOrUpdate(trinca);

                var vancicauti = new Location { Id = 574, Country = moldova, Name = "Vancicăuți", ParentLocation = edinet };
                context.Locations.AddOrUpdate(vancicauti);

                var viisoara = new Location { Id = 575, Country = moldova, Name = "Viișoara", ParentLocation = edinet };
                context.Locations.AddOrUpdate(viisoara);

                var volodeni = new Location { Id = 576, Country = moldova, Name = "Volodeni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(volodeni);

                var zabriceni = new Location { Id = 577, Country = moldova, Name = "Zăbriceni", ParentLocation = edinet };
                context.Locations.AddOrUpdate(zabriceni);

                var albinetulNou = new Location { Id = 578, Country = moldova, Name = "Albinețul Nou", ParentLocation = falesti };
                context.Locations.AddOrUpdate(albinetulNou);

                var albinetulVechi = new Location { Id = 579, Country = moldova, Name = "Albinețul Vechi", ParentLocation = falesti };
                context.Locations.AddOrUpdate(albinetulVechi);

                var beleuti = new Location { Id = 580, Country = moldova, Name = "Beleuți", ParentLocation = falesti };
                context.Locations.AddOrUpdate(beleuti);

                var bocani = new Location { Id = 581, Country = moldova, Name = "Bocani", ParentLocation = falesti };
                context.Locations.AddOrUpdate(bocani);

                var bocsa = new Location { Id = 581, Country = moldova, Name = "Bocșa", ParentLocation = falesti };
                context.Locations.AddOrUpdate(bocsa);

                var burghelea = new Location { Id = 582, Country = moldova, Name = "Burghelea", ParentLocation = falesti };
                context.Locations.AddOrUpdate(burghelea);

                var catranic = new Location { Id = 583, Country = moldova, Name = "Catranîc", ParentLocation = falesti };
                context.Locations.AddOrUpdate(catranic);

                var calinesti = new Location { Id = 584, Country = moldova, Name = "Călinești", ParentLocation = falesti };
                context.Locations.AddOrUpdate(calinesti);

                var calugar = new Location { Id = 585, Country = moldova, Name = "Călugăr", ParentLocation = falesti };
                context.Locations.AddOrUpdate(calugar);

                var chetris = new Location { Id = 586, Country = moldova, Name = "Chetriș", ParentLocation = falesti };
                context.Locations.AddOrUpdate(chetris);

                var chetrisulNou = new Location { Id = 587, Country = moldova, Name = "Chetrișul Nou", ParentLocation = falesti };
                context.Locations.AddOrUpdate(chetrisulNou);

                var ciolacuNou = new Location { Id = 588, Country = moldova, Name = "Ciolacu Nou", ParentLocation = falesti };
                context.Locations.AddOrUpdate(ciolacuNou);

                var ciolacuVechi = new Location { Id = 589, Country = moldova, Name = "Ciolacu Vechi", ParentLocation = falesti };
                context.Locations.AddOrUpdate(ciolacuVechi);

                var ciuluc = new Location { Id = 590, Country = moldova, Name = "Ciuluc", ParentLocation = falesti };
                context.Locations.AddOrUpdate(ciuluc);

                var comarovca = new Location { Id = 591, Country = moldova, Name = "Comarovca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(comarovca);

                var cuzmeniiVechi = new Location { Id = 592, Country = moldova, Name = "Cuzmenii Vechi", ParentLocation = falesti };
                context.Locations.AddOrUpdate(cuzmeniiVechi);

                var doltu = new Location { Id = 593, Country = moldova, Name = "Doltu", ParentLocation = falesti };
                context.Locations.AddOrUpdate(doltu);

                var drujineni = new Location { Id = 594, Country = moldova, Name = "Drujineni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(drujineni);

                var egorovca = new Location { Id = 595, Country = moldova, Name = "Egorovca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(egorovca);

                var fagadau = new Location { Id = 596, Country = moldova, Name = "Făgădău", ParentLocation = falesti };
                context.Locations.AddOrUpdate(fagadau);

                var falestiiNoi = new Location { Id = 597, Country = moldova, Name = "Făleștii Noi", ParentLocation = falesti };
                context.Locations.AddOrUpdate(falestiiNoi);

                var frumusicaF = new Location { Id = 598, Country = moldova, Name = "Frumușica", ParentLocation = falesti };
                context.Locations.AddOrUpdate(frumusicaF);

                var glinjeni = new Location { Id = 599, Country = moldova, Name = "Glinjeni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(glinjeni);

                var hiliuti = new Location { Id = 600, Country = moldova, Name = "Hiliuți", ParentLocation = falesti };
                context.Locations.AddOrUpdate(hiliuti);

                var hitresti = new Location { Id = 601, Country = moldova, Name = "Hitrești", ParentLocation = falesti };
                context.Locations.AddOrUpdate(hitresti);

                var hincestiF = new Location { Id = 602, Country = moldova, Name = "Hîncești", ParentLocation = falesti };
                context.Locations.AddOrUpdate(hincestiF);

                var hirtopF = new Location { Id = 603, Country = moldova, Name = "Hîrtop", ParentLocation = falesti };
                context.Locations.AddOrUpdate(hirtopF);

                var horesti = new Location { Id = 604, Country = moldova, Name = "Horești", ParentLocation = falesti };
                context.Locations.AddOrUpdate(horesti);

                var hrubnaNoua = new Location { Id = 605, Country = moldova, Name = "Hrubna Nouă", ParentLocation = falesti };
                context.Locations.AddOrUpdate(hrubnaNoua);

                var ilenuta = new Location { Id = 606, Country = moldova, Name = "Ilenuța", ParentLocation = falesti };
                context.Locations.AddOrUpdate(ilenuta);

                var iscalau = new Location { Id = 607, Country = moldova, Name = "Ișcălău", ParentLocation = falesti };
                context.Locations.AddOrUpdate(iscalau);

                var ivanovcaF = new Location { Id = 608, Country = moldova, Name = "Ivanovca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(ivanovcaF);

                var izvoare = new Location { Id = 609, Country = moldova, Name = "Izvoare", ParentLocation = falesti };
                context.Locations.AddOrUpdate(izvoare);

                var logofteni = new Location { Id = 610, Country = moldova, Name = "Logofteni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(logofteni);

                var lucaceni = new Location { Id = 611, Country = moldova, Name = "Lucăceni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(lucaceni);

                var magura = new Location { Id = 612, Country = moldova, Name = "Măgura", ParentLocation = falesti };
                context.Locations.AddOrUpdate(magura);

                var maguraNoua = new Location { Id = 613, Country = moldova, Name = "Măgura Nouă", ParentLocation = falesti };
                context.Locations.AddOrUpdate(maguraNoua);

                var magureanca = new Location { Id = 614, Country = moldova, Name = "Măgureanca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(magureanca);

                var marandeni = new Location { Id = 615, Country = moldova, Name = "Mărăndeni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(marandeni);

                var moldoveanca = new Location { Id = 616, Country = moldova, Name = "Moldoveanca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(moldoveanca);

                var musteata = new Location { Id = 617, Country = moldova, Name = "Musteața", ParentLocation = falesti };
                context.Locations.AddOrUpdate(musteata);

                var natalievca = new Location { Id = 618, Country = moldova, Name = "Natalievca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(natalievca);

                var navirnet = new Location { Id = 619, Country = moldova, Name = "Năvîrneț", ParentLocation = falesti };
                context.Locations.AddOrUpdate(navirnet);

                var nicolaevcaF = new Location { Id = 620, Country = moldova, Name = "Nicolaevca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(nicolaevcaF);

                var obrejaNoua = new Location { Id = 621, Country = moldova, Name = "Obreja Nouă", ParentLocation = falesti };
                context.Locations.AddOrUpdate(obrejaNoua);

                var obrejaVeche = new Location { Id = 622, Country = moldova, Name = "Obreja Veche", ParentLocation = falesti };
                context.Locations.AddOrUpdate(obrejaVeche);

                var pervomaiscF = new Location { Id = 623, Country = moldova, Name = "Pervomaisc", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pervomaiscF);

                var pietrosu = new Location { Id = 624, Country = moldova, Name = "Pietrosu", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pietrosu);

                var pietrosulNou = new Location { Id = 625, Country = moldova, Name = "Pietrosul Nou", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pietrosulNou);

                var pinzareni = new Location { Id = 626, Country = moldova, Name = "Pînzăreni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pinzareni);

                var pinzareniiNoi = new Location { Id = 627, Country = moldova, Name = "Pînzărenii Noi", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pinzareniiNoi);

                var pirlita = new Location { Id = 628, Country = moldova, Name = "Pîrlița", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pirlita);

                var pocrovcaF = new Location { Id = 629, Country = moldova, Name = "Pocrovca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pocrovcaF);

                var pompa = new Location { Id = 630, Country = moldova, Name = "Pompa", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pompa);

                var popovcaF = new Location { Id = 631, Country = moldova, Name = "Popovca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(popovcaF);

                var pruteni = new Location { Id = 632, Country = moldova, Name = "Pruteni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(pruteni);

                var rautel = new Location { Id = 633, Country = moldova, Name = "Răuțel", ParentLocation = falesti };
                context.Locations.AddOrUpdate(rautel);

                var rautelulNou = new Location { Id = 634, Country = moldova, Name = "Răuțelul Nou", ParentLocation = falesti };
                context.Locations.AddOrUpdate(rautelulNou);

                var rediuldeJos = new Location { Id = 635, Country = moldova, Name = "Rediul de Jos	", ParentLocation = falesti };
                context.Locations.AddOrUpdate(rediuldeJos);

                var rediuldeSus = new Location { Id = 636, Country = moldova, Name = "Rediul de Sus", ParentLocation = falesti };
                context.Locations.AddOrUpdate(rediuldeSus);

                var risipeni = new Location { Id = 637, Country = moldova, Name = "Risipeni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(risipeni);

                var sarataNoua = new Location { Id = 638, Country = moldova, Name = "Sărata Nouă", ParentLocation = falesti };
                context.Locations.AddOrUpdate(sarataNoua);

                var sarataVeche = new Location { Id = 639, Country = moldova, Name = "Sărata Veche", ParentLocation = falesti };
                context.Locations.AddOrUpdate(sarataVeche);

                var scumpia = new Location { Id = 640, Country = moldova, Name = "Scumpia", ParentLocation = falesti };
                context.Locations.AddOrUpdate(scumpia);

                var sociiNoi = new Location { Id = 641, Country = moldova, Name = "Socii Noi", ParentLocation = falesti };
                context.Locations.AddOrUpdate(sociiNoi);

                var sociiVechi = new Location { Id = 642, Country = moldova, Name = "Socii Vechi", ParentLocation = falesti };
                context.Locations.AddOrUpdate(sociiVechi);

                var suvorovca = new Location { Id = 643, Country = moldova, Name = "Suvorovca", ParentLocation = falesti };
                context.Locations.AddOrUpdate(suvorovca);

                var soltoaia = new Location { Id = 644, Country = moldova, Name = "Șoltoaia", ParentLocation = falesti };
                context.Locations.AddOrUpdate(soltoaia);

                var taxobeni = new Location { Id = 645, Country = moldova, Name = "Taxobeni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(taxobeni);

                var tapoc = new Location { Id = 646, Country = moldova, Name = "Țapoc", ParentLocation = falesti };
                context.Locations.AddOrUpdate(tapoc);

                var unteni = new Location { Id = 647, Country = moldova, Name = "Unteni", ParentLocation = falesti };
                context.Locations.AddOrUpdate(unteni);

                var valeaRusului = new Location { Id = 648, Country = moldova, Name = "Valea Rusului", ParentLocation = falesti };
                context.Locations.AddOrUpdate(valeaRusului);

                var vranesti = new Location { Id = 649, Country = moldova, Name = "Vrănești", ParentLocation = falesti };
                context.Locations.AddOrUpdate(vranesti);


                #endregion Villages

            }




        }
    }
}
