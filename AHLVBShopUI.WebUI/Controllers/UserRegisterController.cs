using AHLVBShopUI.Core.DTO.Brand;
using AHLVBShopUI.Core.DTO.User;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    
    public class UserRegisterController : Controller
    {
        

        [HttpGet("/Register")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserDTO user)
        {
            var url = "http://localhost:5070/AddUser";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(user);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            //var responseObject = JsonConvert.DeserializeObject<ApiResult<UserDTO>>(response.Content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "LoginPage");

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
