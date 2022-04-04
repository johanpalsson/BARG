using BARG.Models;
using BARG.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BARG.Controllers
{
    public class AssessmentsController : Controller
    {
        private ApplicationDbContext _context;

        public AssessmentsController()
        {
            _context = new ApplicationDbContext();
        }

        // Get Assessments
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();


            var assessments = _context.Assessments
                .Where(x => x.AssessmentUser.Id == userId)
                .ToList();

            if (assessments == null)
            {
                return View("Home");
            }

            return View(assessments);
        }

        [Authorize]
        public ActionResult NewAssessment()
        {
            var regions = _context.Regions.ToList();
            var viewModel = new AssessmentsViewModel
            {
                Heading = "New Assessment",
                Regions = regions

            };
            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AssessmentsViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    var viewModel2 = new AssessmentsViewModel
            //    {
            //        Id = viewModel.Id,
            //        Regions = _context.Regions.ToList(),


            //    };
            //    return View("NewAssessment", viewModel);
            //}




            var assessment = _context.SaveChanges();
            _context.SaveChanges();

            return RedirectToAction("Detail", assessment);
        }

        public ActionResult Detail(int id)
        {



            return View();
        }

        public ActionResult Save(List<Region> regions)
        {
            var userId = User.Identity.GetUserId();
            // ändrat från single to singleordefault för att inte få ett null exception

            var user = _context.Users.Single(u => u.Id == userId);

            var region = _context.Regions.ToList();

            var viewModel = new AssessmentsViewModel
            {
                AssessmentUser = user,
                RegionsList = regions
            };

            var assessment = new Assessment
            {
                AssessmentUser = user,
                Regions = regions

            };

            _context.Assessments.Add(assessment);
            _context.SaveChanges();

            return RedirectToAction("Index", viewModel);
        }
    }
}