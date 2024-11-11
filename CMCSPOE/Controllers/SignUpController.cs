using CMCSPOE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMCSPOE.Controllers
{
    public class SignUpController : Controller
    {
        private readonly InMemoryDbContext _dbContext;

        public SignUpController(InMemoryDbContext dbContext)
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
                
                var user = new User
                {
                    
                    Username = signUp.Username,
                    Password = signUp.Password, 
                    Email = signUp.Email
                };

                _dbContext.Users.Add(user); 
                _dbContext.SaveChanges(); 

                
                return RedirectToAction("Index", "Home"); 
            }
            return View(signUp); 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
    

    
}
