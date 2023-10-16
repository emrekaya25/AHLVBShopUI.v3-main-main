using Microsoft.AspNetCore.Mvc;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class LoginPageController : Controller
    {
        [HttpGet("/Giris")]
        [Route("action")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
