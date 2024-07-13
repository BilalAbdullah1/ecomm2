using Ecomm.Data;
using Ecomm.Models;
using Ecomm.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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
            ViewBag.Roles = new SelectList(_dbcontext.Roles, "RId", "RName");
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
                else
                {
                    ViewBag.msg = "User Password And Confirm Password not match";
                    ViewBag.Roles = new SelectList(_dbcontext.Roles, "RId", "RName");
                    return View("Registration");
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
        public IActionResult Login(UserLogin usr)
        {
            if (ModelState.IsValid)
            {
                string dbpass = HashPassword(usr.UPassword);

                var check = _dbcontext.users.Where(x => x.UEmail == usr.UEmail && x.UPassword == dbpass);

                if (check.Count() > 0)
                {
                    return RedirectToAction("Index", "Brand");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(Users usr)
        {
            var data = _dbcontext.users.Where(x => x.UEmail == usr.UEmail).ToList();

            if (data.Count() > 0)
            {
                var otp = GenerateOTP();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                HttpContext.Session.SetString("OTP", otp);
                HttpContext.Session.SetString("Email", usr.UEmail);

                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("bilalabdullah5393@gmail.com", "bqyawuynnpdkhxrl");

                MailMessage msg = new MailMessage("bilalabdullah5393@gmail.com", usr.UEmail);
                msg.Subject = "OTP";
                msg.Body = "Your OTP number is " + otp;
                msg.ReplyTo = new MailAddress(usr.UEmail);
                client.Send(msg);
                ViewBag.Message = "Mail sent successfully";
                return RedirectToAction("SetOTP");
            }
            else
            {
                ViewBag.Message = "You Entered Wrong Email Please Re-enter Correct Email";
            }
            return View();
        }

        [HttpGet]
        public IActionResult SetOTP()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetOTP(Users usr, string otp)
        {
            var sessionOtp = HttpContext.Session.GetString("OTP");

            if (sessionOtp == otp)
            {
                ViewBag.Message = "Email Verified Succesfully";
                return RedirectToAction("PasswordChange");
            }
            else
            {
                ViewBag.Message = "You Entered Wrong OTP";
            }
            return View();
        }

        private string GenerateOTP(int length = 6)
        {
            var random = new Random();
            var otp = new char[length];
            for (int i = 0; i < length; i++)
            {
                otp[i] = (char)random.Next('0', '9' + 1);
            }
            return new string(otp);
        }

        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PasswordChange(UsersRegistration usr)
        {
            var email = HttpContext.Session.GetString("Email");

            var user = _dbcontext.users.FirstOrDefault(x => x.UEmail == email);
            if (user != null && usr.UPassword == usr.ConfirmPassword)
            {
                user.UPassword = HashPassword(usr.UPassword);
                _dbcontext.users.Update(user);
                _dbcontext.SaveChanges();

                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.msg = "User Password And Confirm Password not match";
                return View();
            }
        }

    }
}
