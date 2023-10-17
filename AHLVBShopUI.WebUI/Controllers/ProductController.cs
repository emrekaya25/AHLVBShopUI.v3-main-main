using AHLVBShopUI.Core.DTO.Brand;
using AHLVBShopUI.Core.DTO.Category;
using AHLVBShopUI.Core.DTO.Department;
using AHLVBShopUI.Core.DTO.Product;
using AHLVBShopUI.Core.Model;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
	public class ProductController : Controller
	{
		[HttpGet("/Products")]
		public async Task<IActionResult> Index()
		{

			var Role = HttpContext.Session.GetString("Role");
			TempData["Role"] = Role;
			TempData.Keep("Role");

			if (Role == "ea7a5630-c7c0-46f0-a026-c395716077a0")
			{
				return RedirectToAction("Index", "Home");
			}
			ProductViewModel productViewModel = new()
			{
				Products = await GetProducts(),
				Brands = await GetBrands(),
				Categories = await GetCategories()

			};
			return View(productViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> AddProduct()
		{
            ProductViewModel productViewModel = new()
            {
                Products = await GetProducts(),
                Brands = await GetBrands(),
                Categories = await GetCategories()

            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/AddProduct";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            var body = JsonConvert.SerializeObject(productDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);

            var responseObject = JsonConvert.DeserializeObject<ApiResult<ProductDTO>>(response.Content);



            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product");

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
			var Token = HttpContext.Session.GetString("Token");
			TempData["Token"] = Token;
			TempData.Keep("Token");


			var url = "http://localhost:5070/Product/" + id;
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
			var body = JsonConvert.SerializeObject(id);
			request.AddBody(body, "application/json");
			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<ApiResult<ProductDTO>>(response.Content);
			return View(responseObject.Data);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateProduct(ProductDTO productDTO)
		{
			var Token = HttpContext.Session.GetString("Token");
			TempData["Token"] = Token;
			TempData.Keep("Token");


			var url = "http://localhost:5070/UpdateProduct";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Post);
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
			var body = JsonConvert.SerializeObject(productDTO);
			request.AddBody(body, "application/json");
			RestResponse response = await client.ExecuteAsync(request);

			var responseObject = JsonConvert.DeserializeObject<ApiResult<ProductDTO>>(response.Content);



			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product");

			}
			else
			{
				return BadRequest();
			}
		}

		[HttpGet]
		public async Task<IActionResult> RemoveProduct(Guid id)
		{
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/RemoveProduct/"+id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product");

            }

            return BadRequest();
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
		public async Task<List<BrandDTO>> GetBrands()
		{
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/Brands";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);
			request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<ApiResult<List<BrandDTO>>>(response.Content);

			var brandList = responseObject.Data;

			return brandList;
		}

		[HttpGet]
		public async Task<List<CategoryDTO>> GetCategories()
		{
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/Categories";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);
			request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CategoryDTO>>>(response.Content);

			var categoryList = responseObject.Data;

			return categoryList;
		}
	}
}
