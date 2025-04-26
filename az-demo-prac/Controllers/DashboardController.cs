using az_demo_prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace az_demo_prac.Controllers
{
    public class DashboardController : Controller
    {
        private readonly dbContext dbContext;

        public DashboardController(dbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public async Task<IActionResult> ReturnDashboard()
        {
            return View("~/Views/Account/Dashboard.cshtml");
        }

        public async Task<IActionResult> Earn()
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var work = await dbContext.Earns.Where(x=>x.Completedby==0 && x.UserId!=userId).ToListAsync();
            return View(work);
        }

        public async Task<IActionResult> Spend(Earn earn)
        {
            return View(earn);
        }

        public async Task<IActionResult> AddTask(Earn earn)
        {
            var newTask = new Earn
            {
                TaskName = earn.TaskName,
                UserId = int.Parse(HttpContext.Session.GetString("UserId")),
                Price = earn.Price,
                TaskDetails = earn.TaskDetails,
                FlatNo = earn.FlatNo,
                Addressline1 = earn.Addressline1,
                Addressline2 = earn.Addressline2,
                City = earn.City,
                State = earn.State,
                Country = "India"
            };
            await dbContext.Earns.AddAsync(newTask);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Earn");
        }

        public async Task<IActionResult> Vendors()
        {
            var vendors = await dbContext.Vendors.ToListAsync();
            return View(vendors);
        }

        [HttpGet("VendorsByDiscipline/{TaskDiscipline}")]
        public async Task<IActionResult> GetVendorsByDiscipline(Discipline TaskDiscipline)
        {
            var vendorsByDiscipline = await dbContext.Vendors.Where(x=>x.TaskDiscipline == TaskDiscipline).ToListAsync();
            return View(vendorsByDiscipline);
        }

    }
}
