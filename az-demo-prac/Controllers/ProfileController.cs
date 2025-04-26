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
            var user = await dbContext.Users.Where(x=>x.Id == userId).FirstOrDefaultAsync();
            return View(user);
        }

        public async Task<IActionResult> GetRegisterVendorsPage()
        {
            return View();
        }

        public async Task<IActionResult> RegisterAsVendor(Vendor vendor)
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var user = await dbContext.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
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

        public async Task<IActionResult> UserProfile()
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var user = await dbContext.Users.FindAsync(userId);
            var taskCount = await GetTaskCount(userId);
            //var moneyEarned = await GetMoneyEarned(userId);

            var viewModel = new ProfileViewModel
            {
                User = user,
                TaskCount = taskCount,
                //MoneyEarned = moneyEarned
            };

            return View(viewModel);
        }

        public async Task<int> GetTaskCount(int userId)
        {
            return await dbContext.Earns.Where(t => t.UserId == userId).CountAsync();
        }

        //public async Task<decimal> GetMoneyEarned(int userId)
        //{
        //    return await dbContext.Earns
        //                 .Where(t => t.userId == userId)
        //                 .SumAsync(t => t.PaymentAmount);
        //}

    }
}
