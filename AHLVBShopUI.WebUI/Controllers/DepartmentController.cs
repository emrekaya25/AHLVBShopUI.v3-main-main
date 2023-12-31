﻿using AHLVBShopUI.Core.DTO.Brand;
using AHLVBShopUI.Core.DTO.Company;
using AHLVBShopUI.Core.DTO.Department;
using AHLVBShopUI.Core.Model;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class DepartmentController : Controller
    {
        [HttpGet("/Departments")]
        public async Task<IActionResult> Index()
        {
			var Role = HttpContext.Session.GetString("Role");
			TempData["Role"] = Role;
			TempData.Keep("Role");

			if (Role == "ea7a5630-c7c0-46f0-a026-c395716077a0")
			{
				return RedirectToAction("Index", "Home");
			}

			DepartmentViewModel viewModel = new DepartmentViewModel()
            {
                Departments = await GetDepartments(),
                Companies = await GetCompanies()
            };


            return View(viewModel);
        }

        [HttpGet]
        public async Task<List<DepartmentDTO>> GetDepartments()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/Departments";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<DepartmentDTO>>>(response.Content);

            var departmentList = responseObject.Data;

            return departmentList;
        }

        [HttpGet]
        public async Task<List<CompanyDTO>> GetCompanies()
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/GetCompanies";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CompanyDTO>>>(response.Content);

            var companyList = responseObject.Data;

            return companyList;
        }

        [HttpGet]
        public async Task<IActionResult> AddDepartment()
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel()
            {
                Companies = await GetCompanies(),
                Departments = await GetDepartments()

            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentDTO department)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/AddDepartment";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            var body = JsonConvert.SerializeObject(department);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            
            var responseObject = JsonConvert.DeserializeObject<ApiResult<DepartmentDTO>>(response.Content);
            
            

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Department");

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveDepartment(Guid id)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/RemoveDepartment/"+id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Department");

            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDepartment(Guid id)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/Department/" + id;
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            var body = JsonConvert.SerializeObject(id);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<DepartmentDTO>>(response.Content);
            return View(responseObject.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO departmentDTO)
        {
            var Token = HttpContext.Session.GetString("Token");
            TempData["Token"] = Token;
            TempData.Keep("Token");
            

            var url = "http://localhost:5070/UpdateDepartment";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + TempData["Token"]);
            var body = JsonConvert.SerializeObject(departmentDTO);
            request.AddBody(body, "application/json");
            RestResponse response = await client.ExecuteAsync(request);
            //var responseObject = JsonConvert.DeserializeObject<ApiResult<DepartmentDTO>>(response.Content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Department");

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
