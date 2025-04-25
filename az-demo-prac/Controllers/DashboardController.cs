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
            var work = await dbContext.Earns.ToListAsync();
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
                taskName = earn.taskName,
                userId = earn.userId,
                taskDetails = earn.taskDetails,
                flatNo = earn.flatNo,
                addressline1 = earn.addressline1,
                addressline2 = earn.addressline2,
                state = earn.state,
                country = earn.country
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

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var taskDetails = await dbContext.Earns.Where(x=>x.id == id).FirstOrDefaultAsync();
            return View(taskDetails);
        }

    }
}
