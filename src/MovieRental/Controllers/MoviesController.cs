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
        public static readonly int MaxMovieDescriptionLength = 200;

        public enum MovieFilterType
        {
            None = 0,
            ByName,
            ByYear,
            ByGenre,
            ByDirector,
            ByActor,
            ByMaximalPrice,
            ByMinRating
        }

        private Context db = new Context();

        // GET: Movies/Index?value=Matrix&type=1
        public ActionResult Index(string value, MovieFilterType type)
        {
            ViewBag.Genres = db.Genres.ToList();
            ViewBag.Directors = db.Directors.ToList();
            ViewBag.Actors = db.Actors.ToList();
            ViewBag.Years = db.Movies.Select(movie => movie.Year).Distinct().ToList();
            ViewBag.Years.Sort();

            var movies = db.Movies.ToList();

            switch (type)
            {
                case MovieFilterType.None:
                    break;

                case MovieFilterType.ByName:
                    if (value != null && !string.IsNullOrWhiteSpace(value))
                    {
                        var searchString = value.Trim(' ').ToLower();
                        movies = movies.Where(movie => movie.Name.ToLower().Contains(searchString)).ToList();
                    }
                    break;

                case MovieFilterType.ByYear:
                    int yearToFind;
                    if (int.TryParse(value, out yearToFind))
                    {
                        movies = movies.Where(movie => movie.Year == yearToFind).ToList();
                    }
                    break;

                case MovieFilterType.ByGenre:
                    int genreId;
                    if (int.TryParse(value, out genreId))
                    {
                        movies = db.Genres.FirstOrDefault(genre => genre.Id == genreId)?.Movies.ToList() ?? new List<Movie>();
                    }
                    break;

                case MovieFilterType.ByDirector:
                    int directorId;
                    if (int.TryParse(value, out directorId))
                    {
                        movies = db.Directors.FirstOrDefault(director => director.Id == directorId)?.Movies.ToList() ?? new List<Movie>();
                    }
                    break;

                case MovieFilterType.ByActor:
                    int actorId;
                    if (int.TryParse(value, out actorId))
                    {
                        movies = db.Actors.FirstOrDefault(actor => actor.Id == actorId)?.Movies.ToList() ?? new List<Movie>();
                    }
                    break;

                case MovieFilterType.ByMaximalPrice:
                    int maximumPrice;
                    if (int.TryParse(value, out maximumPrice))
                    {
                        movies = movies.Where(movie => movie.Price <= maximumPrice).ToList();
                    }
                    break;

                case MovieFilterType.ByMinRating:
                    int minimumRating;
                    if (int.TryParse(value, out minimumRating))
                    {
                        movies = movies.Where(movie => movie.Rating >= minimumRating).ToList();
                    }
                    break;

                default:
                    break;
            }

            foreach (var movie in movies)
            {
                if (movie.Description.Length > MaxMovieDescriptionLength)
                {
                    var shortDescription = movie.Description
                                                .Substring(0, MaxMovieDescriptionLength)
                                                .TrimEnd(' ', ',', '.', ':', ';');

                    movie.Description = shortDescription + "...";
                }
            }

            return View(movies);
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
