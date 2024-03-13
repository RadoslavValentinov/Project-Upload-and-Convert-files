using Microsoft.AspNetCore.Mvc;
using MyWebProject.Core.Models;
using UploadFiles.Models.User;

namespace UploadFiles.Controllers
{
    public class UserController : Controller
    {
       
       

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return View();
        }


        public IActionResult Logout()
        {
            return View();
        }
    }
}
