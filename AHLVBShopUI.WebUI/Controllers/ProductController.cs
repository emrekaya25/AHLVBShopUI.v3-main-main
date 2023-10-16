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
            var url = "http://localhost:5070/AddProduct";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

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
            var url = "http://localhost:5070/RemoveProduct/"+id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");

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
			var url = "http://localhost:5070/Products";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);
			request.AddHeader("Content-Type", "application/json");

			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<ApiResult<List<ProductDTO>>>(response.Content);

			var productList = responseObject.Data;

			return productList;
		}

		[HttpGet]
		public async Task<List<BrandDTO>> GetBrands()
		{
			var url = "http://localhost:5070/Brands";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);
			request.AddHeader("Content-Type", "application/json");

			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<ApiResult<List<BrandDTO>>>(response.Content);

			var brandList = responseObject.Data;

			return brandList;
		}

		[HttpGet]
		public async Task<List<CategoryDTO>> GetCategories()
		{
			var url = "http://localhost:5070/Categories";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);
			request.AddHeader("Content-Type", "application/json");

			RestResponse response = await client.ExecuteAsync(request);
			var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CategoryDTO>>>(response.Content);

			var categoryList = responseObject.Data;

			return categoryList;
		}
	}
}
