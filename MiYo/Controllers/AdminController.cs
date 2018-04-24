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
            // deny employee to see this page
            if (roleValidator.IsEmpoyee(User.Identity.GetUserId()))
                return RedirectToAction("Index", "User", routeValues: new { });

            //FIX: use employees who sent request only
            AdminRequestViewModel model = new AdminRequestViewModel();
            var empIdList = new EmployeeRequestFilter().FilterEmployee(skills, 
                locationCountry, locationCity, locationStreet, locationHouse, language
                );
            using (var db = new ApplicationDbContext())
            {                
                var employees = empIdList.Select(eId => EmployeeViewModel.FillById(eId)).ToList();
                model.Mentees = employees.Where(e => 
                    e.Skills.Where(s => s.State.Equals("Want to learn")).Count() > 0).ToList();
                model.Mentors = employees.Where(e =>
                    e.Skills.Where(s => s.State.Equals("Want to teach")).Count() > 0).ToList();
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