using ecomm.Data;
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
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Categories.Where(x => x.Cid == id).FirstOrDefaultAsync();
            _context.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
