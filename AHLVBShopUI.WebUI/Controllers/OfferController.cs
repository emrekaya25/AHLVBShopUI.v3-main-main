using AHLVBShopUI.Core.DTO.Offer;
using AHLVBShopUI.Core.DTO.Request;
using AHLVBShopUI.Core.DTO.User;
using AHLVBShopUI.Core.Model;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class OfferController : Controller
    {
        [HttpGet ("/Offers")]
        public async Task<IActionResult> Index()
        {
            OfferViewModel offerViewModel = new()
            {
                Requests = await GetRequests(),
                Offers = await GetOffers(),
                Users = await GetUsers()
            };
            return View(offerViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetOffersRequest(Guid id)
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


        [HttpPost]
        public async Task<IActionResult> AddOffer(OfferDTO offerDTO)
        {
			var Token = HttpContext.Session.GetString("Token");
			TempData["Token"] = Token;
			TempData.Keep("Token");


			var url = "http://localhost:5070/AddOffer";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Post);
			request.AddHeader("Content-Type", "application/json");
			request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
			var body = JsonConvert.SerializeObject(offerDTO);
			request.AddBody(body, "application/json");
			RestResponse response = await client.ExecuteAsync(request);

			//var responseObject = JsonConvert.DeserializeObject<ApiResult<RequestDTO>>(response.Content);



			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Offer");

			}
			else
			{
				return BadRequest();
			}
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

        [HttpGet]
        public async Task<List<OfferDTO>> GetOffers()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");


            var url = "http://localhost:5070/Offers";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<OfferDTO>>>(response.Content);

            var offerList = responseObject.Data;

            return offerList;
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetUsers()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");


            var url = "http://localhost:5070/Users";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<UserDTO>>>(response.Content);

            var userList = responseObject.Data;

            return userList;
        }
    }
}
