using System.Diagnostics;
using az_demo_prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace az_demo_prac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContext dbContext;

        public HomeController(ILogger<HomeController> logger, dbContext _dbContext)
        {
            _logger = logger;
            dbContext = _dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetUsers() 
        {
            var users =  await dbContext.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
