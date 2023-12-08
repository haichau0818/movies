using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using movies.Models.DTO;
using movies.Repositories.Abstract;
using System.Xml.Linq;

namespace movies.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService _userAutService;


        private readonly ICompositeViewEngine _compositeViewEngine;
        public UserAuthenticationController(IUserAuthenticationService userAutService, ICompositeViewEngine compositeViewEngine)
        {
            _userAutService = userAutService;
            _compositeViewEngine = compositeViewEngine;
        }
        //public async Task<IActionResult> Register()
        //{
        //    //var viewName = $"~/Views/UserAuthentication/Login.cshtml";
        //    //var result = _compositeViewEngine.GetView("", viewName, false);

        //    //if (result.Success) return View(viewName);

        //    //// or do whatever you want
        //    //return NotFound();


        //    var model = new RegistrationModel
        //    {
        //        Email = "haichau0818@gmail.com",
        //        Username = "haichau",
        //        Name = "HaiChau",
        //        Password = "Admin@123",
        //        PasswordConfirm = "Admin@123",
        //        Role = "Admin"
        //    };
        //    var result = await _userAutService.RegisterAsync(model);
        //    return Ok(result.Message);
        //}

        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }
       
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result =  await _userAutService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index","Home");
            else
            {
                TempData["msg"] = result.Message;
                return View(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _userAutService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
