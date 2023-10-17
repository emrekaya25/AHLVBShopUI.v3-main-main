using AHLVBShopUI.Core.DTO.Login;
using AHLVBShopUI.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        [HttpGet("/Anasayfa")]
        public IActionResult Index()
        {
			var AdSoyad = HttpContext.Session.GetString("AdSoyad");
			TempData["AdSoyad"] = AdSoyad;
			TempData.Keep("AdSoyad");


			return View();
        }
    }
}
