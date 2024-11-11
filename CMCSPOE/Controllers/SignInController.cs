using CMCSPOE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMCSPOE.Controllers
{
    public class SignInController : Controller
    {
        private readonly InMemoryDbContext _dbContext;

        public SignInController()
        {
            _dbContext = new InMemoryDbContext();
            _dbContext.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(SignIn signIn)
        {
            Console.WriteLine("Login action called");
            Console.WriteLine($"Attempting login for: {signIn.Email}");

            if (ModelState.IsValid)
            {
               
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == signIn.Email && u.Password == signIn.Password);
                if (user != null)
                {
                    if (user.Role == "Lecturer")
                    {
                        // Successful login
                        Console.WriteLine("Login successful");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Coordinator");
                    }
                }
                else
                {
                    // Invalid login attempt
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            // Log ModelState errors for debugging
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

          
            return View(signIn);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
