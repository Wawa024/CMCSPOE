using CMCSPOE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMCSPOE.Controllers
{
    public class ManagerController : Controller
    {
        private readonly InMemoryDbContext _dbContext;

        public ManagerController(InMemoryDbContext dbContext)
        {
            _dbContext = new InMemoryDbContext();
            _dbContext.Database.EnsureCreated();
        }

        public IActionResult ApproveRejectClaim()
        {
            var claims = _dbContext.Claims.Where(c => c.Status == "Pending").ToList();
            return View(claims);
        }

        [HttpPost]
        public IActionResult ApproveClaim(int id)
        {
            var claim = _dbContext.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
            }
            return RedirectToAction("ApproveRejectClaim");
        }

        [HttpPost]
        public IActionResult RejectClaim(int id)
        {
            var claim = _dbContext.Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
            }
            return RedirectToAction("ApproveRejectClaim");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
