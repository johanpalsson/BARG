using BARG.Models;
using BARG.ViewModels;
using Microsoft.AspNet.Identity;
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

        public ActionResult Detail(int id)
        {

            var userId = User.Identity.GetUserId();
            var assessment = _context.Assessments.SingleOrDefault(m => m.Id == id && m.AssessmentUser.Id == userId);




            if (assessment == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AssessmentsViewModel
            {
                Heading = "Edit Assessment",
                Id = assessment.Id,
                RegionLookUp = _context.Regions.ToList(),
                RegionsList = assessment.Regions
            };

            return View(viewModel);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(AssessmentsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel2 = new AssessmentsViewModel
                {
                    Id = viewModel.Id,
                    RegionLookUp = _context.Regions.ToList(),


                };
                return View("NewAssessment", viewModel);
            }

            var userId = User.Identity.GetUserId();


            var assessment = _context.Assessments.Single(m => m.Id == viewModel.Id && m.AssessmentUser.Id == userId);


            _context.SaveChanges();

            return RedirectToAction("Detail", assessment);
        }




        [Authorize]
        public ActionResult NewAssessment()
        {
            var regions = _context.Regions.ToList();
            var viewModel = new AssessmentsViewModel
            {
                Heading = "New Assessment",
                RegionLookUp = regions

            };
            return View(viewModel);
        }



        public ActionResult Save(AssessmentsViewModel reg)
        {
            var userId = User.Identity.GetUserId();
            // ändrat från single to singleordefault för att inte få ett null exception

            var user = _context.Users.Single(u => u.Id == userId);

            var regionList = _context.Regions.Where(m => m.Id == reg.Id).ToList();


            var assessment = new Assessment
            {
                AssessmentUser = user,
                Regions = regionList

            };

            _context.Assessments.Add(assessment);
            _context.SaveChanges();

            return RedirectToAction("Detail", assessment);
        }
    }
}