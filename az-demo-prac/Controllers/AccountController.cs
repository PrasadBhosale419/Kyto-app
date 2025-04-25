using az_demo_prac.Interfaces;
using az_demo_prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace az_demo_prac.Controllers
{
    public class AccountController : Controller
    {
        public dbContext dbContext { get; }

        public AccountController(dbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public ActionResult GetLoginPage()
        {
            return RedirectToAction("Index", "Home");
        }

        
        public async Task<IActionResult> Login(User user)
        {
            var validUser = await dbContext.Users.Where(x => x.email == user.email).FirstOrDefaultAsync();
            HttpContext.Session.SetString("UserId", validUser.id.ToString());
            if (validUser != null)
            {
                if (validUser.password == user.password)
                {
                    return View("Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid password");
                    return RedirectToAction("Index", "Home");
                }
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Invalid email");
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> GetRegisterPage() 
        {
            return View();
        }

        public async Task<IActionResult> Logout() 
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public async Task<IActionResult> RegisterUser(User user) 
        {
            var newUser = new User
            {
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                password = user.password
            };

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
