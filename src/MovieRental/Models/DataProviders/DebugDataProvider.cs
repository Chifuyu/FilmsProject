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
            var comedy = new Genre { Name = "комедия" };
            var melodrama = new Genre { Name = "мелодрама" };
            var fantastique = new Genre { Name = "фантастика" };

            // Actors
            var jimCarrey = new Actor { FirstName = "Джим", LastName = "Керри" };
            var jeffDaniels = new Actor { FirstName = "Джефф", LastName = "Дэниэлс" };
            var steveCarell = new Actor { FirstName = "Стив", LastName = "Карелл" };
            var paulRudd = new Actor { FirstName = "Пол", LastName = "Радд" };
            var kateWinslet = new Actor { FirstName = "Кейт", LastName = "Уинслет" };
            var tomWilkinson = new Actor { FirstName = "Том", LastName = "Уилкинсон" };
            var elijahWood = new Actor { FirstName = "Элайджа", LastName = "Вуд" };
            var markRuffalo = new Actor { FirstName = "Марк", LastName = "Руффало" };
            var kristenDunst = new Actor { FirstName = "Кирстен", LastName = "Данст" };

            // Directors
            var michaelGoundry = new Director { FirstName = "Мишель", LastName = "Гондри" };
            var peterFarelly = new Director { FirstName = "Питер", LastName = "Фаррелли" };
            var bobbyFarelly = new Director { FirstName = "Бобби", LastName = "Фаррелли" };
            var jayRoach = new Director { FirstName = "Джей", LastName = "Роуч" };

            // Movies
            var dumbAndDumber = new Movie
            {
                Name = "Тупой и еще тупее",
                Year = 1994,
                Logo = "dumb-dumber.jpg",
                Rating = 84,  // Rotten Tomatoes' audience score is used as a raiting here and below.
                Description = "Два полных придурка, Ллойд Крисмас и Харри Данн пытаются нагнать красивую девушку Мэри Суонсон, чтобы вручить ей потерянный ею чемоданчик-дипломат. Кретинам невдомек, что Мэри обронила его специально, в качестве выкупа по договоренности с бандитами, похитившими ее мужа. Ведь внутри лежит кругленькая сумма. На мохнатой машине уникальной марки «Овчарка» двое идиотов пересекают Америку от Род-Айленда до Колорадо, где и находят обворожительную Мэри, в которую Ллойд уже успел втюриться без памяти.",
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
                Name = "Ужин с придурками",
                Year = 2010,
                Logo = "dinner-for-shcmunks.jpg",
                Rating = 42,
                Description = "Простой служащий фирмы Тим получил своё первое приглашение на «ужин для придурков». Это ежемесячное мероприятие устраивает его босс, и тот, кто покажет себя самым большим идиотом, может рассчитывать на некоторые бонусы в будущем. Невеста Тима — Джулии — находит всё это ужасным, и Тим соглашается пропустить ужин, но случайно знакомится с Барри — сотрудником налоговой службы, который в свободное время конструирует диорамы из чучел мышей. Тим приглашает с собой на ужин Барри, который становится причиной злоключений Тима. У него едва не срывается важная сделка, его бывшая подруга возвращается в его жизнь, а Джулии попадает в объятия другого…",
                Price = 180,
                Count = 5
            };
            dinnerForSchmunks.Directors.Add(jayRoach);
            dinnerForSchmunks.Actors.Add(steveCarell);
            dinnerForSchmunks.Actors.Add(paulRudd);
            dinnerForSchmunks.ListOfGenres.Add(comedy);

            var eternalSunshine = new Movie
            {
                Name = "Вечное сияние чистого разума",
                Year = 2004,
                Logo = "eternal-sunshine.jpg",
                Rating = 94,
                Description = "Наконец-то изобретена машина, которая позволяет избавиться от любых воспоминаний. Джоэль и Клементина решают выбросить друг друга из головы. Но в памяти Джоэля все еще живы самые нежные моменты их чувства. Чем меньше он помнит, тем больше любит. Понимая, что он просто обожает Клементину, Джоэль пытается найти способ, чтобы вернуть любимой память о прошлом.Пока еще не очень поздно… Он должен победить ненавистный компьютерный мозг во что бы то ни стало!",
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
            
            var movies = new List<Movie> { dumbAndDumber, dinnerForSchmunks, eternalSunshine };

            return movies;
        }
    }
}