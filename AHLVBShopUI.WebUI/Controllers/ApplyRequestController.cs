using AHLVBShopUI.Core.DTO.Employee;
using AHLVBShopUI.Core.DTO.Product;
using AHLVBShopUI.Core.DTO.Request;
using AHLVBShopUI.Core.Model;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class ApplyRequestController : Controller
    {
        [HttpGet("/ApplyRequests")]
        public async Task<IActionResult> Index()
        {
            var Role = HttpContext.Session.GetString("Role");
            TempData["Role"] = Role;
            TempData.Keep("Role");

            if (Role == "ea7a5630-c7c0-46f0-a026-c395716077a0")
            {
                return RedirectToAction("Index", "Home");
            }
            RequestViewModel requestViewModel = new()
            {
                Employees = await GetEmployees(),
                Products = await GetProducts(),
                Requests = await GetRequests()
            };
            return View(requestViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateApplyRequest(Guid id)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");

            var AdSoyad = HttpContext.Session.GetString("AdSoyad");
            TempData["AdSoyad"] = AdSoyad;
            TempData.Keep("AdSoyad");
            var Id = HttpContext.Session.GetString("Id");
            TempData["Id"] = Id;
            TempData.Keep("Id");


            var url = "http://localhost:5070/GetRequest/" + id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            var body = JsonConvert.SerializeObject(id);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<RequestDTO>>(response.Content);
            return View(responseObject.Data);
        }





        [HttpGet]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");


            var url = "http://localhost:5070/Employees";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<EmployeeDTO>>>(response.Content);

            var employeeList = responseObject.Data;

            return employeeList;
        }


        [HttpGet]
        public async Task<List<ProductDTO>> GetProducts()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");


            var url = "http://localhost:5070/Products";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<ProductDTO>>>(response.Content);

            var productList = responseObject.Data;

            return productList;
        }

        [HttpGet]
        public async Task<List<RequestDTO>> GetRequests()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");


            var url = "http://localhost:5070/GetRequests";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<RequestDTO>>>(response.Content);

            var requestList = responseObject.Data;

            return requestList;
        }
    }
}
