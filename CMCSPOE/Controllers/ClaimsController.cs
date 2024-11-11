using CMCSPOE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMCSPOE.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly InMemoryDbContext _dbContext;

        public ClaimsController( )
        {
            _dbContext = new InMemoryDbContext();
            _dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(ClaimModel claim)
        {
            claim.DateCreated = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (claim.supportingDocument != null)
                {
                    
                    claim.SupportingDocument = claim.supportingDocument.FileName; 
                }
                claim.Status = "Pending";
                _dbContext.Claims.Add(claim);
                _dbContext.SaveChanges();
                return RedirectToAction("ApproveRejectClaim");
            }

      

            return View(claim);

        }

        

       
       
       
    }
}
