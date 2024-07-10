using Ecomm.Data;
using Ecomm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EcommContext _context;
        public CategoryController()
        {
            _context = new EcommContext();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _context.Categories.ToListAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category categories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _context.Categories.Add(categories);
                    _context.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw ;
            }
        
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _context.Categories.Where(x => x.Cid == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category categories)
        {

            _context.Update(categories);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Categories.Where(x => x.Cid == id).FirstOrDefaultAsync();
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
