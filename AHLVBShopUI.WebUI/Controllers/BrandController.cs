using AHLVBShopUI.Core.DTO.Brand;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class BrandController : Controller
    {

        [HttpGet("/Brands")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5070/Brands";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<BrandDTO>>>(response.Content);
            var brandList = responseObject.Data;

            return View(brandList.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> AddBrand()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandDTO brandDTO)
        {
            var url = "http://localhost:5070/AddBrand";
            var client = new RestClient(url);
            var request = new RestRequest(url,Method.Post);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(brandDTO);
            request.AddBody(body,"application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<BrandDTO>>(response.Content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand");

            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public async Task<IActionResult> RemoveBrand(Guid id)
        {
            var url = "http://localhost:5070/RemoveBrand/"+id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index","Brand");

            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(Guid id)
        {
            var url = "http://localhost:5070/Brand/"+id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(id);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<BrandDTO>>(response.Content);
            return View(responseObject.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(BrandDTO brandDTO)
        {
            var url = "http://localhost:5070/UpdateBrand";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(brandDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<BrandDTO>>(response.Content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand");

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
