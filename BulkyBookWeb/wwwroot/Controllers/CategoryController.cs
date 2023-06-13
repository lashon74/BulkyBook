using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            //More Validation throws a customer error 
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
      
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) 
            {
            return NotFound();
            }
            //var category = _db.Categories.FirstOrDefault(Column=> Column.Id == Id);
            var category = _db.Categories.Find(Id);

            if (category == null) 
            { return NotFound(); }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot match the Name.");
            }
            if (ModelState.IsValid)
            {
                //Updates controller
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";

                return RedirectToAction("Index", "Category");
            }
            return View(obj);

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            //var category = _db.Categories.FirstOrDefault(Column=> Column.Id == Id);
            var category = _db.Categories.Find(Id);

            if (category == null)
            { return NotFound(); }
            return View(category);
        }
        //Given action name to pass to controller
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id )
        {
            var category = _db.Categories.Find(Id);

            if (category == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index", "Category");

        }
    }
}
