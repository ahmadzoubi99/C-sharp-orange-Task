using ExtraTask.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraTask.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyContext _dbContext;
        public AuthController(MyContext myContext)
        {
            this._dbContext = myContext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            // Clear the session data
            HttpContext.Session.Clear();

            // Redirect to the login page or home page
            return RedirectToAction("Login", "Auth"); // Adjust the controller and action as necessary
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var auth = _dbContext.Teachers.Where(p => p.Username == username && p.Password == password).FirstOrDefault();
            if (auth != null)
            {
                HttpContext.Session.SetInt32("TeacherID", auth.TeacherID);
                HttpContext.Session.SetString("TeacherName", auth.FullName);
              return  RedirectToAction("Index","Teachers");
            }
            else
            {
                return View();
            }
            return View();

        }
    } 
}
