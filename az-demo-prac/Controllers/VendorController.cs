using az_demo_prac.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace az_demo_prac.Controllers
{
    public class VendorController : Controller
    {
        private readonly dbContext dbContext;

        public VendorController(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> GetVendorEditPage(int id)
        {
            var vendor = await dbContext.Vendors.FirstOrDefaultAsync(x=>x.Id == id);
            return View(vendor);
        }
    }
}
