using Ecomm.Data;
using Ecomm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Controllers
{
    public class ProductController : Controller
    {
        private readonly EcommContext _dbContext;

        public ProductController()
        {
            _dbContext = new EcommContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _dbContext.Products.Include(x => x.Brand).Include(x => x.category).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Brand = new SelectList(_dbContext.Brands, "Bid", "BName");
            ViewBag.Category = new SelectList(_dbContext.Categories, "Cid", "category");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product prd, IFormFile image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (image != null && image.Length > 0)
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        string imgfolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/myfiles");

                        if (!Directory.Exists(imgfolder))
                        {
                            Directory.CreateDirectory(imgfolder);
                        }

                        string filePath = Path.Combine(imgfolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        string upload = Path.Combine("myfiles", fileName);
                        prd.PImage = upload;

                        _dbContext.Products.Add(prd);
                        _dbContext.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();  

        } 

        public IActionResult Delete(int? id)
        {
            var data = _dbContext.Products.Where(x => x.Pid == id).FirstOrDefault();
            _dbContext.Remove(data);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var data = _dbContext.Products.Where(x => x.Pid == id).FirstOrDefault();
            SetData();
            return View(data);
        }

        private void SetData()
        {
            ViewData["Brand"] = new SelectList(_dbContext.Brands, "Bid", "BName");
            ViewData["Category"] = new SelectList(_dbContext.Categories, "Cid", "category");
        }

        [HttpPost]
        public IActionResult Edit(Product prd, IFormFile image)
        {
            try
            {
                if (image != null && image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    string imgfolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/myfiles");

                    if (!Directory.Exists(imgfolder))
                    {
                        Directory.CreateDirectory(imgfolder);
                    }

                    string filePath = Path.Combine(imgfolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }

                    string upload = Path.Combine("myfiles", fileName);
                    prd.PImage = upload;

                    _dbContext.Update(prd);
                    SetData();
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                //else
                //{
                //  //  ViewBag.msg = "Kindly select Product Image";
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
    }
}
