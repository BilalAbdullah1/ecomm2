using Ecomm.Data;
using Ecomm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Ecomm.Controllers
{
    public class StaffController : Controller
    {
        private readonly EcommContext _dbcontext;
        public StaffController()
        {
            _dbcontext = new EcommContext();
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Competitions

        [HttpGet]
        public IActionResult Competition()
        {
            var data = _dbcontext.Competitions.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult CompetitionCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CompetitionCreate(Competitions comp)
        {
            var data = _dbcontext.Competitions.Add(comp);
            _dbcontext.SaveChanges();
            return RedirectToAction("Competition");
        }

        [HttpGet]
        public IActionResult CompetitionEdit(int? id)
        {
            var data = _dbcontext.Competitions.Where(x => x.CopetitionId == id).FirstOrDefault();
            return View(data);
        }


        [HttpPost]
        public IActionResult CompetitionEdit(Competitions comp)
        {
            var data = _dbcontext.Competitions.Update(comp);
            _dbcontext.SaveChanges();
            return RedirectToAction("Competition");
        }

        public IActionResult CompetitionDelete(int? id)
        {
            var data = _dbcontext.Competitions.Where(x => x.CopetitionId == id).FirstOrDefault();
            _dbcontext.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction("Competition");

        }
        #endregion

        #region Awards
        [HttpGet]
        public IActionResult Awards()
        {
            var data = _dbcontext.Awards.Include(x => x.Student).Include(x => x.Competitions).ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult AwardsCreate()
        {
            ViewBag.Students = new SelectList(_dbcontext.Students, "StdId", "StdFirstName");
            ViewBag.Competitions = new SelectList(_dbcontext.Competitions, "CopetitionId", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult AwardsCreate(Awards award)
        {
            var data = _dbcontext.Awards.Add(award);
            _dbcontext.SaveChanges();

            return RedirectToAction("Awards");
        }

        [HttpGet]
        public IActionResult AwardsEdit(int? id)
        {
            var data = _dbcontext.Awards.Where(x => x.AwardId == id).FirstOrDefault();
            setData();
            return View(data);
        }

        private void setData()
        {
            ViewData["Students"] = new SelectList(_dbcontext.Students, "StdId", "StdFirstName");
            ViewData["Competitions"] = new SelectList(_dbcontext.Competitions, "CopetitionId", "Title");

        }

        [HttpPost]
        public IActionResult AwardsEdit(Awards award)
        {
            var data = _dbcontext.Awards.Update(award);
            _dbcontext.SaveChanges();

            return RedirectToAction("Awards");
        }

        public IActionResult AwardsDelete(int? id)
        {
            var data = _dbcontext.Awards.Where(x => x.AwardId == id).FirstOrDefault();
            _dbcontext.Awards.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction("Awards");
        }

        #endregion

        #region Upcoming Exhibitions
        [HttpGet]
        public IActionResult UpcomingExhibitions()
        {
            var data = _dbcontext.upcomingExhibitions.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult UpcomingExhibitionsCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpcomingExhibitionsCreate(UpcomingExhibitions exhib)
        {
            var data = _dbcontext.upcomingExhibitions.Add(exhib);
            _dbcontext.SaveChanges();

            return RedirectToAction("UpcomingExhibitions");
        }

        [HttpGet]
        public IActionResult UpcomingExhibitionsEdit(int? id)
        {
            var data = _dbcontext.upcomingExhibitions.Where(x => x.UpExbId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult UpcomingExhibitionsEdit(UpcomingExhibitions exhib)
        {
            var data = _dbcontext.upcomingExhibitions.Update(exhib);
            _dbcontext.SaveChanges();

            return RedirectToAction("UpcomingExhibitions");
        }
        public IActionResult UpcomingExhibitionsDelete(int? id)
        {
            var data = _dbcontext.upcomingExhibitions.Where(x => x.UpExbId == id).FirstOrDefault();
            _dbcontext.upcomingExhibitions.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction("UpcomingExhibitions");
        }
        #endregion

        #region Submissions
        [HttpGet]
        public IActionResult Submissions()
        {
            var data = _dbcontext.submissions.Include(x => x.Student).Include(x => x.Competitions).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult SubmissionsCreate()
        {
            ViewBag.Students = new SelectList(_dbcontext.Students, "StdId", "StdFirstName");
            ViewBag.Competitions = new SelectList(_dbcontext.Competitions, "CopetitionId", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult SubmissionsCreate(Submissions submission, IFormFile image)
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
                    submission.File = upload;


                    var data = _dbcontext.submissions.Add(submission);
                    _dbcontext.SaveChanges();
                    return RedirectToAction("Submissions");

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();

        }

        [HttpGet]
        public IActionResult SubmissionsEdit(int? id)
        {
            var data = _dbcontext.submissions.Where(x => x.SubId == id).FirstOrDefault();
            setData();
            return View(data);
        }

        [HttpPost]
        public IActionResult SubmissionsEdit(int? id, Submissions sub, IFormFile image)
        {
            if (image == null)
            {
                _dbcontext.Update(sub);
                _dbcontext.SaveChanges();
                return RedirectToAction("Submissions");
            }
            else
            {
                try
                {
                    var fileName = Path.GetFileName(image.FileName);
                    string imgfolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/myfiles");
                    string filePath = Path.Combine(imgfolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }

                    string upload = Path.Combine("myfiles", fileName);
                    sub.File = upload;
                    _dbcontext.Update(sub);
                    _dbcontext.SaveChanges();
                    return RedirectToAction("Submissions");
                }
                catch (Exception e)
                {
                    ViewBag.msg = e.Message;
                }
            }
            //ViewData["PCat"] = new SelectList(dbconn.Categories, "CId", "CName");
            //var data = await dbconn.Products.FindAsync(id);
            //return View(data);
            return View();
            //var data = _dbcontext.upcomingExhibitions.Update(exhib);
            //    _dbcontext.SaveChanges();

            //    return RedirectToAction("Submissions");
        }
        public IActionResult SubmissionsDelete(int? id)
        {
            var data = _dbcontext.submissions.Where(x => x.SubId == id).FirstOrDefault();
            _dbcontext.submissions.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction("Submissions");
        }

        [HttpGet]
        public IActionResult SubmissionsMark()
        {
            var data = _dbcontext.submissions.Include(x => x.Student).Include(x => x.Competitions).ToList();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SubmissionsMark(int id)
        {
            var submission = await _dbcontext.submissions.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }

            submission.Mark = !submission.Mark;
            await _dbcontext.SaveChangesAsync();

            return RedirectToAction("SubmissionsMark");



        }
        #endregion

        #region Exhibitions
        [HttpGet]
        public IActionResult Exhibitions()
        {
            var data = _dbcontext.exhibitions.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult ExhibitionsCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExhibitionsCreate(Exhibitions exhib)
        {
            var data = _dbcontext.exhibitions.Add(exhib);
            _dbcontext.SaveChanges();

            return RedirectToAction("Exhibitions");
        }

        [HttpGet]
        public IActionResult ExhibitionsEdit(int? id)
        {
            var data = _dbcontext.exhibitions.Where(x => x.ExbId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public IActionResult ExhibitionsEdit(Exhibitions exhib)
        {
            var data = _dbcontext.exhibitions.Update(exhib);
            _dbcontext.SaveChanges();

            return RedirectToAction("Exhibitions");
        }
        public IActionResult ExhibitionsDelete(int? id)
        {
            var data = _dbcontext.exhibitions.Where(x => x.ExbId == id).FirstOrDefault();
            _dbcontext.exhibitions.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction("Exhibitions");
        }
        #endregion

        #region Exhibition Submissions
        [HttpGet]
        public IActionResult ExhibitionSubmissions()
        {
            var data = _dbcontext.ExhibtionSubmission.Include(x => x.Exhibition).Include(x => x.Submission).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult ExhibitionSubmissionsCreate()
        {
            ViewBag.Exhibition = new SelectList(_dbcontext.exhibitions, "ExbId", "ExbTitle");
            ViewBag.Submission = new SelectList(_dbcontext.submissions, "SubId", "Description");
            return View();
        }

        [HttpPost]
        public IActionResult ExhibitionSubmissionsCreate(ExhibitionSubmissions exhsub)
        {
            var data = _dbcontext.ExhibtionSubmission.Add(exhsub);
            _dbcontext.SaveChanges();
            return RedirectToAction("ExhibitionSubmissions");
        }

        [HttpGet]
        public IActionResult ExhibitionSubmissionsEdit(int? id)
        {
            var data = _dbcontext.ExhibtionSubmission.Where(x => x.ExhibitionSubmissionID == id).FirstOrDefault();
            setDatasubExhibtion();
            return View(data);
        }

        private void setDatasubExhibtion()
        {
            ViewData["Exhibition"] = new SelectList(_dbcontext.exhibitions, "ExbId", "ExbTitle");
            ViewData["Submission"] = new SelectList(_dbcontext.submissions, "SubId", "Description");
        }

        [HttpPost]
        public IActionResult ExhibitionSubmissionsEdit(ExhibitionSubmissions exhsub)
        {
            var data= _dbcontext.ExhibtionSubmission.Update(exhsub);
            _dbcontext.SaveChanges();
            return RedirectToAction("ExhibitionSubmissions");
        }
        public IActionResult ExhibitionSubmissionsDelete(int? id)
        {
            var data = _dbcontext.ExhibtionSubmission.Where(x => x.ExhibitionSubmissionID == id).FirstOrDefault();
            _dbcontext.ExhibtionSubmission.Remove(data);
            _dbcontext.SaveChanges();
            return RedirectToAction("ExhibitionSubmissions");
        }
        #endregion

    }
}
