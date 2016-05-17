using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieRental.DAL;
using MovieRental.Models;

namespace MovieRental.Controllers
{
    public class MoviesController : Controller
    {
        public readonly int MaxMovieDescriptionLength = 200;

        private Context db = new Context();

        // GET: Movies
        /*public ActionResult Index()
        {
            var movies = db.Movies.ToList();
            ViewBag.Movies = movies;
            ViewBag.Years = GetList(movies, x => { return x.Year; });
            ViewBag.Genres = db.Genres.ToList();
            ViewBag.Directors = db.Directors.ToList();
            ViewBag.Actors = db.Actors.ToList();
            ViewBag.Prices = GetList(movies, x => { return x.Price; });
            ViewBag.Ratings = GetList(movies, x => { return x.Rating; });

            return View(movies);
        }*/

        public ActionResult Index(string value, int type)
        {
            var result = new List<Movie>();
            var movies = db.Movies.ToList();
            ViewBag.Years = GetList(movies, x => { return x.Year; });
            ViewBag.Genres = db.Genres.ToList();
            ViewBag.Directors = db.Directors.ToList();
            ViewBag.Actors = db.Actors.ToList();
            ViewBag.Prices = GetList(movies, x => { return x.Price; });
            ViewBag.Ratings = GetList(movies, x => { return x.Rating; });

            System.Diagnostics.Debug.WriteLine(value);
            switch (type)
            {
                case 0:
                    if (value == null)
                    {
                        result.AddRange(movies);
                    }
                    else
                    {
                        foreach (var item in movies)
                        {
                            if (item.Name.ToLower().Contains(value.ToLower()))
                                result.Add(item);
                            System.Diagnostics.Debug.WriteLine(String.Format("{0} is that {1} in {2}", item.Name.Contains(value), value, item.Name));
                        }
                    }
                    break;
                case 1:
                    SortMoviesList(ref result, movies, x => { return x.Year == Int32.Parse(value); });
                    break;
                case 2:
                    SortMoviesList(ref result, movies, x => {
                        foreach (var item in x.ListOfGenres)
                            if (item.Id == Int32.Parse(value))
                                return true;

                        return false;
                    });
                    break;
                case 3:
                    SortMoviesList(ref result, movies, x => {
                        foreach (var item in x.Directors)
                            if (item.Id == Int32.Parse(value))
                                return true;

                        return false;
                    });
                    break;
                case 4:
                    SortMoviesList(ref result, movies, x => {
                        foreach (var item in x.Actors)
                            if (item.Id == Int32.Parse(value))
                                return true;

                        return false;
                    });
                    break;
                case 5:
                    SortMoviesList(ref result, movies, x => { return x.Price <= Int32.Parse(value); });
                    break;
                case 6:
                    SortMoviesList(ref result, movies, x => { return x.Rating >= Int32.Parse(value); });
                    break;
            }

            result.ForEach(movie => movie.Description = movie.Description.Substring(0, Math.Min(movie.Description.Length, MaxMovieDescriptionLength)) + "...");
            return View(result);
        }

        public List<int> GetList(List<Movie> movies, Func<Movie, int> func)
        {
            var result = new List<int>();

            foreach (var item in movies)
            {
                if (result.IndexOf(func(item)) != -1)
                    continue;

                result.Add(func(item));
            }
            result.Sort();

            return result;
        }
        
        public void SortMoviesList(ref List<Movie> result, List<Movie> movies, Predicate<Movie> pred)
        {
            foreach (var item in movies)
            {
                if (pred(item))
                    result.Add(item);
            }
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            ViewBag.CanBeOrdered = db.Orders
                                     .Where(order => order.To < DateTime.Now)
                                     .All(order => order.MovieId != id);
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Year,Price,Rating,Logo,Count,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Year,Price,Rating,Logo,Count,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
