using CMCSPOE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMCSPOE.Controllers
{
    public class LecturerController : Controller
    {
        private readonly InMemoryDbContext _dbContext;

        public LecturerController(InMemoryDbContext dbContext)
        {
            _dbContext = new InMemoryDbContext();
            _dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                var lecturer = new User
                {
                    Name = signUp.Username,
                    Email = signUp.Email
                };
                _dbContext.Users.Add(lecturer);
                return RedirectToAction("Login");
            }
            return View(signUp);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitClaim(ClaimModel claim, IFormFile supportingDocument)
        {
            if (ModelState.IsValid)
            {
                if (supportingDocument != null)
                {
                    
                    claim.SupportingDocument = supportingDocument.FileName;
                }
                claim.Status = "Pending";
                _dbContext.Claims.Add(claim);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(claim);
        }
    }
}
