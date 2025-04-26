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

            var user = await dbContext.Users.FindAsync(userId);
            var taskCount = await dbContext.Earns.CountAsync(e => e.Completedby == userId);
            var moneyEarned = await dbContext.Earns
                                .Where(e => e.Completedby == userId)
                                .SumAsync(e => (decimal?)e.Price) ?? 0;

            var completedTasks = await dbContext.Earns
                                .Where(e => e.Completedby == userId)
                                .Select(e => new CompletedTaskDto
                                {
                                    TaskName = e.TaskName,
                                    Price = (decimal)e.Price
                                })
                                .ToListAsync();

            var postedTasks = await dbContext.Earns
                .Where(t => t.UserId == userId && t.Completedby==0)
                .Select(t => new PostedTaskDto
                {
                    Id = t.Id,
                    TaskName = t.TaskName,
                    Price = (decimal)t.Price,
                    TaskStatus = t.TaskStatus
                })
                .ToListAsync();

            var userServices = await dbContext.Vendors
                .Where(s => s.UserId == userId)
                .Select(s => new UserServiceDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();


            var viewModel = new ProfileViewModel
            {
                User = user,
                TaskCount = taskCount,
                MoneyEarned = moneyEarned,
                CompletedTasks = completedTasks,
                PostedTasks = postedTasks,
                UserServices = userServices
            };

            return View(viewModel);
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
            
    }
}
