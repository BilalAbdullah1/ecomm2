using Ecomm.Data;
using Ecomm.Models;
using Ecomm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;

namespace Ecomm.Controllers
{
    public class UsersController : Controller
    {
        private readonly EcommContext _dbcontext;
        public UsersController()
        {
            _dbcontext = new EcommContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            ViewBag.Roles = new SelectList (_dbcontext.Roles , "RId", "RName");
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UsersRegistration usersreg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkEmail = _dbcontext.users.Where(x => x.UEmail == usersreg.UEmail);
                    if (checkEmail.Count() == 0)
                    {
                        Users user = new Users()
                        {
                            UName = usersreg.UName,
                            UEmail = usersreg.UEmail,
                            Uid = usersreg.Uid,
                            UPassword = HashPassword(usersreg.UPassword),
                            URole = usersreg.URole
                        };
                        _dbcontext.users.Add(user);
                        _dbcontext.SaveChanges();
                        return RedirectToAction("Login");
                    }
                }
            }
            catch (Exception)
            {

                throw;
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users usr)
        {
            string dbpass = HashPassword(usr.UPassword);

            var check = _dbcontext.users.Where(x => x.UEmail== usr.UEmail && x.UPassword == dbpass);

            if (check.Count() > 0)
            {

                return RedirectToAction("Index","Brand");
            }
            //else
            //{
            //    ViewBag.msg = "Invalid email/password";
            //}
            return View();
        }

    }
}
