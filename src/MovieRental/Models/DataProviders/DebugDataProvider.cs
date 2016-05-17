using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models.DataProviders
{
    public static class DebugDataProvider
    {
        public static ICollection<Movie> GetMovies()
        {
            // Genres
            var comedy = new Genre { Name = "comedy" };
            var melodrama = new Genre { Name = "melodrama" };
            var fantastique = new Genre { Name = "fantastique" };
            var animation = new Genre { Name = "animation" };
            var drama = new Genre { Name = "drama" };
            var crime = new Genre { Name = "crime" };
            var action = new Genre { Name = "action" };
            var adventure = new Genre { Name = "adventure" };

            // Actors
            var jimCarrey = new Actor { FirstName = "Jim", LastName = "Carrey" };
            var jeffDaniels = new Actor { FirstName = "Jeff", LastName = "Daniels" };
            var steveCarell = new Actor { FirstName = "Steve", LastName = "Carell" };
            var paulRudd = new Actor { FirstName = "Paul", LastName = "Rudd" };
            var kateWinslet = new Actor { FirstName = "Kate", LastName = "Winslet" };
            var tomWilkinson = new Actor { FirstName = "Tom", LastName = "Winkinson" };
            var elijahWood = new Actor { FirstName = "Elijah", LastName = "Wood" };
            var markRuffalo = new Actor { FirstName = "Mark", LastName = "Ruffalo" };
            var kristenDunst = new Actor { FirstName = "Kristen", LastName = "Dunst" };
            var chikaSakamoto = new Actor { FirstName = "Chika", LastName = "Sakamoto" };
            var hitoshiTakagi = new Actor { FirstName = "Hitoshi", LastName = "Takagi" };
            var norikoHidaka = new Actor { FirstName = "Noriko", LastName = "Hidaka" };
            var ellenBurstyn = new Actor { FirstName = "Ellen", LastName = "Burstyn" };
            var jaredLeto = new Actor { FirstName = "Jared", LastName = "Leto" };
            var jenifferConney = new Actor { FirstName = "Jeniffer", LastName = "Conney" };
            var marlonWayans = new Actor { FirstName = "Marlon", LastName = "Wayans" };
            var jasonFlemyng = new Actor { FirstName = "Jason", LastName = "Flemyng" };
            var dexterFletcher = new Actor { FirstName = "Dexter", LastName = "Fletcher" };
            var nickMoran = new Actor { FirstName = "Nick", LastName = "Moran" };
            var jasonStatham = new Actor { FirstName = "Jason", LastName = "Statham" };
            var timRoth = new Actor { FirstName = "Tim", LastName = "Roth" };
            var johnTravolta = new Actor { FirstName = "John", LastName = "Travolta" };
            var samuelLJackson = new Actor { FirstName = "Samuel L.", LastName = "Jackson" };
            var bruceWillis = new Actor { FirstName = "Bruce", LastName = "Willis" };
            var umaThurman = new Actor { FirstName = "Uma", LastName = "Thurman" };
            var vingRhames = new Actor { FirstName = "Ving", LastName = "Rhames" };
            var ginniferGoodwin = new Actor { FirstName = "Ginnifer", LastName = "Goodwin" };
            var jasonBateman = new Actor { FirstName = "Jason", LastName = "Bateman" };
            var idrisElba = new Actor { FirstName = "Idris", LastName = "Elba" };
            var jennySlate = new Actor { FirstName = "Jenny", LastName = "Slate" };

            // Directors
            var michaelGoundry = new Director { FirstName = "Michael", LastName = "Foundry" };
            var peterFarelly = new Director { FirstName = "Peter", LastName = "Farelly" };
            var bobbyFarelly = new Director { FirstName = "Bobby", LastName = "Farelly" };
            var jayRoach = new Director { FirstName = "Jay", LastName = "Roach" };
            var hayaoMiyazaki = new Director { FirstName = "Hayao", LastName = "Miyazaki" };
            var darrenAronofsky = new Director { FirstName = "Darren", LastName = "Aronofsky" };
            var guyRitchie = new Director { FirstName = "Guy", LastName = "Ritchie" };
            var quentinTarantino = new Director { FirstName = "Quentin", LastName = "Tarantino" };
            var byronHoward = new Director { FirstName = "Byron", LastName = "Howard" };
            var richMoore = new Director { FirstName = "Rich", LastName = "Moore" };
            var jaredBush = new Director { FirstName = "Jared", LastName = "Bush" };

            // Movies
            var dumbAndDumber = new Movie
            {
                Name = "Dumb & Dumber",
                Year = 1994,
                Logo = "~/Content/Images/dumb-dumber.jpg",
                Rating = 84,  // Rotten Tomatoes' audience score is used as a raiting here and below.
                Description = "The cross-country adventures of two good-hearted but incredibly stupid friends.",
                Price = 250,
                Count = 8,
            };
            dumbAndDumber.Directors.Add(peterFarelly);
            dumbAndDumber.Directors.Add(bobbyFarelly);
            dumbAndDumber.Actors.Add(jimCarrey);
            dumbAndDumber.Actors.Add(jeffDaniels);
            dumbAndDumber.ListOfGenres.Add(comedy);

            var dinnerForSchmunks = new Movie
            {
                Name = "Dinner for Schmunks",
                Year = 2010,
                Logo = "~/Content/Images/dinner-for-shcmunks.jpg",
                Rating = 42,
                Description = "When he finds out that his work superiors host a dinner celebrating the idiocy of their guests, a rising executive questions it when he's invited, just as he befriends a man who would be the perfect guest.",
                Price = 180,
                Count = 5
            };
            dinnerForSchmunks.Directors.Add(jayRoach);
            dinnerForSchmunks.Actors.Add(steveCarell);
            dinnerForSchmunks.Actors.Add(paulRudd);
            dinnerForSchmunks.ListOfGenres.Add(comedy);

            var eternalSunshine = new Movie
            {
                Name = "Eternal Sunshine of the Spotless Mind",
                Year = 2004,
                Logo = "~/Content/Images/eternal-sunshine.jpg",
                Rating = 94,
                Description = "When their relationships turns sour, a couple undergoes a procedure to have each other erased from their memories. But it is only through the process of loss that they discover what they had been to begin with.",
                Price = 200,
                Count = 4
            };
            eternalSunshine.Directors.Add(michaelGoundry);
            eternalSunshine.Actors.Add(jimCarrey);
            eternalSunshine.Actors.Add(kateWinslet);
            eternalSunshine.Actors.Add(tomWilkinson);
            eternalSunshine.Actors.Add(elijahWood);
            eternalSunshine.Actors.Add(markRuffalo);
            eternalSunshine.Actors.Add(kristenDunst);
            eternalSunshine.ListOfGenres.Add(melodrama);
            eternalSunshine.ListOfGenres.Add(fantastique);

            var myNeigbourTotoro = new Movie
            {
                Name = "My Neighbour Totoro",
                Year = 1988,
                Logo = "~/Content/Images/totoro.jpg",
                Rating = 94,
                Description = "When two girls move to the country to be near their ailing mother, they have adventures with the wonderous forest spirits who live nearby.",
                Price = 200,
                Count = 3
            };
            myNeigbourTotoro.Directors.Add(hayaoMiyazaki);
            myNeigbourTotoro.Actors.Add(chikaSakamoto);
            myNeigbourTotoro.Actors.Add(hitoshiTakagi);
            myNeigbourTotoro.Actors.Add(norikoHidaka);
            myNeigbourTotoro.ListOfGenres.Add(drama);
            myNeigbourTotoro.ListOfGenres.Add(animation);

            var requiemForADream = new Movie
            {
                Name = "Requiem for a Dream",
                Year = 1988,
                Logo = "~/Content/Images/requiem.jpg",
                Rating = 93,
                Description = "The drug-inducced utopias of four Coney Island people are shattered when their addictions become stronger.",
                Price = 190,
                Count = 5
            };
            requiemForADream.Directors.Add(darrenAronofsky);
            requiemForADream.Actors.Add(ellenBurstyn);
            requiemForADream.Actors.Add(jaredLeto);
            requiemForADream.Actors.Add(jenifferConney);
            requiemForADream.Actors.Add(marlonWayans);
            requiemForADream.ListOfGenres.Add(drama);

            var lockStockBarrels = new Movie
            {
                Name = "Lock, Stock and Two Smocking Barrels",
                Year = 1998,
                Logo = "~/Content/Images/lock-stock-barrels.jpg",
                Rating = 93,
                Description = "A botched card game in London triggers four friends, thugs, weed-growers, hard gangsters, loan sharks and debt collectors to collide with each other in a series of unexpected events, all for the sake of weed, cash and two antique shotguns.",
                Price = 180,
                Count = 6
            };
            lockStockBarrels.Directors.Add(guyRitchie);
            lockStockBarrels.Actors.Add(jasonFlemyng);
            lockStockBarrels.Actors.Add(dexterFletcher);
            lockStockBarrels.Actors.Add(nickMoran);
            lockStockBarrels.Actors.Add(jasonStatham);
            lockStockBarrels.ListOfGenres.Add(crime);
            lockStockBarrels.ListOfGenres.Add(comedy);

            var pulpFiction = new Movie
            {
                Name = "Pulp Fiction",
                Year = 1994,
                Logo = "~/Content/Images/pulp-fiction.jpg",
                Rating = 96,
                Description = "The lives of two mob hit men, a boxer, a gangster's wife, and a pair of diner bandits interwine in four tales of violence and redemption.",
                Price = 200,
                Count = 7
            };
            pulpFiction.Directors.Add(quentinTarantino);
            pulpFiction.Actors.Add(timRoth);
            pulpFiction.Actors.Add(johnTravolta);
            pulpFiction.Actors.Add(samuelLJackson);
            pulpFiction.Actors.Add(bruceWillis);
            pulpFiction.Actors.Add(umaThurman);
            pulpFiction.Actors.Add(vingRhames);
            pulpFiction.ListOfGenres.Add(crime);
            pulpFiction.ListOfGenres.Add(drama);

            var zootopia = new Movie
            {
                Name = "Zootopia",
                Year = 2016,
                Logo = "~/Content/Images/zootopia.jpg",
                Rating = 94,
                Description = "In a city of antropomorphic animals, a rookie bunny cop and a cynical con artist fox must work together to uncover a conspiracy.",
                Price = 250,
                Count = 8
            };
            zootopia.Directors.Add(byronHoward);
            zootopia.Directors.Add(richMoore);
            zootopia.Directors.Add(jaredBush);
            zootopia.Actors.Add(ginniferGoodwin);
            zootopia.Actors.Add(jasonBateman);
            zootopia.Actors.Add(idrisElba);
            zootopia.Actors.Add(jennySlate);
            zootopia.ListOfGenres.Add(action);
            zootopia.ListOfGenres.Add(adventure);
            zootopia.ListOfGenres.Add(animation);

            var movies = new List<Movie> {
                dumbAndDumber,
                dinnerForSchmunks,
                eternalSunshine,
                myNeigbourTotoro,
                requiemForADream,
                lockStockBarrels,
                pulpFiction,
                zootopia
            };

            return movies;
        }
    }
}