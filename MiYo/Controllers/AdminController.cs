using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MiYo.Models;

namespace MiYo.Controllers
{
    /// <summary>
    /// Provides views for admin
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        private MiYo.Models.Validation.RoleValidator roleValidator;
        public MiYo.Models.Validation.RoleValidator RoleValidator
        {
            get
            {
                return roleValidator ?? new Models.Validation.RoleValidator();
            }
            private set
            {
                roleValidator = value;
            }
        }

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
            RoleValidator = new Models.Validation.RoleValidator();
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleValidator = new Models.Validation.RoleValidator();
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin
        public async Task<ActionResult> Index()
        {
            // deny employee to see this page
            if (roleValidator.IsEmpoyee(User.Identity.GetUserId()))
                return RedirectToAction("Index", "User", routeValues: new { });

            var model = new AdminIndexViewModel();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            //fill model data
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;

            return View(model);
        }

        // GET: Admin/PairCreated
        public ActionResult PairCreated()
        {
            return View();
        }


        // GET: Admin/Requests
        public ActionResult Requests(string[] skills, 
            string locationCountry, string locationCity, string locationStreet, string locationHouse,
            string language)
        {
            //FIX: use employees who sent request only
            AdminRequestViewModel model = new AdminRequestViewModel();
            using(var db = new ApplicationDbContext())
            {
                //search for location. If part of location is spcecified it must match with db
                int locationId = db.Locations.Where(loc =>
                    locationCountry != null ? locationCountry.Equals(loc.Country) : true &&
                    locationCity != null ? locationCountry.Equals(loc.City) : true &&
                    locationStreet != null ? locationCountry.Equals(loc.Street) : true &&
                    locationHouse != null ? locationCountry.Equals(loc.House) : true
                    ).FirstOrDefault()?.Id ?? -1;
                int languageId = db.Languages.Where(
                    l => l.Name.Equals(language)).FirstOrDefault()?.Id ?? -1;
                
                //users with selected language
                var empIdList = db.EmployeeLanguages.
                    Where(el => el.LanguageId == languageId).
                    Select(el => el.EmployeeId);

                
                List<int> skillIdList = skills == null ? new List<int>() :
                    db.Skills.Where(s => skills.Contains(s.Name)).Select(s => s.Id).ToList();
                //users with specified language and skill
                empIdList = empIdList.Intersect(db.EmployeeSkills.
                    Where(es => skillIdList.Contains(es.SkillId)).
                    Select(es => es.EmployeeId));

                var employees = empIdList.Select(eId => EmployeeViewModel.FillById(eId)).ToList();
                model.Mentees = employees.Where(e => 
                    e.Skills.Where(s => s.State.Equals("WantToLearn")).Count() > 0).ToList();
                model.Mentors = employees.Where(e =>
                    e.Skills.Where(s => s.State.Equals("WantToTeach")).Count() > 0).ToList();
            }
            return View(model);
        }

        // POST: Admin/Requests
        [HttpPost]
        public async Task<ActionResult> Requests(AdminRequestViewModel request)
        {
            //Handling selected mentors and mentees here

            return RedirectToAction("PairCreated");
        }

    }
}