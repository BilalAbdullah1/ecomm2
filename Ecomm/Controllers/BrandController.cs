using Ecomm.Data;
using   Ecomm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Controllers
{
    public class BrandController : Controller
    {
        private readonly EcommContext _dbContext;

        public BrandController()
        {
            _dbContext = new EcommContext();    
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _dbContext.Brands.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brnd)
        {
            if (ModelState.IsValid)
            {
                var data = _dbContext.Brands.Add(brnd);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        
        }

        public IActionResult Delete(int? id)
        {
            var data = _dbContext.Brands.Where(x => x.Bid == id).FirstOrDefault();
            _dbContext.Remove(data);
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _dbContext.Brands.Where(x => x.Bid == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit( Brand brnd)
        {
            _dbContext.Update(brnd);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
