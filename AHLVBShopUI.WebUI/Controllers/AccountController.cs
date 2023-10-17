using AHLVBShopUI.Core.DTO.Login;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        [HttpGet("/Login")]
        public IActionResult Index()
        {
            //_httpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpGet("/LoginEmployee")]
        public IActionResult IndexEmployee()
        {
            //_httpContextAccessor.HttpContext.Session.Clear();
            return View();
        }

        [HttpPost("/UserLogin")]
        public async Task<IActionResult> UserLogin(LoginDTO loginDTO)
        {
            var url = "http://localhost:5070/LoginUser";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(loginDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(response.Content);

            if (responseObject.Data != null)
            {
                HttpContext.Session.SetString("AdSoyad", responseObject.Data.AdSoyad);
                var AdSoyad = HttpContext.Session.GetString("AdSoyad");
                TempData["AdSoyad"] = AdSoyad;
                TempData.Keep("AdSoyad");

                HttpContext.Session.SetString("Token", responseObject.Data.Token);
                var Token = HttpContext.Session.GetString("Token");
                TempData["Token"] = Token;
                TempData.Keep("Token");

                HttpContext.Session.SetString("Role", responseObject.Data.RoleId);
                var Role = HttpContext.Session.GetString("Role");
                TempData["Role"] = Role;
                TempData.Keep("Role");

                HttpContext.Session.SetString("Id", responseObject.Data.Id);
                var Id = HttpContext.Session.GetString("Id");
                TempData["Id"] = Id;
                TempData.Keep("Id");



                return RedirectToAction("Index", "Home");
            }

            //Session
            ViewData["LoginError"] = "Kullanıcı Adı Veya Şifreniz Yanlış";

            return View("Index");
        }

        [HttpPost("/EmployeeLogin")]
        public async Task<IActionResult> EmployeeLogin(LoginDTO loginDTO)
        {
            var url = "http://localhost:5070/LoginEmployee";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(loginDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<LoginDTO>>(response.Content);

            if (responseObject.Data != null)
            {
				HttpContext.Session.SetString("AdSoyad", responseObject.Data.AdSoyad);
				var AdSoyad = HttpContext.Session.GetString("AdSoyad");
				TempData["AdSoyad"] = AdSoyad;
				TempData.Keep("AdSoyad");

				HttpContext.Session.SetString("Token", responseObject.Data.Token);
				var Token = HttpContext.Session.GetString("Token");
				TempData["Token"] = Token;
				TempData.Keep("Token");

				HttpContext.Session.SetString("Role", responseObject.Data.RoleId);
				var Role = HttpContext.Session.GetString("Role");
				TempData["Role"] = Role;
				TempData.Keep("Role");

				HttpContext.Session.SetString("Id", responseObject.Data.Id);
				var Id = HttpContext.Session.GetString("Id");
				TempData["Id"] = Id;
				TempData.Keep("Id");

				return RedirectToAction("Index", "Home");
            }

            //Session
            ViewData["LoginError"] = "Kullanıcı Adı Veya Şifreniz Yanlış";

            return View("Index");
        }
    }
}
