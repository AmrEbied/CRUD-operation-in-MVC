using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Serilog;
using TaxiBooking.Models.DTO.UserDto;
using TaxiBooking.Models.Entities;
using TaxiBooking.Repositories;

namespace TaxiBooking.Controllers
{
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

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LogInDto logIn)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(logIn);
                }
                var result = await SignInManager.PasswordSignInAsync(logIn.UserName, logIn.Password, true, shouldLockout: false);
                if (result == SignInStatus.Success)
                {
                    IUserRepository userRepository = new UserRepository();
                    var user = await UserManager.FindByNameAsync(logIn.UserName);
                    HttpCookie cookie = new HttpCookie("Token");
                    cookie.Value = userRepository.GetToken(user.Id);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    return Redirect("Car/index");
                  //  return Json(userRepository.GetToken(user.Id));
                }
                ModelState.AddModelError("", "Please check your data");
                return View(logIn);
            }
            catch (Exception ex )
            {
                Log.Error(ex.Message, "Login api");
                return Redirect("User/Login");
            }
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            var loginModel = new LogInDto();
            return View(loginModel);
        }
    }
}