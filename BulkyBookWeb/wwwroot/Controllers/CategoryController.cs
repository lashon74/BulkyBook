using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //var odjCategoryList = _db.Categories.ToList();
            IEnumerable<Category> odjCategoryList = _db.Categories;
            return View(odjCategoryList);
        }
        //Get action method
        public IActionResult Create()
        {
            
            return View();
        }

        //Post action method needs httppost attribute 
        [HttpPost]
        [ValidateAntiForgeryToken]//injects key into form to prevent forgery
        public IActionResult Create(Category obj )
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
      
        }
    }
}
