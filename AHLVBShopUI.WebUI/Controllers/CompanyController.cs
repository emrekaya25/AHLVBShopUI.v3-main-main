using AHLVBShopUI.Core.DTO.Brand;
using AHLVBShopUI.Core.DTO.Category;
using AHLVBShopUI.Core.DTO.Company;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class CompanyController : Controller
    {
        [HttpGet("/Companies")]
        public async Task<IActionResult> Index()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");

			var Role = HttpContext.Session.GetString("Role");
			TempData["Role"] = Role;
			TempData.Keep("Role");

			if (Role == "ea7a5630-c7c0-46f0-a026-c395716077a0")
			{
				return RedirectToAction("Index", "Home");
			}

			var url = "http://localhost:5070/GetCompanies";
            var client = new RestClient(url);
            var request = new RestRequest(url,Method.Get);

            request.AddHeader("Content-Type", "application/json");
            //
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            //

            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CompanyDTO>>> (response.Content);

            var companyList = responseObject.Data;
            return View(companyList.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> AddCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany (CompanyDTO company)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            


            var url = "http://localhost:5070/AddCompany";
            var client = new RestClient(url);
            var request = new RestRequest(url,Method.Post);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            var body = JsonConvert.SerializeObject(company);
            request.AddBody(body, "application/json");

            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<CompanyDTO>> (response.Content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCompany(Guid id)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");



            var url = "http://localhost:5070/RemoveCompany/" + id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);

            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Company");

            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCompany(Guid id)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            


            var url = "http://localhost:5070/Company/" + id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);

            var body = JsonConvert.SerializeObject(id);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<CompanyDTO>>(response.Content);
            return View(responseObject.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompany(CompanyDTO company)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");


            var url = "http://localhost:5070/UpdateCompany";
            var client = new RestClient(url);   
            var request = new RestRequest(url,Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);

            var body = JsonConvert.SerializeObject(company);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<CompanyDTO>>(response.Content);

            return RedirectToAction("Index", "Company");
        }
    }
}
