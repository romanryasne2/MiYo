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
    /// Provides views for employee
    /// </summary>
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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

        // GET: User
        public async Task<ActionResult> Index()
        {
            var model = new UserIndexViewModel();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            //fill model data
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;

            return View(model);
        }
    }
}