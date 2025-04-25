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

        public async Task<IActionResult> GetRegisterVendorsPage()
        {
            return View();
        }

        public async Task<IActionResult> RegisterAsVendor(Vendor vendor)
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var user = await dbContext.Users.Where(x => x.id == userId).FirstOrDefaultAsync();
            var registration = new Vendor {
                Name = vendor.Name,
                Description = vendor.Description,
                UserId = userId,
                AddressLine1 = vendor.AddressLine1,
                AddressLine2 = vendor.AddressLine2,
                City = vendor.City,
                Country = vendor.Country
            };
            await dbContext.Vendors.AddAsync(registration);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Vendors", "Dashboard");
        }
    }
}
