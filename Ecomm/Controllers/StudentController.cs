using Ecomm.Data;
using Ecomm.Models;
using Ecomm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class StudentController : Controller
{
    private readonly EcommContext _context;

    public StudentController()
    {
        _context = new EcommContext();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(StudentRegistration std, IFormFile image)
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
            std.ImageFile = upload;

            Student student = new Student()
            {
                StdFirstName = std.StdFirstName,
                StdLastName = std.StdLastName,
                StdAddress = std.StdAddress,
                StdPassword = HashPassword(std.StdPassword),
                StdAge = std.StdAge,
                StdContact = std.StdContact,
                StdBirthDate = std.StdBirthDate,
                StdEmail = std.StdEmail,
                ImageFile = std.ImageFile,
            };

            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(StudentLogin usr)
    {
        if (ModelState.IsValid)
        {
            string dbpass = HashPassword(usr.StdPassword);

            var check = _context.Students.Where(x => x.StdEmail == usr.StdEmail && x.StdPassword == dbpass);

            if (check.Count() > 0)
            {
                return RedirectToAction("Index", "Brand");
            }
        }
        return View();
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }

}
