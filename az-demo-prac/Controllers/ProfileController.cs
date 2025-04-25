using az_demo_prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace az_demo_prac.Controllers
{
    public class ProfileController : Controller
    {
        private readonly dbContext dbContext;

        public ProfileController(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> GetProfile()
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var user = await dbContext.Users.Where(x=>x.id == userId).FirstOrDefaultAsync();
            return View(user);
        }
    }
}
