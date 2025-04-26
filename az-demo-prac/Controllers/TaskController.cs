using az_demo_prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskStatus = az_demo_prac.Models.TaskStatus;

namespace az_demo_prac.Controllers
{
    public class TaskController : Controller
    {
        private readonly dbContext dbContext;

        public TaskController(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var taskDetails = await dbContext.Earns.Where(x => x.Id == id).FirstOrDefaultAsync();
            var postedby = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == taskDetails.UserId);

            var details = new TaskDetailsViewModel
            {
                EarnTask = taskDetails,
                Postedby = postedby.FirstName + " " + postedby.LastName,
                Phone = postedby.Phone,
                Email = postedby.Email,
            };

            return View("~/Views/Dashboard/GetDetails.cshtml", details);
        }


        [HttpPost("AcceptTask/{taskId}")]
        public async Task<IActionResult> AcceptTask(int taskId)
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var task = await dbContext.Earns.FirstOrDefaultAsync(x => x.Id == taskId);

            if (user == null)
            {
                return NotFound();
            }

            user.AssignedTask = taskId;
            task.TaskStatus = TaskStatus.Accepted;
            await dbContext.SaveChangesAsync();

            return RedirectToAction("GetDetails", new { id = taskId });
        }

        [HttpPost("CompleteTask/{id}")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var taskAssignedUser = dbContext.Users.FirstOrDefault(x => x.AssignedTask == id);
            var task = await dbContext.Earns.FirstOrDefaultAsync(x => x.Id == id);
            task.Completedby = taskAssignedUser.Id; 
            if (taskAssignedUser == null)
            {
                return NotFound();
            }

            task.TaskStatus = TaskStatus.Completed;
            await dbContext.SaveChangesAsync();

            return RedirectToAction("GetProfile","Profile");
        }

        [HttpGet("EditTask/{Id}")]
        public async Task<IActionResult> GetEditTaskPage(int Id) 
        {
            var task = await dbContext.Earns.FirstOrDefaultAsync(x=>x.Id == Id);
            return View(task);
        }
    }
}
