using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_Restaurant.DAL;
using Demo_Restaurant.Models;
using PagedList;

namespace Demo_Restaurant.Controllers
{
    public class RecipesController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Recipes
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "id_asc";
            ViewBag.DateSortParm = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewBag.isAvailableSortParm = sortOrder == "avail_asc" ? "avail_desc" : "avail_asc";
            ViewBag.QuantitySortParm = sortOrder == "quantity_asc" ? "quantity_desc" : "quantity_asc";
            ViewBag.NameSortParm = sortOrder == "name_asc" ? "name_desc" : "name_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var recipes = from s in db.Recipes
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.RecipeName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    recipes = recipes.OrderByDescending(s => s.ID);
                    break;
                case "name_desc":
                    recipes = recipes.OrderByDescending(s => s.RecipeName);
                    break;
                case "name_asc":
                    recipes = recipes.OrderBy(s => s.RecipeName);
                    break;
                case "quantity_desc":
                    recipes = recipes.OrderByDescending(s => s.Quantity);
                    break;
                case "quantity_asc":
                    recipes = recipes.OrderBy(s => s.Quantity);
                    break;
                case "avail_desc":
                    recipes = recipes.OrderByDescending(s => s.isAvailable);
                    break;
                case "avail_asc":
                    recipes = recipes.OrderBy(s => s.isAvailable);
                    break;
                case "date_desc":
                    recipes = recipes.OrderByDescending(s => s.RegisterDate);
                    break;
                case "date_asc":
                    recipes = recipes.OrderBy(s => s.RegisterDate);
                    break;
                default:
                    recipes = recipes.OrderBy(s => s.ID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(recipes.ToPagedList(pageNumber, pageSize));
            
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RecipeName,Quantity,isAvailable,RegisterDate")] Recipe recipe)
        {
            if(recipe.Quantity>0)
            {
                recipe.isAvailable = true;
            }
            else
            {
                recipe.isAvailable = false;
            }

            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RecipeName,Quantity,isAvailable,RegisterDate")] Recipe recipe)
        {
            if (recipe.Quantity > 0)
            {
                recipe.isAvailable = true;
            }
            else
            {
                recipe.isAvailable = false;
            }

            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
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
