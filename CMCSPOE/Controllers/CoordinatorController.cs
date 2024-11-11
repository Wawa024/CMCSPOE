using CMCSPOE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMCSPOE.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly InMemoryDbContext _dbContext;

        public CoordinatorController(InMemoryDbContext dbContext)
        {
            _dbContext = new InMemoryDbContext();
            _dbContext.Database.EnsureCreated();
        }
        public IActionResult Index()
        {
            var claims = (from c in _dbContext.Claims
                          join l in _dbContext.Users on c.LecturerId equals l.Id
                          where c.Status == "Pending"
                          select new ClaimViewModel
                          {
                              Id = c.Id,
                              Status = c.Status,
                              LecturerId = c.LecturerId,
                              LectureName = l.Name ?? "",
                              AdditionalNotes = c.AdditionalNotes,
                              ClaimValue = c.ClaimValue,
                              Description = c.Description,
                              HourlyRate = c.HourlyRate,
                              HoursWorked = c.HoursWorked,
                              SupportingDocument = c.SupportingDocument,
                              DateCreated = c.DateCreated
                          }).OrderByDescending(x => x.DateCreated).ToList();
            return View(claims);
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


        [HttpPost]
        public IActionResult UpdateStatus(int claimId, string status)
        {
            var claim = _dbContext.Claims.Find(claimId);
            if (claim != null)
            {
                claim.Status = status;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
