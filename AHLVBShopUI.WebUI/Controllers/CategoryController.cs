using AHLVBShopUI.Core.DTO.Brand;
using AHLVBShopUI.Core.DTO.Category;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class CategoryController : Controller
    {

        [HttpGet("/Categories")]
        public async Task<IActionResult> Index()
        {
            var url = "http://localhost:5070/Categories";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CategoryDTO>>>(response.Content);

            var categoryList = responseObject.Data;
            return View(categoryList.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            var url = "http://localhost:5070/AddCategory";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(categoryDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<CategoryDTO>>(response.Content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCategory(Guid id)
        {
            var url = "http://localhost:5070/RemoveCategory/" + id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");

            }

            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            var url = "http://localhost:5070/Category/" + id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(id);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<CategoryDTO>>(response.Content);
            return View(responseObject.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryDTO categoryDTO)
        {
            var url = "http://localhost:5070/UpdateCategory";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

            var body = JsonConvert.SerializeObject(categoryDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<CategoryDTO>>(response.Content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category");

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
